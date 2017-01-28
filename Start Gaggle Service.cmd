CD D:\Project\Messenger\MessageService

SET VsDevCmd = %comspec% /k "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"

CALL %VsDevCmd% dotnet restore
CALL %VsDevCmd% dotnet build
CALL %VsDevCmd% dotnet publish -f netcoreapp1.0 -c release
CALL %VsDevCmd% dotnet run

PAUSE