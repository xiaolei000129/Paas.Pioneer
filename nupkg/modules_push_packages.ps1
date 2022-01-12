. ".\modules.ps1"

$apiKey = "oy2lbjb7zj7sgzrrhl4ary7g3tvdbr6elhl4lg7cb4s6wi"

# Publish all packages
foreach ($project in $projects) {
    $projectName = $project.Substring($project.LastIndexOf("\") + 1)
    $nupkgPath = ($projectName + "." + $version + ".nupkg")
    if (Test-Path -Path $nupkgPath) {
        & dotnet nuget push ($projectName + "." + $version + ".nupkg") -s https://api.nuget.org/v3/index.json --api-key "$apiKey"
    }
}

# Go back to the pack folder
if (Test-Path -Path $packFolder) {
    Set-Location $packFolder
}
