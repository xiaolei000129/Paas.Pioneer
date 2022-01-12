#!/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# 安装Net 5

echo "-------应用服务器安装脚本--------"
echo "1 自动检测是否安装NetCoe运行时"
echo "2 否： 安装NetCoe运行时"
echo "---------------------------------"

echo "根路径$path_current"

# dotnet软件目录
path_dotnetcore="$path_current/dotnetcore/environment"

echo "dotnet目录$path_dotnetcore"

# dotnet安装目录
path_dotnet="/usr/bin"

#------脚本需检查的进程------#
processname_dotnet="dotnet"
#------脚本需检查的进程------#

# dotnet运行时监测||安装
func_install_netcoreruntime()
{
    func_check_install $processname_dotnet

    if [ $? -eq 0 ] ;then

        success "dotnet运行时已安装"
        return 
    fi

    file_runtime_aspnetcore="$path_dotnetcore/aspnetcore-runtime-5.0.0-linux-x64.tar.gz"
    file_runtime_dotnet="$path_dotnetcore/dotnet-runtime-5.0.0-linux-x64.tar.gz"
    
    fun_check_file $file_runtime_aspnetcore
    
    if [ $? -eq 1 ] ;then
        error "缺少安装dotnet运行时必要组件$file_runtime_aspnetcore"
        exit 1
    fi

    fun_check_file $file_runtime_dotnet
    
    if [ $? -eq 1 ] ;then
        error "缺少安装dotnet运行时必要组件$file_runtime_dotnet"
        exit 1
    fi

   #mkdir -p $HOME/dotnet 
    
    info "正在安装aspnetcore运行时"

    tar zxf $file_runtime_aspnetcore -C $path_dotnet
    
    info "正在安装dotnet运行时"
    
    tar zxf $file_runtime_dotnet -C $path_dotnet
    
    info "正在注册环境变量"
    export DOTNET_ROOT=$path_dotnet
    export PATH=$PATH:$path_dotnet

    source /etc/profile

    func_check_install $processname_dotnet  

    if [ $? -eq 0 ] ;then

        success "dotnet运行时安装成功" 
        return 
    fi
}

fun_load_dotnet(){
    ##----脚本入口逻辑----##
    success "1.正在安装NetCore运行时"

    func_install_netcoreruntime

    dotnet --info
}


