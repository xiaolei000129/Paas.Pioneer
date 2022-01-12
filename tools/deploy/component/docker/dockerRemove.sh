# !/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# docker卸载

fun_load_docker_remove(){
  
  echo -e "您确定删除docker(此操作会删除所有容器、镜像、容器数据)吗？ \n确定请输入：y、取消直接回车"
  read  -n 1 input
  
  if [[ $input == "y" ]] ;then

  ## 本地环境信息
  echo -e "\n--------------docker信息-----------------"
  docker info 
  echo "----------------------------------------------"

  # 停止所有容器
  docker stop $(docker ps -aq)

  # 删除所有容器
  docker rm $(docker ps -aq)

  # 删除所有镜像
  docker rmi $(docker images -q)

# 停止进程
  systemctl stop docker.service

  # 杀死docker进程（为防止特殊情况下有残留的docker进程）
  ps -ef | grep docker | awk '{print $2}' | xargs sudo kill -s 9

  # 删除挂载目录
  rm -rf "/home/docker"

  # 删除执行状态文件的根目录
  # 默认值/var/run/docker，可通过dockerd命令的--exec-root选项修改
  sudo rm -rf /var/run/docker

  # 删除默认监听的Unix域套接字，容器中的进程可以通过它与Docker守护进程进行通信
  sudo rm -rf /var/run/docker.sock

  # 删除docker守护进程PID文件
  # 默认值/var/run/docker.pid，可通过dockerd命令的-p或--pidfile选项修改
  sudo rm -rf /var/run/docker.pid
  
  # 删除系统服务配置文件
  sudo rm -rf /etc/systemd/system/docker.service

  # 删除docker配置文件
  # 默认值/etc/docker/daemon.json，可通过dockerd命令的--config-file选项修改
  sudo rm -rf /etc/docker/daemon.json

  # 删除自动生成的文件，tls相关配置：~/.docker/{ca.pem,cert.pem,key.pem}
  sudo rm -rf ~/.docker/

# 删除docker 文件信息
  rm -rf /usr/bin/containerd
  rm -rf /usr/bin/containerd-shim
  rm -rf /usr/bin/ctr
  rm -rf /usr/bin/runc
  rm -rf /usr/bin/docker*
  echo "删除docker文件信息"

# 删除配置
  rm -rf /etc/docker/
  echo "删除docekr配置"

# 删除镜像/容器
  rm -rf /var/lib/docker

  echo "删除docker镜像/容器"

  echo "docker卸载成功"

  fi
}

