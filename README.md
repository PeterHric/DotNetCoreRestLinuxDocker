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
Create a new directory and enter it. Clone the application code:  
__*git clone https://github.com/PeterHric/DotNetCoreRestLinuxDocker*__

Enter the created directory:  
__*cd DotNetCoreRestLinuxDocker*__

(You can try to run the application: *dotnet run*)
Publish the app in release mode locally:  
__*dotnet publish -c Release*__

-----------------
Dockerize the app
-----------------
Build a DOCKER image from the app:
(You can examine the Dockerfile that contains instructions for Docker on how to build the image.):  
__*docker build -t your_preffered_image_name -f Dockerfile .*__

Check if you can see the new created image:  
__*docker images*__

---------------------
Run the app in Docker
---------------------
Run a new container based on new created image (in this case docker will assing the new container a random name):  
__*docker run -p 8080:80 your_preffered_image_name*__

Alternatively, you can run in on the background as a daemon: 
__*docker run -d -p 8080:80 your_preffered_image_name*__

You may select the container an arbitrary name (lowercase): 
__*docker run -d -p 8080:80 --name=container_name  your_preffered_image_name*__

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
