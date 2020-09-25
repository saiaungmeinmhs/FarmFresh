Github link
===================
http://

Instruction
===================
1) To run this project you need dotnet core 3.1 installed on you pc.
2) You can run on both Visual Studio Code or Visual Studio 2017 or later.
3) When project is ready.Please run the following migration cmd.

	dotnet cli => dotnet ef migrations add 'initialCreate'
	dotnet cli => dotnet ef database update

	(OR)

	PS => Add-Migration InitialCreate
	PS => Update-Database

API
===============
1) To test api I have used Swagger interface.
   You can go to https://localhost:5001/swagger.
2) You can also test from Postman.