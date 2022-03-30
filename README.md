Vendor Machine
==============
BackEnd Technnologies
------------
C# (dotnet 6) - DDD Approach with SOLID principles applyed

Entity Framework Sql Server - Code first approach (Initial values being seed in the db migrations script) - Check folder : InitialData inside Data Project
	Overriding save changes to save automatically the field createdOn

CORS Configuration (Accept calls from Angular Project)

Swagger

MVVM pattern - Using AutoMapper

Repository Pattern with UOW (UOW unnecessary here since the machine can only be used by one person at time, however its important to avoid concurrent operations on DB)

MediatR Setup

Back End Notes:
1 - Normally I do like to create another layer called "AppService" in order to provide/manipulate informations for specific projects, In our case we have only the WebApi using the 
others layers, that is why it was not necessary here.
2 - Relationship between entities/tables Sales and Product should be N -> N, generating one new table ProductSales in the midle (keep it like this to simplify)

Steps to Run
------------

DataBase Diagram 
------------
![alt text](http://url/to/img.png)