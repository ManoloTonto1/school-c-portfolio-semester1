FILE=sqlitedb.db
rm 
if test -f "$FILE"; then
    rm $FILE 
fi
dotnet ef migrations add test2
dotnet ef database update 
dotnet run