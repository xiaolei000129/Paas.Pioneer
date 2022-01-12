<h1 align="center">Paas.Pioneer</h1>
<h3 align="center">一个基于 ABP 多租户中后台前端解决方案，提供更多通用性业务模块，让开发者更加专注于业务。</h3>
<div align="center">

[![star](https://gitee.com/chenxi-team/paas-pioneer/badge/star.svg?theme=dark)](https://gitee.com/chenxi-team/paas-pioneer/stargazers)
[![fork](https://gitee.com/chenxi-team/paas-pioneer/badge/fork.svg?theme=dark)](https://gitee.com/chenxi-team/paas-pioneer/members)
[![](https://img.shields.io/badge/QQ群-812722325-red)](https://jq.qq.com/?_wv=1027&k=5eRxySKd)

    如果对您有帮助，点击右上角⭐Star⭐关注 ，感谢支持开源！
</div>

### 🌱Paas.Pioneer简介
> Paas.Pioneer源于我们平常的开发需求，将通用性业务进行模块化。将通用需求进行拼装，让开发者更加专注于业务。
    
Paas.Pioneer使用ABP框架作为基础架构，通过业务划分模块，将模块比做积木，我们通过不同的积木组装我们想要的房子🏠车子🚗，
如您在框架的使用过程中遇到问题可以加入[Paas.Pioneer讨论群](https://jq.qq.com/?_wv=1027&k=5eRxySKd)共同探讨技术。

### 🍀项目介绍
- 基于.NET 6、ABP 5实现的后台解决方案，模块插件化，前后端分离，支持分布式部署，跨平台运行。
- 前端基于[element](https://element.eleme.cn/#/zh-CN)实现了AdminCore管理系统。
- 持久层使用EF Core、实现多租户、Redis缓存、Jwt实现鉴权、Scriban实现低代码模块、hangfire实现后台任务。
- 核心模块包括：用户管理、角色管理、权限管理、人事管理、菜单管理、字典管理、日志管理、低代码管理、定时任务等功能。

### 🌴功能介绍
- 人事管理：公司组织架构维护，支持多层级结构的树形结构。
- 用户管理：公司系统管理员维护、可以绑定用户角色。
- 角色管理：公司组织架构角色划分，并且设置权限信息。
- 接口管理：统一管理后端提供接口，进行后端接口可视化，并且进行后端接口颗粒权限管理。
- 视图管理：统一管理前端页面，进行前端接口可视化管理。
- 权限管理：通过视图、接口数据支持、显示权限管理。
- 缓存管理：通过枚举方式呈现平台的Redis缓存管理。
- 租户管理：平台对于租户进行权限分配。
- 字典管理：系统内各种枚举类型、常量类型的维护。
- 个人管理：用户个性化的维护自己的个人信息。
- 文档管理：进行平台文档存档，支持Markdown格式、已经文档图片存储。
- 低代码管理： 新建对于实体之后，设置字段显示方式和添加方式，生成对应前后端代码。
- 角色权限管理：结合权限管理数据为每一个角色分配对于权限。

### 🌵效果图

<table>
    <tr>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/1.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/2.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/3.png"/></td>
    </tr>
    <tr>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/4.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/5.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/6.png"/></td>
    </tr>
    <tr>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/7.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/8.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/9.png"/></td>
    </tr>
    <tr>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/10.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/11.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/12.png"/></td>
    </tr>
    <tr>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/13.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/14.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/15.png"/></td>
    </tr>
    <tr>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/16.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/17.png"/></td>
        <td><img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/18.png"/></td>
    </tr>
</table>

### 🌲项目分层
**paas.pioneer文件夹分层**
```
├─build                      ->项目构建文件夹。
├─docs                       ->文档文件夹。
├─framework                  ->核心类库项目。
├─modules                    ->模块化文件夹
├─nupkg                      ->nuget包构建和发布文件夹
├─templates                  ->模板项目文件夹
├─tools                      ->工具文件夹
```
<img src="https://chenxi-team.gitee.io/paas-pioneer/imgs/19.png"/>

**paas.pioneer项目分层**
```
├─Paas.Pioneer.Template.Application             ->该项目包含项目中定义的接口的应用服务。
├─Paas.Pioneer.Template.Application.Contracts   ->本项目主要包含应用层的应用服务 接口和数据传输对象（DTO）。
├─Paas.Pioneer.Template.DbMigrator              ->这是一个控制台应用程序，可简化在开发和生产环境中执行数据库迁移。
├─Paas.Pioneer.Template.Domain                  ->这是解决方案的领域层。它主要包含实体、聚合根、域服务、值对象、存储库接口和其他域对象。
├─Paas.Pioneer.Template.Domain.Shared           ->该项目包含常量、枚举和其他对象，但需要由解决方案中的所有层/项目使用。
├─Paas.Pioneer.Template.EntityFrameworkCore     ->这是 EF Core 的集成项目。它定义DbContext并实现了.Domain项目中定义的存储库接口。
├─Paas.Pioneer.Template.HttpApi                 ->该项目用于定义您的 API 控制器。
├─Paas.Pioneer.Template.HttpApi.Client          ->这是一个定义 C# 客户端代理以使用解决方案的 HTTP API 的项目。
├─Paas.Pioneer.Template.HttpApi.Host            ->如果您使用的是 ASP.NET Core MVC UI，则此项目包含应用程序的用户界面 (UI)。
```
### 🥦模块化
> 我们沿用了ABP的思路进模块化，在modules文件夹存放模块项目，模块项目通过Nuget包方式管理，同时通过Nuget引用达到聚合。

- 更新模板&安装
    - dotnet new --update-apply || dotnet new --install Paas.Pioneer.Template
- 使用Paas.Pioneer.Template脚手架创建项目
    - dotnet new Paas.Pioneer.Template -n 项目名称<br/>
    示例：
    - dotnet new Paas.Pioneer.Template -n User(生成的项目名称 Paas.Pioneer.User)

这样您就创建了一个项目，我们只需要编写模块的业务。

### 🌻近期计划
- [x] 权限管理
- [x] 文档管理
- [x] 字典管理
- [x] 代码生成器
- [x] 定时任务
- [ ] 资讯模块
- [ ] 用户模块
- [ ] 订单模块
- [ ] 支付集成
- [ ] 事件模式
- [ ] 集成微信开发
- [ ] 邮件发送
- [ ] 短信发送
- [ ] 前端模块可视化创建

### 🌾演示站点
- 平台用户：[演示站点](http://119.91.225.37/)
    - 用户名：admin，密码：123456
- 租户： 
    - 租户1管理员（用户名：morning 密码：123456）
    - 租户1普通用户（用户名：17674705062 密码：123456）

### 🥗开发环境
- Visual Studio 2022
- .NET 6 SDK +
- VS Code
- Redis

### 💐贡献代码

- 欢迎提交 pull request，注意提交至 dev 分支
- 欢迎提交 issue，请写清楚遇到问题的原因、开发环境、复显步骤以及期望达到的效果。

### 🥂特别鸣谢
- [ABP](https://www.abp.io/)
- [element](https://element.eleme.cn/#/zh-CN)
- [Admin.Core](https://gitee.com/zhontai/Admin.Core)

如果对您有帮助，点击右上角⭐Star⭐关注 ，感谢支持开源！