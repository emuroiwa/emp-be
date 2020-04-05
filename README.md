# emp-be
Employee backend API

## Table of Contents
- How i made it(#blog)
- [Technology](#technology)
- [Database](#database)
- [Setup](#setup)
- [API Endpoints](#apiendpoints)

## How i made it <a id="blog">
http://www.ernestmuroiwa.com/crud-spa-asp-net-web-api-and-angular/

## Technology <a id="technology">
This uses the following technology...

- C#
- ASP.NET Web API
- Entity Framework 6 (using Database first approach)

## Database <a id="database">
Developed against sql server express 2017

Connection string can be found [here](https://github.com/emuroiwa/emp-be/blob/master/emp-be/Web.config "Web.Config file")


## API endpoints <a id="apiendpoints">
Replace placeholder `{}` with actual value

#### Get all employees

`http://localhost:{port}/api/employees`


#### Post new book

`http://localhost:{port}/api/employees`


#### Patch title of existing book using book id

`http://localhost:{port}/api/employees/{id}`
