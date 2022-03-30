# REST Demo
This project is develop in Visual studio 2022 and with .NET 6.0 version.

This is mainly used as answer to an coding test with nrgi company. 

(Yes, I am aware that I made an spelling mistake on NGRI instead of NRGI. Sadly I found out after I have finished develop in the project.)

The Project is made in two parts:

App
- Web api project

Library
- class library which contains the DBContext, Interfaces, Models, and Services that is required in web api.

SQLite database that is located in C:\Users\[username]\AppData\Local. This will be created during runtime if not existing.

Worth note that I have also add an extra part into the project in another branch named "AddFrontEnd" which contain an blazor project.
However the branch is just used to make it easier to interact with the rest api and isn't required in the task that I recived from the coding test.

The "AddFrontEnd" branch probably contains the fixs on some bugs that I ran into during making the blazor project. 
I am a little bit lazy to move all the fixes into master, but I could do an pull request to solve this.

# User manual:

* boot the rest server up.

* View the apis in swagger.

* use postman or something similar to call the apis.

# Image of software:
![image](https://user-images.githubusercontent.com/9974608/160822499-0a298ce1-b326-4310-ac09-30a120e37e20.png) Rest api on master

![image](https://user-images.githubusercontent.com/9974608/160822944-cbf3ca31-b8fe-4ce4-839b-02caee3e2853.png) Rest api on AddFrontEnd

![image](https://user-images.githubusercontent.com/9974608/160823118-4f81b6fc-2d70-4a92-855d-2db55c98e27c.png) Blazor project on AddFrontEnd


Credit: Djinnet
