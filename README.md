# WebLogger

### What is done:
1. Fake log generation service, that is triggered from UI
2. WebLoggerHub, so many clients can subscribe/unsubscribe and receive logs

### Possible improvements:
1. Add some styles on UI (especially for the table)
2. Add some additional logic on BE to prevent calling IBusinessLogicService.DoSomeLogic() a couple of time (currently, it's done by hiding button, but it does not solve a problem with several tabs/clients)
3. Remove default files, that added by the project template
4. Use some JS-library to make the JS-code more clear
5. Use closures on UI, extract "magic strings" to constants (and other best practices)
6. Add separate projects on BE for services

### Files for review
#### Folders:
Constants, Controllers, Hubs, Services

#### Files:
Pages/Index.cshtml

wwwroot/js/log.js
