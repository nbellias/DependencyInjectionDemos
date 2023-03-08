// See https://aka.ms/new-console-template for more information
using SimpleDI.Services.SendEmail;
using SimpleDI.Services.SendSMS;
using SimpleDI.Services.WriteLog;
using SimpleDI.ServiceUsage;

Console.WriteLine("Simple Dependency Injection");

IWriteLog writeLog = new WriteLog();
ISendEmail sendEmail = new SendEmail(writeLog);
ISendSMS sendSMS = new SendSMS(writeLog);
Inform inform = new Inform(sendEmail, sendSMS);

inform.InformWithEmailAndSMS("Hello World");