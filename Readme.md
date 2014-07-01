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
* EventStore (www.geteventstore.com)  
* Unity

Thirdparty

* Bower
* GruntJS

####Components####
* Web components  
  * Application Entry  
    http://localhost:8100/sponsorportal
     
  * Management website (for managing applications)  
    http://localhost:8200/sponsorportal

####Known issues:####
1. Helios (Owin-IIS) on IIS Express may return http 500 internal server error saying the configuration is invalid. To fix, run the ClearIISExpressCache script located in the Scripts folder. This is an alpha-release related issue (I hope).