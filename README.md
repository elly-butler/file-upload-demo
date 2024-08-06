# file-upload-demo
A project to demo file uploads in C# and Angular. Uploaded files are stored in a database which tracks who 'owns' each file and information about each file, plus resized versions of each file for blazing fast downloads of just the exact size the client application needs.

This repository is meant to SHOW you how to implement file uploads in a C# API, called from a front-end application (such as an Angular app).

## Requirements

1. Install Visual Studio Community 2019 or a higher edition
2. Recommended, Install SQL Server Management Studio (to view your database)
3. Install .Net Core SDK 3.1.x (replace the x with the lastest version you can download, stay in the 3.1 line)

## Getting this repository running

1. REQUIRED, to compile or run migrations. Ensure global.json at the solution root references the version of .Net Core SDK you have installed.  
   You need something in the .Net Core 3.1 series (not 2.x or 5.x)
   5.x is not out at the time of this writing.  the code will very likely work as is, but may need some NuGet package updates and global.json updates.

2. REQUIRED, or files cannot be uploaded. Run the database migrations.  This will create a SQL Server Express (LocalDb) database called NexulDemo on your local machine. You must already have SQL Server Express installed. It should come with Visual Studio 2019 (any edition)
   If you are on a Mac, you'll need to create a docker container to host SQL Server, or swap it out for another SQL brand database.

3. REQUIRED, or login fails. Create an OAuth application at Microsoft
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/microsoft-logins?view=aspnetcore-3.1

4. REQUIRED, or login fails. Update the appsettings.Development.json with your Microsoft application keys. Update this:

````
    "MicrosoftAuthSettings": {
      "ApplicationId": "00000000-aaaa-0000-0000-0123456789012",
      "Password": "1234567890qazwsxedcrfv"
    },
````

5. Optional to function, but HIGHLY recommended for security. Update the appsettings.Development.json with a new Tokens key.

6. Optional to function, but HIGHLY recommended for security, Update Startup.cs SecretKey constant to a different 32 character private key.
  private const string SecretKey = "12345678901234567890123456789012";
  
7. Optional, for your brand, Update appsettings.Development.json, anything that has "nexul" in its value to whatever you want them to be.
 
dante is a good dog