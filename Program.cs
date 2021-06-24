using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace ArrayIteration
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = DefaultConfig.Instance
                .WithSummaryStyle(SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend))
                .AddDiagnoser(MemoryDiagnoser.Default)
                .AddDiagnoser(new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(
                    printSource: true,
                    exportGithubMarkdown: true)))
                .AddExporter(MarkdownExporter.GitHub);
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
        }
    }
}
