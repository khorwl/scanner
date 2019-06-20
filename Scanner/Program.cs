using System;
using System.IO;
using System.Reflection;
using System.Text;
using CommandLine;

namespace Scanner
{
    internal class Program
    {
        private class Options
        {
            [Value(0, HelpText="Path to directory with dll files", Required = true)]
            public string Path { get; set; }
        }

        public static void Main(string[] args)
        {
            Parser
                .Default
                .ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    try
                    {
                        var scanner = new Scanner();
                        var classes = scanner.Scan(new DirectoryInfo(options.Path));
                        var builder = new StringBuilder();
                        var newLine = Environment.NewLine;

                        foreach (var classInfo in classes)
                        {
                            builder.Append(classInfo.Name);
                            builder.Append(newLine);

                            foreach (var method in classInfo.Methods)
                            {
                                builder.Append("\t").Append(method).Append(Environment.NewLine);
                            }
                        }

                        Console.WriteLine(builder.ToString());
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("Cant open given directory");
                    }
                    catch (ReflectionTypeLoadException e)
                    {
                        Console.WriteLine("During scanning assemblies errors was occured:");

                        foreach (var eLoaderException in e.LoaderExceptions)
                        {
                            Console.WriteLine(eLoaderException);
                        }
                    }
                });
        }
    }
}