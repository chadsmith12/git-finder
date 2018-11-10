# GitFinder

GitFinder is a simple fullstack GitHub User Search application written using .Net Core and Vue.js. This application will search for any user from the GitHub API and will give you some information from their public profile.

The main point of this application is to teach and learn .Net Core Web Api Development and Vue.Js. The application is missing a lot of things before being considered a complete application. Some features that could be added:
* More API Endpoints - Currently only features two simple API End Points
* OAuth Authentication
* More pages using Vue Router.

---
## Server
Server is written in .Net Core 2.2 Preview and shows an example of a simple web api. The server makes the request to the GitHub API using `HTTPClient`. The response from the GitHub API is then used to create a standard response.

### Sawgger
A Swagger UI is generated from the WebAPI to show the two api endpoints that are exposed and to allow for easy testing.

---
## Client
Client APP is a simple Vue.Js application. This application used to get started with Vue.Js The application has been broken into a few components and also shows child component talking to a parent component.