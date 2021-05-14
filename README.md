## quickstart
Проект, реализующий работу косольного клиента с webapi. Webapi в свою очередь работает в связке с IdentityServer4. Также в проект включен reverse-proxy nginx

## Отладка 

Auth: https://localhost/is4
Api: https://localhost/api

## Заметки
Для корректной работы с https в конейтнерах docker в Rider,
нужно сгенерировать сертификаты для разработки на каждый проект. Для этого нужно выполняить следующие команды:

- добавить секрет с паролем от сертификата(выполнять из папки проекта для которого делаем сертификат):
  ```
  dotnet user-secrets set "Kestrel:Certificates:Development:Password" "yourpassword"
  ```
- создать сам сертификат с указанным ранее паролем:
  ```
  dotnet dev-certs https -ep %USERPROFILE%\AppData\Roaming\ASP.NET\Https\backend.pfx -p password
  ```
- добавить сертификаты для разработки в доверенные:
  ```
  dotnet dev-certs https --trust
  ```
- добавить монтирование папок с сертификатом и секретом в контейнер
  ```
  volumes: 
  - ${APPDATA}/Microsoft/UserSecrets/:/root/.microsoft/usersecrets
  - ${APPDATA}/ASP.NET/Https:/root/.aspnet/https:ro
  ```



