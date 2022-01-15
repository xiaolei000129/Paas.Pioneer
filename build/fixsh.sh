#!/bin/bash
# 防止脚本转义
sed -i 's/\r$//' helper.sh

sed -i 's/\r$//' install-admin-core.sh

sed -i 's/\r$//' install-hangfire.sh