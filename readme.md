
# Project Name

TODO: Write a project description

## Installation

TODO: Describe the installation process

## Usage

This repository is a demo of a blog post I found [here](https://www.exceptionnotfound.net/the-asp-net-web-api-exception-handling-pipeline-a-guided-tour/).  So first off, kudos to that guy for helping me understand the "4 levels" of logging.  The purpose is to show different ways of handling exceptions in Web API.  I tried to keep the levels separate, which is why routing is implemented (you'll see below).

Just in case that link ever dies, I'll lay out those 4 levels here and how to call them from within the API.  I recommend using that blog post as a reference if something doesn't make sense.  It should noted as well that I tried keeping this project as simple as possible to illustrate Exceptions in Web API.  Certain design principles may have been ignored.  And I used singletons, which I'm not a fan of.  And I did not make them thread-safe.  So use at your own risk.  This by no means is production-ready code.

Swashbuckle/Swagger was not included, however, MS's Web API Help Pages are included.  So if you ever want to look at all of the endpoints, run the app and goto /Help.

1. HttpResponseException
	This is your basic exception response in Web API 2.  You'll reach this going to api/exception/1.  What are you doing is creating a `HttpResponseException` and throwing it.  This gets returned to the client.
2. Exception Filters
	These work by adding attributes to your controller or action (depending upon your desired scope.  This gives you the ability to focus behavior down to the action but reuse code in multiple places.  You can reach this with api/exception/2.  This will redirect to another controller in order to invoke the exception filter.  So head over to Level2ExceptionController to check that out.  As you can see on the Get method, there is a `Level2ExceptionFilter` attribute.  This attribute inherits from `ExceptionFilterAttribute`.  By simple overriding the `OnException` method, you can intercept these exceptions and do what you want.

3. Logging
	ASP.NET Web API has a built-in way to do some logging with exceptions.  You'll set this up in your `WebApiConfig` class by adding 
	```c#
	 config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());
	 ```  
	 By replacing this service with your own custom service, you can implement your own custom logger.  My logging server is called `BadLogger` because it's a terrible logging service.  In practice, I will typically use an open-source logger.  I wanted to keep this demo as simple as possible though, so I only used the necessary frameworks to get this to work.  `BadLogger` uses `InMemoryLogRepository`, which keeps the logs of your calls and exceptions during the debug session in memory.  You can retrieve these at api/log and api/exceptionlog.  If you visit api/exception/3, you will get an exception back.  Then, if you visit api/exceptionlog, you will see that exception in the list!
4. Exception Handlers
	This is it.  This is the final level.  This is a global handler that you register like so:
	```C#
	config.Services.Replace(typeof(IExceptionHandler), new Level4ExceptionHandler());
	```
	By registering this service, you're going to catch all unhandled exceptions.  Notice my handler is named `Level4ExceptionHandler`.  There's a reason for this!  I'm only doing something with Level4Exceptions.  These are created when you visit api/exception/4.  If you place a breakpoint in the handler class and throw a Level3Exception, you'll notice it passes right through so the unhandled exception is returned.  But for Level4, we're passing back a nice neat response message like we did in level 1.  The difference here is that we're doing this on a global scope instead of per-action.  

## Other Notes

One more thing.  I never mentioned `ApiLogHandler`.  You may have noticed this.  It gets plugged in during the config setup with this line:
```C#
config.MessageHandlers.Add(new ApiLogHandler());
```

As you can see, it's a `DelegatingHandler`which, itself, is a `HttpMessageHandler`.  All this does is intercept the call and log it.  You can view these logs at api/log.  Just like the exception logger, it uses the `BadLogger` to do it's dirty work.


## Contributing

While I'm not really interested in doing anything else with this, I would welcome feedback and criticism, so feel free to fork it and fix it and create a pull request for me.

## History

So little history, I did this in a few hours.  I am including it to help anyone else with exception handling.  By getting all the way up the levels, you can ensure minimum code re-use.  DRY!

## Credits

Just me and that [original blog post](https://www.exceptionnotfound.net/the-asp-net-web-api-exception-handling-pipeline-a-guided-tour/)