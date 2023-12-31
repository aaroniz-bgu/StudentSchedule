# Design the services
### Author: *[aaroniz-bgu](https://github.com/aaroniz-bgu)*

Service-pattern had a slight decline in popularity as of writing this (2023/09), I personally think that the service has been proven to be a excellent. However, when diving deep into structuring the services one may encounter difficulties and need to make decisions which seem either to break the pattern/SRP (Single Responsibility Principle) or overcomplicate the system codebase overall.

What are main difficulties you may ask. As application grows more and more service may become depended on each other. E.g. suppose `ProductService` and `OrderService`, when adding `Product`s to an `Order` we need to retrieve data of `Product`s, but how do we do it? do we call the appropriate `ProductService` functions? do we hold a `ProductRepository` inside out `OrderService`? Now as in anything in software engineering it **depends**.

Let's dive deeper to this design choice. With EF Core we have the amazing `DbContext` object, in smaller-medium apps it is common to see usage of the same context across the app. `DbContext` is a representation of [repository and UoW(unit of work)](https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext?view=entity-framework-6.2.0#definition), it holds all the specific 'repositories' our app needs. Each service is dependent on `DbContext` which doesn't damage the cohesion overall and much needed (Why not to use Repository pattern to wrap the context is a matter for another day). Since `DbContext` holds all the needed repositories for our app we can access them when needed for other entities, yes seems as we're breaking the pattern, but injecting other services would overcomplicate the code so much that the tradeoff worth it. [See this StackOverflow answer to this](https://stackoverflow.com/questions/56667351/communications-between-entities-through-service-layer). It is important to note that this does not solve many other difficulties that may arise when designing the services, such as data validation of entities. 

This post summarizes some design choices regarding the services that are realized in this repository.

[comment]: <> (TODO Grammar check, word choices etc.)
[comment]: <> (TODO Talk about Gatherer)