dotnet restore
dotnet build ./src/Monads
dotnet build ./src/Monads.Test

dotnet test ./src/Monads.Test

dotnet pack -c Release -o ./