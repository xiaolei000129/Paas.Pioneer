# !/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# docker导入rabbitmq镜像启动容器

path_rabbitmq="$path_current/component/images/environment";

images_name="rabbitmq-management";

# 容器挂载目录
path_rabbitmq_mount="/home/docker/$images_name"

# 数据挂载目录
path_rabbitmq_data="$path_rabbitmq_mount/data"

# docker导入rabbitmq镜像启动容器
fun_RabbitMQ_load(){
    file_source_rabbitmq="$path_redis/$images_name.tar";
  # 判断文件是否存在
  fun_check_file  $file_source_rabbitmq
  
  if [ $? -eq 1 ] ; then
  error "缺少$file_source_rabbitmq镜像文件"
  return
  fi

  func_check_image "rabbitmq:management"

  if [ $? -eq 1 ] ;then
    # 导入docker镜像
    docker load -i $file_source_rabbitmq
  fi
  
  # 判断是否已经存在容器
  func_check_container "rabbitmq:management"

  if [ $? -eq 0 ] ;then
      error "容器rabbitmq:management已安装，如需重新安装，请先卸载"  
      return
  fi

  # 创建rabbitmq挂在目录
  fun_create_path $path_rabbitmq_data

  # 运行容器
  docker run -d --name Myrabbitmq  -v $path_rabbitmq_data:/var/lib/rabbitmq --restart=always -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=admin -p 15672:15672 -p 5672:5672 rabbitmq:management
}
