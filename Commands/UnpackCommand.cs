using System;
using ConsoleAppFramework;
using RoflanArchives.Core;

namespace RoflanArchives.CLI.Commands;

// ReSharper disable once ClassCannotBeInstantiated
// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class UnpackCommand
{
    public const string CommandPath = "unpack";



    /// <summary>
    /// Unpack 'source' archive file (.roflarc) to 'output' directory.
    /// </summary>
    /// <param name="source">-s, Source archive file (.roflarc) path.</param>
    /// <param name="output">-o, Output directory path.</param>
    [Command("")]
    public void Unpack(
        [Argument] string source,
        [Argument] string output)
    {
        RoflanArchive.Unpack(
            source, output);
    }
}
