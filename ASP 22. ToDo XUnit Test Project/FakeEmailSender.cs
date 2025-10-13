using ASP_23._Unit_Test.Services;

namespace ASP_22._ToDo_XUnit_Test_Project;

class FakeEmailSender : IEmailSender
{
    public Task SendEmail(string to, string text, string title)
    {
       return Task.CompletedTask;
    }
}
