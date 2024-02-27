# TestRegistration
## Перед запуском проекта убедитесь, что у вас установлен:
* .NET7
* Erlang runtime
* RabbitMQ
## Убедитесь, что на вашем Filewall нет запрета использовать SMTP-protocol
## Вставьте в файлы настройки приложения (appsettings.json и appsetting.Development.json) данные для отправки писем клиентам

# О приложении
### Были реализованы все требования (за исклюлчением каптчи, тк она реализована в старых web forms и не работает в новом ASP.NET Razor Pages или MVC)
## Endpoints:
* /register: POST
* /verify: POST
## UI был удален, тк каптча не работает с новыми версиями ASP.NET MVC. Для взаимодействия с сервером использовать Swagger, Postman, etc.
