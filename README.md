# How to build and deploy this (C# ASP.NET) app in docker on Linux (ubuntu 18.04 tested) environment

Prerequisites:
- Have installed .NET Core 3.1 for Linux [1]
  '*dotnet --info*' will determine which verstion is instaled
- Have installed Docker for Linux [2]

[1] https://dotnet.microsoft.com/download
[2] https://www.docker.com/products/docker-desktop

-------------
Build the app
-------------
... To do ....

-----------------
Dockerize the app
-----------------
... To do ....

---------------------
Run the app in Docker
---------------------
... To do ....

------------
Test the app
------------

Try to put to the web browser:
http://localhost:8080/WeatherForecast
You should get a randomized weather forecast

Try to post a request using the Postman tool:

Method: POST
URL: http://localhost:8080/api/RestItems/
Request BODY:
Format: raw
Type: JSON
BODY content:
{
  "name":"Item 1",
  "isComplete":false
}

You should get a response like this:
*{
    "id": 1,
    "name": "Item 1",
    "isComplete": false
}*

----------------
Read your entry:
Method: GET
URL: http://localhost:8080/api/RestItems/1
Request BODY:  None (anything you enter will be ignored with GET method)

Expected raw response body:
*{"id":1,"name":"Item 1","isComplete":false}*

----------------
Delete your entry:
Method: DELETE
URL: http://localhost:8080/api/RestItems/1
Request BODY:  None (anything you enter will be ignored with DELETE method)

Expected response body:
*{"id":1,"name":"Item 1","isComplete":false}*
