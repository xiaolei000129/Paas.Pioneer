#!/bin/bash
# 时间：2022-01-13
# 创建人：段晨曦
# 环境部署入口

# 引入帮助方法 注意：因为所有脚本都可能引用该脚本所以顶级引用
# 当前目录
path_current="$PWD"

sed -i 's/\r$//' $path_current/helper.sh

sed -i 's/\r$//' $path_current/install-admin-core.sh

sed -i 's/\r$//' $path_current/install-hangfire.sh

source $path_current/helper.sh

echo 
echo -e "请选择安装资源：默认退出操作"
echo -e "1.发布admin-core"
echo -e "2.发布hangfire"
echo -e "3.删除所有为none的镜像"
echo -e "4.添加docker用户组（如果不是root用户，执行docker没有权限，所以需要添加当前用户操作权限）"
echo -e "5.关闭Docker日志"
echo -e "6.启用Docker日志\n"
echo -e "请选择需要安装的资源"

read  -n 2 chose_input

case $chose_input in
    "1")
        echo -e "\n发布admin-core"
        source $path_current/install-admin-core.sh
        ;;
    "2")
        echo -e "\n发布hangfire"
        source $path_current/install-hangfire.sh
        ;;
    "3")
        echo -e "\n删除所有为none的镜像"
        fun_delete_images_none
        ;;
    "4")
        echo -e "\n添加docker用户组"
        func_add_user_docker
        ;;
    "5")
        echo -e "\n关闭Docker日志"
        func_config_docker_log disable
        ;;
    "6")
        echo -e "\n启用Docker日志"
        func_config_docker_log enable
        ;;
     *) 
      echo '下次再来执行我吧！！！'
    ;;
esac