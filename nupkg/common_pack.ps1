. ".\common.ps1"

# Delete all packages
foreach ($project in $projects) {

    $projectName = $project.Substring($project.LastIndexOf("\") + 1)

    $nupkgPath = ($projectName + "." + $version + ".nupkg")

    if (Test-Path -Path $nupkgPath) {
        Remove-Item -Recurse  $nupkgPath
    }
}

# Rebuild all solutions
foreach ($solution in $solutions) {
    $solutionFolder = Join-Path $rootFolder $solution
    if (Test-Path -Path $solutionFolder) {
        Set-Location $solutionFolder
        & dotnet restore
    }
}

# Create all packages
foreach ($project in $projects) {
    
    $projectFolder = Join-Path $rootFolder $project
	
    # Create nuget pack
    if (Test-Path -Path $projectFolder) {
        Set-Location $projectFolder
        & dotnet pack -c Release -p:PackageVersion=$version --output $packFolder
    }
}

# Go back to the pack folder
if (Test-Path -Path $packFolder) {
    Set-Location $packFolder
}