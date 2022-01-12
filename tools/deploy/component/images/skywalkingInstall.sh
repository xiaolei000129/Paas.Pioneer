# !/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# docker导入skywalking_oap_server镜像启动容器
# docker导入skywalking_ui镜像启动容器

path_skywalking="$path_current/component/images/environment";

images_name="skywalking-oap-server";

# docker导入skywalking_oap_server镜像启动容器
fun_skywalking_oap_server_load(){
  file_source_skywalking="$path_skywalking/$images_name.tar";
  # 判断文件是否存在
  fun_check_file  $file_source_skywalking
  
  if [ $? -eq 1 ] ; then
  error "缺少$file_source_skywalking镜像文件"
  return
  fi

  func_check_image "apache/skywalking-oap-server:latest"

  if [ $? -eq 1 ] ;then
    # 导入docker镜像
    docker load -i $file_source_skywalking
  fi

  # 判断是否已经存在容器
  func_check_container "apache/skywalking-oap-server:latest"

  if [ $? -eq 0 ] ;then
      error "容器apache/skywalking-oap-server:latest已安装，如需重新安装，请先卸载"  
      return
  fi

  # 运行容器
  docker run --name skywalking-oap-server --restart=always -d apache/skywalking-oap-server:latest

  images_name="skywalking-ui";

  fun_skywalking_ui_load 
}

# docker导入skywalking_ui镜像启动容器
fun_skywalking_ui_load(){
  file_source_skywalking_ui="$path_skywalking/$images_name.tar";
  # 判断文件是否存在
  fun_check_file  $file_source_skywalking_ui
  
  if [ $? -eq 1 ] ; then
  error "缺少$file_source_skywalking_ui镜像文件"
  return
  fi

  func_check_image "apache/skywalking-ui:latest"

  if [ $? -eq 1 ] ;then
    # 导入docker镜像
    docker load -i $file_source_skywalking_ui
  fi

  # 判断是否已经存在容器
  func_check_container "apache/skywalking-ui:latest"

  if [ $? -eq 0 ] ;then
      error "容器apache/skywalking-ui:latest已安装，如需重新安装，请先卸载"  
      return
  fi

  # 运行容器
  docker run --name skywalking_ui --restart=always -d -e SW_OAP_ADDRESS=skywalking-oap-server:12800 apache/skywalking-ui:latest
}