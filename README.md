# EmailService
Web-cервис, задача которого формировать и отправлять письма адресатам и логировать результат в БД <br>
## POST
1. Сервис принимает POST запрос по `url:/api/mails/` Тело запроса в формате json. <br>
**Модель запроса:**
```json
{
    "subject":"string",
    "body": "string",
    "recipients":["string1@gmail.com", "string1@gmail.com"]
}
```
В результате обработки формируется email сообщение, и отправляется указанным адресатам. <br>
В БД добавляется запись всех полей, дата создания, результат отправки (значения "OK" "Failed") и поле FailedMessage (пустое или содержит ошибку отсылки уведомления) <br>
_В корне сборки добавлен образец файла конфигурации SMTP сервера <br>(необходимо поместить файл с заполненными данными в .. \EmailService\EmailServiceWebApi\bin\Debug\netcoreapp3.1)_ <br>
## GET
2. Сервис так-же отвечает на GET запрос по `url:/api/mails/` выводом списка всех отправленных сообщений в формате json <br>
**Вид ответа:**
```json
[
{
    "subject": "string",
    "body": "string",
    "recipients": [
        "string1@gmail.com",
        "string2@gmail.com"
    ],
    "date": "2022-10-07T16:07:44.9414625",
    "result": "OK",
    "failedMessage": null
}, ...
]
```
----
- ASP.NET Core Api
- СУБД - MS SQL
- Entity Framework (добавлены миграции) 

