#Sponsor Portal
##A DDD, CQRS and Eventsourcing example implementation

####Case####
Placeholder

####Concepts####
* Domain Driven Design
* Command Query Responsibility Segregation
* Event Sourcing

####Frameworks####
Frontend

* AngularJS
* Bootstrap

Backend  
  
* OWIN  
* Katana  
* Helios (IIS' OWIN implementation)  
* ASP.NET WebAPI
* NEventStore  
* Unity

Thirdparty

* Bower
* GruntJS

####Components####
* Web components  
  * Public website (the application form)  
    http://localhost:8100/sponsorportal
     
  * Management website (for managing applications)  
    http://localhost:8200/sponsorportal

  * Query API  
    http://localhost:8300/sponsorportal

  * Command API  
    http://localhost:8400/sponsorportal

* Aggregate roots
  * Application Form

####Known issues:####
1. Helios (Owin-IIS) on IIS Express may return http 500 internal server error saying the configuration is invalid. To fix, run the ClearIISExpressCache script located in the Scripts folder. This is an alpha-release related issue (I hope).