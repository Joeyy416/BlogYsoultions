# BlogYsoultions

Used Technology:
  •	EF 4
  •	MVC 5 
  •	Bootstrap 4
  •	SQL Server 2014
  •	Visual basic 2015
  •	JWT for authentication 


Steps For building Project
1.	Download project 
  •	Using “Download as .zip” then extract
  •	Using Git: git clone https://github.com/Joeyy416/BlogYsoultions.git
2.	Open using Visual studio
3.	Set the connection with database: In web.config file, in <connections strings>
  •	In connectionString,
    i.	Replace “[DATA SOURCE]” to your SQL server name
    ii.	Replace “[INITIAL CATALOG]” to your desired Database name 
    iii.	For sql server authentication 
        •	leave [INTEGRATED SECURITY] to “SSPI” or “true” for windows authentication (preferred)
        •	Delete “Integrated security” field, and add “User Id=user;Password=pwd”, where “user” and “pwd” are the user authentication credentials for the SQL server  
4.	Build solution
5.	Run “update database” command via package Manager (restart VS if there’s an error in running the command)
6.	Run the project and use one of the following credentials:
  •	For admin:
    i.	 UserName:Hazem/password:admin
    ii.	username :Hatem/password:admin
  •	for moderator:
    i.	UserName:Ali/password:moderator   
    ii.	UserName:Alia/password:moderator
  •	For visitor:
    i.	UserName:Farid/password:visitor
    ii.	UserName:Farida/password:visitor
