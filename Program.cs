using System;
using ConsoleAppFramework;
using RoflanArchives.CLI.Commands;

namespace RoflanArchives.CLI;

internal static class Program
{
    private static void Main(
        string[] args)
    {
        var app = ConsoleApp.Create();

        // ReSharper disable InvocationIsSkipped

        app.Add<PackCommand>(
            "pack");
        app.Add<UnpackCommand>(
            "unpack");

        // ReSharper restore InvocationIsSkipped

        app.Run(args);
    }
}
