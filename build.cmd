echo Building the project...
dotnet restore
dotnet build

cd test\1.Presentation\Admin.Tests
dotnet test
cd ..\..\4.DataAccess.Tests
dotnet test

echo Build done!