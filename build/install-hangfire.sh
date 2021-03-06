#!/bin/bash
# 时间：2022-01-11
# 创建人：段晨曦
# 自动部署脚本

path_current="$PWD"

source "$path_current/helper.sh"

# 变量区
path_appsettings="/home/docker/paasPioneer/paasPioneerHangfire/appsettings"

path_file_appsettings="$path_appsettings/appsettings.json"

# 初始化appsettings
fun_init_appsettings()
{
  # 创建配置文件
  mkdir -p $path_appsettings

  # 创建文件
  touch $path_file_appsettings

  cat <<EOT > ${path_file_appsettings}
  {
    "urls": "http://*:9202",
    "App": {
      "SelfUrl": "http://*:9202",
      "CorsOrigins": "http://localhost:9000/,http://119.91.225.37/",
      "RedirectAllowedUrls": "http://localhost:4200,https://localhost:44307"
    },
    "ConnectionStrings": {
      "Default": "Server=127.0.0.1;Port=3306;Database=Paas.Pioneer;Uid=root;Pwd=123456;",
      "Redis": "127.0.0.1:6379,password=Paas.Pioneer,connectTimeout=3000,connectRetry=1,syncTimeout=10000,DefaultDatabase=10"
    },
    "AuthServer": {
      "Authority": "https://localhost:44338",
      "RequireHttpsMetadata": "false",
      "SwaggerClientId": "Admins_Swagger",
      "SwaggerClientSecret": "1q2w3e*"
    },
    "StringEncryption": {
      "DefaultPassPhrase": "WqI6YyLOMuD4GT67"
    }
  }
EOT

}

fun_check_file $path_file_appsettings
    
if [ $? -eq 1 ] ;then
  info "appsettings文件不存在，准备初始化appsettings文件"
	fun_init_appsettings
  success "appsettings文件创建成功,文件路径：$path_file_appsettings"
fi

# 启动项目
docker-compose -f docker-compose-hangfire.yml  up -d --build  --force-recreate

success "paasPioneerHangfire发布镜像成功，镜像Tag为lastest"