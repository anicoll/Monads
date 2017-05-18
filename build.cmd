dotnet restore
dotnet build ./src/Monads.NetCore
dotnet build ./src/Monads.NetCore.Test

dotnet test ./src/Monads.NetCore.Test

dotnet pack  .\src\Monads.NetCore -c Release -o ./