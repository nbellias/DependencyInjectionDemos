// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using SimpleDI.Models;
using SimpleDI.Services.Authenticate;
using SimpleDI.Services.Authorize;
using SimpleDI.Services.SendEmail;
using SimpleDI.Services.SendSMS;
using SimpleDI.Services.WriteLog;
using SimpleDI.ServiceUsage;

IWriteLog writeLog = new WriteLog();
IAuthenticate authenticate = new Authenticate(writeLog);
IAuthorize authorize = new Authorize(writeLog);
ISendEmail sendEmail = new SendEmail(writeLog);
ISendSMS sendSMS = new SendSMS(writeLog);

InformUseService inform = new InformUseService(sendEmail, sendSMS);

Console.WriteLine("Simple Dependency Injection");
Console.WriteLine();

Console.Write("Username: ");
var userName = Console.ReadLine();
Console.Write("Password: ");
var passWord = Console.ReadLine();

var request = new Request
{
    Data = new
    {
        username = userName,
        password = passWord
    }
};

var authResponse = authenticate.IsAuthenticated(request);

var accessResponse = authorize.IsAuthorized(authResponse);

if(accessResponse.Data.Count == 2)
{
    inform.InformWithEmailAndSMS("Hello World");
    writeLog.ShutdownLogManager();
}
    





