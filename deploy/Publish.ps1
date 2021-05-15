$PublishPath = "..\publish"

If (Test-Path $PublishPath) {
	Remove-Item ..\publish -Recurse -Force
}
dotnet publish ..\AmongUsRoleSelector\AmongUsRoleSelector.csproj --configuration Release --output ..\publish
azcopy sync "..\publish\wwwroot" "https://amongus.blob.core.windows.net/`$web" --put-md5 --delete-destination=true --recursive=true

Unpublish-AzCdnEndpointContent -EndpointName  "amongus"  -ProfileName  "amongus"  -ResourceGroupName  "amongus"  -PurgeContent  @( "/*" )  -Force