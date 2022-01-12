#!/bin/bash
# 时间：2022-01-11
# 创建人：段晨曦
# 自动部署脚本

path_current="$PWD"

source "$path_current/tools/deploy/helper.sh"

# 变量区
path_appsettings="/home/docker/paasPioneer/adminCore/appsettings"

# 初始化appsettings
fun_init_appsettings()
{
  # 创建配置文件
  mkdir -p $path_appsettings

  path_file_appsettings="$path_appsettings/appsettings.json" 

  cat <<EOT > ${path_file_appsettings}
  {
    "urls": "http://*:9099",
    "App": {
      "SelfUrl": "http://*:9099",
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

fun_check_file $path_appsettings
    
if [ $? -eq 1 ] ;then
  info "appsettings文件不存在，准备初始化appsettings文件"
	fun_init_appsettings
  success "appsettings文件创建成功,文件路径：$path_appsettings"
fi

# 启动项目
docker-compose up -d --build  --force-recreate

success "发布镜像成功，镜像Tag为lastest"

docker images|grep none|awk '{print $3}'|xargs docker rmi

success "删除所有为none的镜像"