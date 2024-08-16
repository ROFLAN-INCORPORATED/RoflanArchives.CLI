using System;
using System.IO;
using System.Linq;
using ConsoleAppFramework;
using RoflanArchives.Core;

namespace RoflanArchives.CLI.Commands;

// ReSharper disable once ClassCannotBeInstantiated
// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class PackCommand
{
    public const string CommandPath = "pack";



    /// <summary>
    /// Pack 'sources' directories to 'output' archive file (.roflarc).
    /// </summary>
    /// <param name="sources">-s, Source directories paths (comma-separated without spaces).</param>
    /// <param name="output">-o, Output archive file (.roflarc) path.</param>
    /// <param name="compressionType">-c|-ct, Global compression type (valid values: 1 or NoCompression; 2 or LZ4Block; 3 or LZ4Stream).</param>
    /// <param name="compressionLevel">-l|-cl, Global compression level.</param>
    /// <param name="name">-n, Archive in-code name (uses output file name by default).</param>
    /// <param name="version">-v, Archive API version (uses latest API by default).</param>
    [Command("")]
    public void Pack(
        [Argument] string[] sources,
        [Argument] string output,
        RoflanArchiveCompressionType compressionType = RoflanArchiveCompressionType.LZ4Stream,
        byte compressionLevel = 0,
        string? name = null,
        string? version = null)
    {
        var sourcesInfo = sources
            .Select(source =>
                new RoflanArchiveSourceDirectoryInfo(source));
        var outputDirectoryPath = Path.GetDirectoryName(output)
                                  ?? Environment.CurrentDirectory;
        var outputFileName = Path.GetFileName(output);
        var versionApi = string.IsNullOrWhiteSpace(version)
            ? null
            : new Version(version);

        RoflanArchive.Pack(
            outputDirectoryPath, outputFileName, sourcesInfo,
            compressionType, compressionLevel, name, versionApi);
    }
}
