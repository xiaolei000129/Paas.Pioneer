# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    "modules\AdminCore\src\Paas.Pioneer.Admin.Core.HttpApi.Host"
)

# List of projects
$projects = (

    # framework
    "framework\src\Paas.Pioneer.Domain",
    "framework\src\Paas.Pioneer.Domain.Shared",
    "framework\src\Paas.Pioneer.Knife4jUI.Swagger",
    "framework\src\Paas.Pioneer.Middleware",
    "framework\src\Paas.Pioneer.Redis",
    "framework\src\Paas.Pioneer.AutoWrapper"
)

# Get the version
[xml]$commonPropsXml = Get-Content (Join-Path $rootFolder "/build/common.props")
$version = $commonPropsXml.Project.PropertyGroup.Version
