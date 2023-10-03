# Services
### Authour aaroniz-bgu@github

This post is part of a series of posts about the StudentSchedule.API project from a developer perspective.

<p>
These days I've seen a decline in popularity online of the service pattern for the service layer.
As I see this, this decline is a result of the complexity comes in a big project with many services and entities.
Where ocassionally different services need to communicate with each other, and the developer needs to decide how to do it.
Since a new network of dependencies is being formed it becomes a messy situation which is hard to maintain and track.
A good solution for this which does gain popularity online is <a href="https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs">CQRS</a>.
</p>

<p>
After all, this project does use the service pattern for the service layer. And there are some good reasons for that.
Firstly, we should address the fact that this system is not a big system, and it is not expected to grow to be a big project.
However, if it does come up to grow and expand services are still maintainable and there are solutions to the problems above each with their trade-offs.
Secondly, we should dive into the possible solutions for the problem above. There are three main solutions I've found to this problem.
</p>

<p>
The first two both allow services to use each other, but they differ in the way they do it.
One way to allow services to use each other is by using a dependency injection, however, it opens a
door to some serious problems and verbose code, we can easily face a circular dependency problem and
have big "fat" verbose constructors with ton of injections. Second way is by using a service locator,
which is a singleton that holds all the services and allows them to use each other. I personally not
a fan of the singleton pattern, so I tweaked this pattern. I created a "Service Gatherer", which is
almost identical is holding all the services, but it is not a singleton, it works by injecting all the
services into it, and then property inject itself into the services. Additionally all the services
extend a base service which has the gatherer instance and injection method to keep injection uniformed 
and easy to perform. An important note to make is that the gatherer was injected to the controllers
and they were extracting they're services inorder to prevent complexities at this level.
</p>

<p>
While the gatherer abstraction/ pattern described above is a good solution for the problem, it adds
a complexity to the project which isn't required at the moment, and it is not expected to be required.
Hence the third solution, which is to not allow services to use each other but rather allow duplicated
code to exist and let services communicate with several repositories. Since EF provides the amazing <code>DbContext</code>
class which is a realization of both the Unit of Work and Repository patterns, it is easy to use it for
retrieval of repositories (the <code>DbSet</code>s). Since most of the required uses between services
are for retrieval of data, this solution is a good one, if additional behavior is required (e.g. a
validation of some sort) it would be simply replicated or abstracted into a new object which would be
used by several services.
</p>

<p>
This solution is discussed in this <a href="https://stackoverflow.com/a/56667454/19275130">StackOverflow answer</a>.
It is important to note that this solution does come at the cost of not only duplicated code but also
a more complex code which would be a pain to refactor at a large scale. However, addressing the fact that this solution
is for small projects makes it a fair trade-off.