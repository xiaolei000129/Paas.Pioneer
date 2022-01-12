#!/bin/bash
# 时间：2021-03-30
# 创建人：段晨曦
# 定时监控主机Redis运行情况，如果主机运行正常备机Redis在1分钟后重启

func_timing_redis(){
# 获取主机redis运行情况
path_deploy=$(echo|telnet 192.168.69.207 6379)

# 判断是否正常
is_start=$([[ $path_deploy =~ "Escape character is '^]" ]] && echo "0")

# 获取是否需要重启
 if [ $is_start -eq 0 ] ;then
    cur_dateTime="`date +%Y-%m-%d,%H:%m:%s`"
	# 停止容器
	docker stop redis;
	sleep 60;
	docker start redis;
	echo "$cur_dateTime :重启成功"
    fi
}
func_timing_redis