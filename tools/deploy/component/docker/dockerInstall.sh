#!/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# 安装docker环境

echo "-------应用服务器安装脚本--------"
echo "1 自动检测是否安装docker环境"
echo "2 否： 安装docker环境"
echo "---------------------------------"

# 路径部署
path_deploy=$(dirname "$PWD")

# 当前目录
path_current="$PWD"

# 部署环境名称
processname_docker="docker"

# 安装目录
path_docker="/usr/bin"

# 部署资源位置
path_ent_docker="$path_current/component/docker/environment"

# 安装包名称
path_name_docker="docker-19.03.9.tgz"

success "当前路径：$path_current"
success "当前软件安装路径：$path_deploy"

# 安装docker
func_install_docker()
{
    # 判断是否重复安装
    func_check_install $processname_docker
        if [ $? -eq 0 ] ;then
        success "Docker已经安装"
        return 
    fi

    file_source_docker="$path_ent_docker/$path_name_docker" 

    info "正在检查$file_source_docker是否存在"
    
    fun_check_file $file_source_docker
    
    if [ $? -eq 1 ] ;then
        error "缺少安装Docker守护进程必要组件$file_source_docker"
        exit 1
    fi

    # 配置docker信息
    path_docker_docker="/etc/docker"

    fun_create_path $path_docker_docker

    # 文件名字和路径
    path_docker_daemon="$path_docker_docker/daemon.json"

    # 如果存在就删除
    if [ -f $path_docker_daemon ];then
        sudo rm -rf $path_docker_daemon
    fi

    # 写入配置信息
    cat <<EOT > ${path_docker_daemon}
    {
    "log-driver":"json-file",
    "log-opts": {"max-size":"500m", "max-file":"3"}
    }
EOT

    # 安装Docker
    
    info "正在解压Docker..........." 

    tar zxvf  $file_source_docker 

    #  赋值文件
    cp docker/* /usr/bin/

    # 删除文件夹
    rm -rf docker

    info "完成Docker安装..........."

    func_check_install $processname_docker

    if [ $? -eq 0 ] ;then
        sudo dockerd &
        success "Docker安装成功"
        # 创建docker守护进程
        func_config_systemd_docker
        success "docker配置生效中、将重启一次服务器。"
        reboot
        return 
    fi

    error "Docker安装失败"
}

# 开启守护进程
func_config_systemd_docker()
{
    info "正在配置Docker开机自启动"

    name_server="docker.service"
    path_server="/etc/systemd/system/$name_server"

    if [ -f $path_server ];then

        sudo rm -rf $path_server

        return 
    fi

    path_docker_root_dir="$path_deploy/docker/"

    fun_create_path $path_docker_root_dir

    cat <<EOT >> $path_server
[Unit]
Description=service for docker
After=network-online.target firewalld.service
Wants=network-online.target

[Service]
Type=notify
ExecStart=/usr/bin/dockerd --data-root="$path_docker_root_dir" -H tcp://0.0.0.0:2375 -H unix://var/run/docker.sock
ExecReload=/bin/kill -s HUP $MAINPID
LimitNOFILE=infinity
LimitNPROC=infinity
LimitCORE=infinity
TimeoutStartSec=0
Delegate=yes
KillMode=process
Restart=on-failure
StartLimitBurst=3
StartLimitInterval=60s

[Install]
WantedBy=multi-user.target
EOT

info "删除当前Docker运行进程ID"

rm -rf /var/run/docker.pid

chmod +x $path_server

info "创建Docker开机自启动文件成功"

systemctl daemon-reload 

info "重新加载开机自动项成功"

systemctl enable "$name_server"

info "配置Docker开机自启动成功"

docker_status=$(systemctl is-enabled docker)

if [ "$docker_status" = "disable" ];then
    error "Docker已禁用开机自启动"
fi    

if [ "$docker_status" = "enable" ];then
    success "Docker已启用开机自启动"
fi

info "正在重新启动Docker"

success "因Docker占用资源过大，不建议频繁重启，休眠20秒钟，休眠过后继续后续操作"
sleep 20

systemctl restart "$name_server"

success "Docker重新启动成功"

systemctl is-active "$name_server"

#systemctl status "$name_server"
}

# docker-compose文件名称
path_name_docker_compose="docker-compose-Linux-x86_64";

# docker-compose程序名称
processname_docker_compose="docker-compose";

# docker-compose安装
fun_install_docker_compose () {
        # 判断是否重复安装
    func_check_install $processname_docker_compose
    if [ $? -eq 0 ] ;then
      success "Docker-compose已经安装"
      return 
    fi

    file_source_docker="$path_ent_docker/$path_name_docker_compose" 

    info "正在检查$file_source_docker是否存在"
    
    fun_check_file $file_source_docker
    
    if [ $? -eq 1 ] ;then
        error "缺少安装Docker守护进程必要组件$file_source_docker"
        exit 1
    fi

    # 移动文件目录和修改名称
    sudo cp $file_source_docker /usr/local/bin/docker-compose 

    # 添加docker-compose权限
    sudo chmod +x /usr/local/bin/docker-compose

    # 查看docker-compose版本
    docker-compose -v

    success "docker-compose安装成功"
}


fun_load_docker(){
    # 判断当前模式是否为禁止dokcer运行模式
    fun_linex_is_enforcing

    # 安装docker环境
    func_install_docker

    # docker-compose安装
    fun_install_docker_compose

    # 查看docker信息
    docker info 
}


