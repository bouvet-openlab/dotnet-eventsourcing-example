#Sponsor Portal
##A DDD, CQRS and Event Sourcing example implementation

#### Prerequisites
* Node Package Manager (npm). Install nodejs from http://nodejs.org/ and make sure npm is on your PATH.

#### How to run
* git clone https://github.com/bouvet-openlab/dotnet-eventsourcing-example.git
* In the project dir: npm install (installs grunt (http://gruntjs.com/) and packages required by grunt)
* In the project dir: grunt build-full (restores nuget, builds, starts event store, runs all tests)

*Optional*   

* In the project dir: bower install  


#### Case
This is an example implementation of the concepts Domain Driven Design (DDD), Command Query Responsibility Segregation (CQRS) and Event Sourcing (ES). 

The solution is called SponsorPortal and is modeled (and somewhat simplified) on an existing system (which is neither DDD, CQRS or ES). 

SponsorPortal is a management system for handling requests for sponsorships. A user (any person, organization or group) can submit an application form which is then registered and processed by a clerk in the managment portion of the system. An application can be Granted or Rejected. In both cases an e-mail is sent to the applicant letting them know of the decision. In order for an application to be Granted it must be tied to an Account which must have enough money left on it to pay for the amount granted.

*More info coming...*

#### Concepts
* Domain Driven Design
* Command Query Responsibility Segregation
* Event Sourcing

#### Frameworks
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

#### Components

*TBA*

#### Known issues:
1. Helios (Owin-IIS) on IIS Express may return http 500 internal server error saying the configuration is invalid. To fix, run the ClearIISExpressCache script located in the Scripts folder. This is an alpha-release related issue (I hope).