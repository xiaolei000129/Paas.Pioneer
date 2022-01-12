# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    "modules\AdminCore\src\Paas.Pioneer.Admin.Core.HttpApi.Host"
)

# List of projects
$projects = (
    # templates
    "templates",
    "Paas.Pioneer.Template",

    # admin-core
    "modules\admin-core\src\Paas.Pioneer.Admin.Core.Application",
    "modules\admin-core\src\Paas.Pioneer.Admin.Core.Application.Contracts",
    "modules\admin-core\src\Paas.Pioneer.Admin.Core.Domain",
    "modules\admin-core\src\Paas.Pioneer.Admin.Core.Domain.Shared",
    "modules\admin-core\src\Paas.Pioneer.Admin.Core.EntityFrameworkCore",
    "modules\admin-core\src\Paas.Pioneer.Admin.Core.HttpApi",

    # Mission
    "modules\mission\src\Paas.Pioneer.Mission.Application",
    "modules\mission\src\Paas.Pioneer.Mission.Application.Contracts",
    "modules\mission\src\Paas.Pioneer.Mission.Domain",
    "modules\mission\src\Paas.Pioneer.Mission.Domain.Shared",
    "modules\mission\src\Paas.Pioneer.Mission.EntityFrameworkCore",
    "modules\mission\src\Paas.Pioneer.Mission.HttpApi",

    # User
    "modules\user\src\Paas.Pioneer.User.Application",
    "modules\user\src\Paas.Pioneer.User.Application.Contracts",
    "modules\user\src\Paas.Pioneer.User.Domain",
    "modules\user\src\Paas.Pioneer.User.Domain.Shared",
    "modules\user\src\Paas.Pioneer.User.EntityFrameworkCore",
    "modules\user\src\Paas.Pioneer.User.HttpApi"
)

# Get the version
[xml]$commonPropsXml = Get-Content (Join-Path $rootFolder "/build/common.props")
$version = $commonPropsXml.Project.PropertyGroup.Version
