// ASP - Active Server Pages
// VBScript - Visual Basic Scripting Edition

// Chain Of Responsibility - CoR

User user = new User("mr.13", "Salam123654", "zamanov@itstep.org");
var director = new CheckDirector();
Console.WriteLine(director.MakeUserChecker(user));

