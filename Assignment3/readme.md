```shell
# install the element framework command
dotnet tool install --global dotnet-ef --version "6.0.10"

# create a new migration
dotnet ef migrations add [migration name]
dotnet ef migrations add InitialCreate # example

# apply to database
dotnet ef database update

# unapply last change
dotnet tool uninstall --global dotnet-ef


# revert
dotnet ef database update 0
```