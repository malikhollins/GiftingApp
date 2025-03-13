using System.Diagnostics;

const string dotnetPath = "dotnet";
const string installScriptArgs = "tool install -g microsoft.sqlpackage";
const string installSqlPackageArgs = "tool install -g dotnet-script";
const string runLocalDbArgs = "script createlocal.csx";

Console.WriteLine("Choose an option from the following list:");
Console.WriteLine("\tinstall - Install Dependecies");
Console.WriteLine("\tlocal - Create local database");
Console.Write("Your option? ");

switch (Console.ReadLine()?.ToLower() ?? string.Empty)
{
    case "install":
        Console.WriteLine("Running install command...");
        RunDotnetCommand(installScriptArgs);
        RunDotnetCommand(installSqlPackageArgs);
        Console.WriteLine("Dependecies installed...");
        break;
    case "local":
        Console.WriteLine("Running local command...");
        RunDotnetCommand(runLocalDbArgs);
        break;
}

Console.Write("Press any key to close the console app...");
Console.ReadKey();

static void RunDotnetCommand(string dotnetArgs)
{
    using Process installDotnetPackage = new();
    installDotnetPackage.StartInfo.FileName = dotnetPath;
    installDotnetPackage.StartInfo.Arguments = dotnetArgs;
    installDotnetPackage.StartInfo.CreateNoWindow = true;
    installDotnetPackage.StartInfo.RedirectStandardOutput = true;
    installDotnetPackage.Start();
    string output = installDotnetPackage.StandardOutput.ReadToEnd();
    installDotnetPackage.WaitForExit();
    Console.WriteLine(output);
}