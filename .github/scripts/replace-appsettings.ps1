param (
    [Parameter(Mandatory=$true)]
    [string]$Path,
    [string]$BrowserType,
    [bool]$Headless,
    [string]$DownloadDirectory
)

$jsonContent = Get-Content $Path -Raw | ConvertFrom-Json

$jsonContent.AppSettings.BrowserType = "$BrowserType"
$jsonContent.AppSettings.Headless = $Headless
$jsonContent.AppSettings.DownloadDirectory = "$DownloadDirectory"

$jsonString = $jsonContent | ConvertTo-Json -Depth 10

Set-Content $Path -Value $jsonString
