# !/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# docker导入MySql镜像启动容器

path_mysql="$path_current/component/images/environment";

images_name="mysql";

conf_name="my.cnf";

# 容器挂载目录
path_mysql_mount="/home/docker/$images_name"

# 配置挂载目录
path_mysql_conf="$path_mysql_mount/confg"

# 数据挂载目录
path_mysql_data="$path_mysql_mount/data"

# 配置文件
file_mysql_conf="$path_mysql_conf/$conf_name";

# docker导入MySql镜像启动容器
fun_mysql_load(){
  file_source_mysql="$path_mysql/$images_name.tar"
  # 判断文件是否存在
  fun_check_file  $file_source_mysql
  
  if [ $? -eq 1 ] ; then
  error "缺少$file_source_mysql镜像文件"
  return
  fi

  func_check_image "mysql:latest"

  if [ $? -eq 1 ] ;then
    # 导入docker镜像
    docker load -i $file_source_mysql
  fi

  # 判断是否已经存在容器
  func_check_container "mysql:latest"

  if [ $? -eq 0 ] ;then
      error "容器mysql:latest已安装，如需重新安装，请先卸载"  
      return
  fi

  # 创建redis挂在目录
  fun_create_path $path_mysql_conf

  # 创建redis挂在目录
  fun_create_path $path_mysql_data

  # 复制配置文件进行挂载
  sudo cp "$path_mysql/$images_name/$conf_name" $file_mysql_conf

  # 运行容器
  docker run --name mysql -p 3306:3306 -v $file_mysql_conf:/etc/mysql/mysql.conf.d/mysqld.cnf -v $path_mysql_data:/var/lib/mysql --restart=always -e MYSQL_ROOT_PASSWORD=root -d mysql:latest --character-set-server=utf8mb4 --collation-server=utf8mb4_unicode_ci --lower_case_table_names=1
}
