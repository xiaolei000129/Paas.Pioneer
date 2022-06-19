. ".\modules.ps1"

$apiKey = "oy2kugu4zvcfwcdu34qargcz36y4pczu7prxuoisih4kdm"

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
