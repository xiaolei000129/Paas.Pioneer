#!/bin/bash
# 防止脚本转义
sed -i 's/\r$//' $path_current/helper.sh

sed -i 's/\r$//' $path_current/install-admin-core.sh

sed -i 's/\r$//' $path_current/install-hangfire.sh