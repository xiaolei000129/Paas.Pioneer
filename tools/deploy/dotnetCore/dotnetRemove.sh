# !/bin/bash
# 时间：2020-12-4
# 创建人：段晨曦
# dotnet卸载
fun_load_dotnet_remove(){
  echo -e "您确定卸载dotnet吗？ \n确定请输入：y、取消直接回车"
  read  -n 1 input

  if [[ $input == "y" ]] ;then

  ## 本地环境信息
  echo -e "\n--------------已安装dotnet运行时列表--------------"
  dotnet --list-runtimes
  echo "------------------------------------------------------"

  sudo rm -rf /usr/bin/shared/Microsoft.NETCore.App

  sudo rm -rf /usr/bin/shared/Microsoft.AspNetCore.All

  sudo rm -rf /usr/bin/shared/Microsoft.AspNetCore.App

  # 清空配置信息
  rm -rf /usr/bin/dotnet

  echo "dotnet运行时卸载成功"

  fi
}

