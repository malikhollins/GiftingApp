using System;
using System.Diagnostics;

var sqlPackage = "SqlPackage";
string sqlPackageArgs =
    """
    /Action:Publish /SourceFile:"../../DatabaseApp/bin/Release/ServerApp.dacpac" /TargetConnectionString:"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=GiftingApp;"
    """;

using (Process installDotnetPackage = new Process())
{
    installDotnetPackage.StartInfo.FileName = sqlPackage;
    installDotnetPackage.StartInfo.Arguments = sqlPackageArgs;
    installDotnetPackage.StartInfo.CreateNoWindow = true;
    installDotnetPackage.StartInfo.RedirectStandardOutput = true;
    installDotnetPackage.Start();
    string output = installDotnetPackage.StandardOutput.ReadToEnd();
    installDotnetPackage.WaitForExit();
    Console.WriteLine(output);
}