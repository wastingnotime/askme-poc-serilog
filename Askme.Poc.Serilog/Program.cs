using Serilog;
using Serilog.Events;
using System.Net;
using Serilog.Sinks.Email;

string Mensagem = "Serilog Teste";
Console.WriteLine(Mensagem);

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("C:\\Temp\\log_.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Email(new EmailConnectionInfo
    {
        FromEmail = "from@gmail.com",
        ToEmail = "to@gmail.com",
        MailServer = "smtp.gmail.com",
        NetworkCredentials = new NetworkCredential
        {
            UserName = "user@gmail.com",
            Password = "123456"
        },
        EnableSsl = false,
        Port = 465,
        EmailSubject = "Send"
    }, restrictedToMinimumLevel: LogEventLevel.Warning, batchPostingLimit: 10)
    .CreateLogger();

try
{
    Log.Error("Mensagem de erro");
    Log.Information($"{Mensagem} - Mensagem de Informação");
    Log.Fatal("Erro fatal");
    Log.Debug("Mensagem de Debug");
    Log.Warning("Mensagem de Warning");

    //throw new Exception("erro");
}
catch (Exception ex)
{
    Log.Error($"Catch - {ex}");
}

Console.WriteLine("Fim");



