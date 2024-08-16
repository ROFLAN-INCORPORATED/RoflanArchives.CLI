using System;
using ConsoleAppFramework;
using RoflanArchives.CLI.Commands;

namespace RoflanArchives.CLI;

internal sealed class Program
{
    private static void Main(
        string[] args)
    {
        var app = ConsoleApp.Create();

        app.Add<PackCommand>(
            "pack");
        app.Add<UnpackCommand>(
            "unpack");

        app.Run(args);
    }
}
