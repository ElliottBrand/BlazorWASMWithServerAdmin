# Blazor WebAssembly app with a Blazor Server-Side Admin Area
This is a very simple example of a Blazor WebAssembly app that's setup with a Blazor Server-Side admin area. I wasn't focused on architecture or best practices, but rather just focused on showing it was possible to setup Identity to work with both a Blazor WebAssembly app and Blazor Server-Side app in the same project.

If you download and run the app to try it out, it will attempt to setup the database to your MSSQL Local Db and install some sample data automatically when you first run it. The connection string it uses can be found in the root appsettings.json file.

The default user login credentials are:
* Email: admin@blazor.net *(This is fake, don't attempt to send email to it)*
* Password: Password123!
