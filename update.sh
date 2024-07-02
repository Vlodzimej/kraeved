git pull update
sudo systemctl stop kraeved.service
sudo dotnet publish kraeved.csproj -o /var/www/kraeved
sudo systemctl start kraeved.service
