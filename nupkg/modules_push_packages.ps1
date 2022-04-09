. ".\modules.ps1"

$apiKey = "oy2hrtlanfp4lnmoratqj223hz5pucmevhy7k3hpjmrzii"

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
