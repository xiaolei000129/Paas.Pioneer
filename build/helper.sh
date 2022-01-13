#!/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# 帮助方法

# 路径部署
path_deploy=$(dirname "$PWD")

# 当前目录
path_current="$PWD"

## 打印
success()
{
	echo -e "\033[32m ${1} \033[0m"
}

info()
{
	echo -e "\033[37m ${1} \033[0m"
}

warning()
{
	echo -e "\033[33m ${1} \033[0m"
}

error()
{
	echo -e "\033[31m ${1} \033[0m"
}

# 创建目录给予777权限
fun_create_path() 
{
    sudo mkdir -p -m 777 $1
    success "创建目录:$1成功"
}

# 目录给予777权限
func_chmod_path()
{ 
    sudo chmod 777 -R $1
    success "目录:$1授权成功"
}

# 判断文件是否存在
fun_check_file() 
{
    if [ ! -f $1 ]; then 
        error "$1文件不存在"
        return 1
    fi
    info "$1文件存在"
    return 0
}

# 判断是否安装
func_check_install()
{
    result_which=$(which $1)
    if [ -z $result_which  ];then
        error "$1未安装"
        return 1
    fi  
    rule_notfound="found"
    if [[ $result_which =~ $rule_notfound ]] ;then
        error "$1未安装"
        return 1 
    fi
    return 0
}

# 判断docker容器是否存在
func_check_container()
{
    # 容器名称IMAGE
    image_name=$1
    # 获取该容器信息
    array_container=$(docker ps -a --filter ancestor=$image_name | tail -n +2)
    # 判断数量是否大于0
    if [ ${#array_container[*]} -gt 0 ] ;then
        # 判断容器名字
        content=${array_container[0]}
        # 判断是否为空，为空则为真
        if [ -z "$content"  ];then
            return 1
        fi
        return 0
    fi
    return 1
}

# 判断docker镜像是否存在
func_check_image()
{
    docker_image=$(docker images $1 | tail -n +2)
    if [[ -n $docker_image ]];then
        #success "$1镜像已导入"
        return 0
    fi
    #error "$1镜像未导入"
    return 1
}

# 删除所有为none的镜像
fun_delete_images_none()
{
    docker images|grep none|awk '{print $3}'|xargs docker rmi

    success "删除所有为none的镜像"
}

# 删除docker容器
func_rm_container()
{
    info "正在卸载$1"
    array_container=$(docker ps -a --filter ancestor=$1 | tail -n +2)
    for container in ${array_container[*]} ;do
        info "正在停止容器${container}"
        docker stop $container
        info "正在删除容器${container}"
        docker rm $container
    done
    success "$1卸载成功"
}

# 启动docker容器
func_start_container()
{
  array_container=$(docker ps -a  --filter ancestor=$1 | tail -n +2)

  for container in ${array_container[*]} ;do

        docker start $container
        info "容器$1-${container}启动成功"
  done
}

# 添加当前用户到docker
func_add_user_docker()
{
    #添加docker用户组
    sudo groupadd docker 

    #将登陆用户加入到docker用户组中
    sudo gpasswd -a $USER docker 

    #更新用户组
    newgrp docker 
}

# docker日志信息
func_config_docker_log()
{
    info "正在查询当前日志级别"
    current_log_level=$(docker info --format '{{.LoggingDriver}}')

    log_level="none"

    if [ "$1" = "disable" ];then
        log_level="none"
    fi    
    
    if  [ "$1" = "enable" ];then
        log_level="json-file"
    fi

    if  [ "$current_log_level" = "$log_level" ];then
        
        success "当前日志级不需要重复设置，如显示不正确，请手动重启Docker服务"
        return
    fi 

    path_docker_docker="/etc/docker"

    # 创建目录给予权限
    fun_create_path $path_docker_docker

    path_docker_daemon="$path_docker_docker/daemon.json"

    # 判断是否存在这个文件
     if [ -f $path_docker_daemon ];then
        sudo rm -rf $path_docker_daemon
     fi

# 开启
if  [ "$1" = "enable" ];then
cat <<EOT > ${path_docker_daemon}
{
  "log-driver":"json-file",
  "log-opts": {"max-size":"500m", "max-file":"3"}
}
EOT
fi

# 关闭
if [ "$1" = "disable" ];then
cat <<EOT > ${path_docker_daemon}
{
  "log-driver":"none"
}
EOT
fi  

systemctl daemon-reload

systemctl restart docker.service

success "Docker重新启动成功"

systemctl is-active docker.service

#systemctl status docker.service

success "因Docker占用资源过大，不建议频繁重启，休眠10秒钟，休眠过后继续后续操作"
sleep 10  
}

path_tenforce_config="/etc/selinux/config";
# 判断当前模式是否为禁止dokcer运行模式
fun_linex_is_enforcing(){
    success "正在修改Linux运行模式，方式docker运行出现错误"
        # 获取当前执行模式
    tenforce=$(getenforce)

    # 设置SELinux 成为permissive模式
    if [ $tenforce == "Enforcing" ] ; then

    success "成功设置SELinux 成为disabled模式、服务器将进行重启一次之后生效"

    rm -rf $path_tenforce_config

    cat <<EOT > ${path_tenforce_config}
    # This file controls the state of SELinux on the system.
    # SELINUX= can take one of these three values:
    #     enforcing - SELinux security policy is enforced.
    #     permissive - SELinux prints warnings instead of enforcing.
    #     disabled - No SELinux policy is loaded.
    SELINUX=disabled
    # SELINUXTYPE= can take one of three values:
    #     targeted - Targeted processes are protected,
    #     minimum - Modification of targeted policy. Only selected processes are protected.
    #     mls - Multi Level Security protection.
    SELINUXTYPE=targeted
EOT

    # 重启服务器
    reboot
    fi
}