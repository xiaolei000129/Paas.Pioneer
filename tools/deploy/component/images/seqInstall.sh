# !/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# docker导入SEQ镜像启动容器

path_seq="$path_current/component/images/environment";

images_name="seq-latest";

# 容器挂载目录
path_seq_mount="/home/docker/$images_name"

# 数据挂载目录
path_seq_data="$path_seq_mount/data"

# docker导入SEQ镜像启动容器
fun_SEQ_load(){
  file_source_seq="$path_seq/$images_name.tar";
  # 判断文件是否存在
  fun_check_file  $file_source_seq
  
  if [ $? -eq 1 ] ; then
  error "缺少$file_source_seq镜像文件"
  return
  fi

  func_check_image "datalust/seq:latest"

  if [ $? -eq 1 ] ;then
    # 导入docker镜像
    docker load -i $file_source_seq
  fi
  
  # 判断是否已经存在容器
  func_check_container "datalust/seq:latest"

  if [ $? -eq 0 ] ;then
      error "容器datalust/seq:latest已安装，如需重新安装，请先卸载"  
      return
  fi

  # 创建seq挂在目录
  fun_create_path $path_seq_data

  # 运行容器
  docker run --name seq -d --restart=always -e ACCEPT_EULA=Y -v $path_seq_data:/data  -p 80:80  -p 5341:5341 datalust/seq:latest
}
