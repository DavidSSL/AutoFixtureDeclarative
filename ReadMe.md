Introduction
============

[AutoFixture](https://github.com/AutoFixture/AutoFixture) is a great library for dealing with the "Arrange" phase in Test Driven Development. There is very good documentation and the [CheatSheet](https://github.com/AutoFixture/AutoFixture/wiki/Cheat-Sheet) is a time saver. 

However, there is a lack of documentation/examples on how to get the fixture set up to be more declarative. This is my attempt to remedy that through examples. Hence, I'll be going through the various [posts](http://blog.ploeh.dk/tags.html#AutoFixture-ref) and turning the given examples into a more declarative fashion. 

Warning
=======
The names of my tests might be very misleading and no semantic meaning should be attached to them. As I'm basing these examples upon the blog posts given above, I am simply naming the tests accordingly. 

For example there is this [post](http://blog.ploeh.dk/2009/04/23/DealingWithTypesWithoutPublicConstructors/) and the related code is [this](https://github.com/DavidSSL/AutoFixtureDeclarative/blob/master/Example.UnitTests/DealingWithTypesWithoutPublicCtrsTests.cs)