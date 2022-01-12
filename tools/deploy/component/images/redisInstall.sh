# !/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# docker导入Redis镜像启动容器

path_redis="$path_current/component/images/environment";

images_name="redis";

conf_name="redis.conf";

path_redis_mount="/home/docker/$images_name"

# 配置挂载目录
path_redis_conf="$path_redis_mount/confg"

# 数据挂载目录
path_redis_data="$path_redis_mount/data"

# 文件路径
file_redis_conf="$path_redis_conf/$conf_name";

# docker导入Redis镜像启动容器
fun_Redis_load(){
  file_source_redis="$path_redis/$images_name.tar";
  # 判断文件是否存在
  fun_check_file  $file_source_redis
  
  if [ $? -eq 1 ] ; then
  error "缺少$file_source_redis镜像文件"
  return
  fi

  func_check_image "redis:latest"

  if [ $? -eq 1 ] ;then
    # 导入docker镜像
    docker load -i $file_source_redis
  fi

  # 判断是否已经存在容器
  func_check_container "redis:latest"

  if [ $? -eq 0 ] ;then
      error "容器redis:latest已安装，如需重新安装，请先卸载"  
      return
  fi
  
  # 创建redis挂在目录
  fun_create_path $path_redis_conf

  # 创建redis挂在目录
  fun_create_path $path_redis_data

  # 复制配置文件进行挂载
  sudo cp "$path_redis/$images_name/$conf_name" $file_redis_conf

  # 运行容器
  docker run -p 6379:6379 -v $file_redis_conf:/etc/redis/redis.conf -v $path_redis_data:/data:rw --privileged=true --restart=always --name redis -d redis:latest
}