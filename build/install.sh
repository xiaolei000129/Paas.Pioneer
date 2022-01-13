#!/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# 环境部署入口

# 引入帮助方法 注意：因为所有脚本都可能引用该脚本所以顶级引用
# 当前目录
path_current="$PWD"

source $path_current/helper.sh

source $path_current/component/docker/dockerInstall.sh

# 部署docker
fun_load_docker

clear

echo 
echo -e "请选择安装资源：默认退出操作"
echo -e "1.安装Dotnet"
echo -e "2.删除Dotnet"
echo -e "3.删除docker(此操作会删除所有容器、镜像、容器数据)"
echo -e "4.安装(redis、RabbitMQ)"
echo -e "5.安装数据库(安装mysql8.0)"
echo -e "6.安装日志系统(SEQ)"
echo -e "7.安装追踪链系统(Skywalking)"
echo -e "8.添加docker用户组（如果不是root用户，执行docker没有权限，所以需要添加当前用户操作权限）"
echo -e "9.关闭Docker日志"
echo -e "10.启用Docker日志\n"
echo -e "请选择需要安装的资源"

read  -n 2 chose_input

case $chose_input in
    "1")
        echo -e "\n安装Dotnet"
        source dotnetcore/DotnetInstall.sh
        fun_load_dotnet
        ;;
    "2")
        echo -e "\n删除Dotnet"
        source dotnetcore/DotnetRemove.sh
        fun_load_dotnet_remove
        ;;
    "3")
        echo -e "\n删除docker(此操作会删除所有容器、镜像、容器数据)"
        source component/docker/DockerRemove.sh
        fun_load_docker_remove
        ;;
    "4")
        echo -e "\n安装(redis、RabbitMQ)"
        source component/images/RedisInstall.sh
        fun_Redis_load
        source component/images/RabbitMQInstall.sh
        fun_RabbitMQ_load
        ;;  
    "5")
        echo -e "\n安装数据库(安装mysql8.0)"
        source component/images/MySqlInstall.sh
        fun_mysql_load
        ;;
   "6")
        echo -e "\n安装日志系统(SEQ)"
        source component/images/SEQInstall.sh
        fun_SEQ_load
        ;;
    "7")
        echo -e "\n安装追踪链系统(Skywalking)"
        source component/images/SkywalkingInstall.sh
        fun_skywalking_oap_server_load
        ;;
    "8")
        echo -e "\n添加docker用户组"
        func_add_user_docker
        ;;
    "9")
        echo -e "\n关闭Docker日志"
        func_config_docker_log disable
        ;;
    "10")
        echo -e "\n启用Docker日志"
        func_config_docker_log enable
        ;;
     *) 
      echo '下次再来执行我吧！！！'
    ;;
esac



