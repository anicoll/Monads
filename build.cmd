dotnet restore
dotnet build ./src/Monads
dotnet build ./src/Monads.Test

dotnet test ./src/Monads.Test

dotnet pack  .\src\Monads -c Release -o ./