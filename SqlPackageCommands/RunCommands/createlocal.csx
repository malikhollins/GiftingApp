using System.Diagnostics;
using System;

string sqlPackage = "SqlPackage";
string sqlPackagePublishArgs =
    """
    /Action:Publish /SourceFile:"./DatabaseApp/bin/Release/ServerApp.dacpac" /TargetConnectionString:"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=GiftingApp;"
    """;

using (Process publishSqlServer = new Process())
{
    publishSqlServer.StartInfo.FileName = sqlPackage;
    publishSqlServer.StartInfo.Arguments = sqlPackagePublishArgs;
    publishSqlServer.StartInfo.CreateNoWindow = true;
    publishSqlServer.StartInfo.RedirectStandardOutput = true;
    publishSqlServer.Start();
    string output = publishSqlServer.StandardOutput.ReadToEnd();
    publishSqlServer.WaitForExit();
    Console.WriteLine(output);
}