Vendor Machine
==============
BackEnd Technnologies
---------------------
C# (dotnet 6) - DDD Approach with SOLID principles applyed

Entity Framework Sql Server - Code first approach (Initial values being seed in the db migrations script) - Check folder : InitialData inside Data Project
	Overriding save changes to save automatically the field createdOn

CORS Configuration (Accept calls from Angular Project)

Swagger

MVVM pattern - Using AutoMapper

Repository Pattern with UOW (UOW unnecessary here since the machine can only be used by one person at time, however its important to avoid concurrent operations on DB)

MediatR Setup

Fluent Assert Validation Pattern

Back End Notes:
1 - Normally I do like to create another layer called "AppService" in order to provide/manipulate informations for specific projects, In our case we have only the WebApi using the 
others layers, that is why it was not necessary here;
2 - Relationship between entities/tables Sales and Product should be N -> N, generating one new table ProductSales in the midle (keep it like this to simplify);
3 - The database should have more 2 tables in order to controll the currencies (list of), and what currencies are accepeted in each machine (table currency_machine for example);
4 - To make it simple I kept all the endpoint in the same controller (It requires basically all the services to be injected in the same controller wich is not good);
5 - the starting point of angular project is get the machine by id (hardcoded because we know there is only one);


Tests XUnit
------------
Coverlet with Report Generator

Entity framework In Memory tests

Test Server

[Go to Test Report](https://support.west-wind.com)

Steps to Run
------------
** Front End Project **
* npm install; 
* npm install -g @angular/cli@11.2.2



DataBase Diagram 
----------------
![alt text](DbDiagram.jpg)

Front End Technnologies
------------------------
Angular 11 - standard application (Only with bootstrap for simplicity)

Reactive Forms

Front End Notes:
1 - For Simplicity the model classes were not reproduced in Angular Project (Thats why on the services layer the observables are dealing with "any" types);


Improvements (Suggestion)
-------------------------
1 - Presuming the machine should be connected and not standalone, we should create some mechanism to update data in real time (SignalR for example);
2 - Network trafic should be protected by HTTPS tunnel and another authorization such as JWT might have been configured in our API/UI.
