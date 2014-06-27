### Bounded contexts

* Application Entry
* Application Management
* Account Management
* Clerk Management

### Aggregates

* Application form

<br/>
### Solution structure #3
---
##### Application Entry [solution folder]
* ApplicationEntry [web project] 

##### Application Management [solution folder]
* ApplicationManagement.Web [web project]
* ApplicationManagement.Core [project]
	* Contracts [folder]
		* [interfaces]
	* Commands [folder]
		* [commands]
	* Events [folder]
		* [events]
	* CommandModel [folder]
		* ApplicationFormAggregate [folder] 
			* [entities]
		* [value objects]
	* QueryModel [folder]
		* [value objects]
	* Services [folder]
		* [services]
	* Projections [folder]
		* [projections]

##### Persistance [solution folder]
* EventRepository [project]
* Repositories [project]
	* Contracts [folder]
		* [interfaces]
	* [repositories]


##### Common [solution folder]
* Infrastructure [project]
* Helpers [project]

##### Account Management
##### Clerk Management 

<br/>
### Solution structure #1
---
##### Application Entry [solution folder]
* ApplicationEntry [web project] 

##### Application Management [solution folder]
* ApplicationManagement [web project]
* ApplicationForm.Command [project]
	* Contracts [folder]
		* [interfaces]
	* Commands [folder]
		* [commands]
	* Model [folder]
		* [entities]
		* [value objects]
	* ApplicationFormRepository
	* ApplicationFormService
* ApplicationForm.Query [project]
	* Model [folder]
		* [entities]
		* [value objects]
	* ApplicationFormProjection
* ApplicationForm.Common [project]
	* Model [folder]
		* [value objects]
	* Events [folder]
		* [events]


##### Persistance [solution folder]
* EventPersistance [project]

##### Common [solution folder]
* Infrastructure [project]
* Helpers [project]

##### Account Management
##### Clerk Management

<br/>
### Solution structure #2
---
##### Application Entry [solution folder]
* ApplicationEntry [web project] 

##### Application Management [solution folder]
* ApplicationManagement [web project]
* ApplicationForm [project]
	* Contracts [folder]
		* [interfaces]
	* Commands [folder]
		* [commands]
	* Events [folder]
		* [events]
	* CommandModel [folder]
		* [entities]
		* [value objects]
	* QueryModel [folder]
		* [entities]
		* [value objects]
	* ApplicationFormRepository
	* ApplicationFormService
	* ApplicationFormProjection

##### Persistance [solution folder]
* EventPersistance [project]

##### Common [solution folder]
* Infrastructure [project]
* Helpers [project]

##### Account Management
##### Clerk Management 