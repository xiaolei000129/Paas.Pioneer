# !/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# 使用docker-compose进行服务启动

# 引入帮助方法 注意：因为所有脚本都可能引用该脚本所以顶级引用
# 当前目录
path_current="$PWD"

source $path_current/Helper.sh

source $path_current/component/docker/DockerInstall.sh

# 部署docker
fun_load_docker

# 导入镜像数组
name_images=("mysql.tar" "rabbitmq-management.tar" "redis.tar" "seq-latest.tar" "skywalking-oap-server.tar" "skywalking-ui.tar");

# 镜像路径
path_image="$path_current/component/images/environment";

# docker导入SEQ镜像启动容器
fun_docker_load(){
  for item in ${name_images[@]}
  do
    file_source_image="$path_image/$item";
    # 判断文件是否存在
    fun_check_file  $file_source_image
    
    if [ $? -eq 1 ] ; then
    error "缺少$file_source_image镜像文件"
    return
    fi

    func_check_image $file_source_image

    if [ $? -eq 1 ] ;then
      # 导入docker镜像
      docker load -i $file_source_image
    fi
  done
}

# 导入镜像数组
name_composes=("mysql" "rabbitmq" "redis" "seq" "skywalking");

path_compose="$path_current/component/images";

fun_compose_up(){
  # 进入docker-compose执行目录
  cd $path_compose

 for item in ${name_composes[@]}
  do
    docker-compose -f "docker-compose-$item.yml" up -d
  done
}

fun_docker_load

fun_compose_up