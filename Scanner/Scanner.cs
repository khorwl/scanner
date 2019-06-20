using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Scanner
{
    public class Scanner
    {
        public IEnumerable<ClassInfo> Scan(DirectoryInfo directory)
        {
            return directory
                .EnumerateFiles("*.dll")
                .SelectMany(ScanFile);
        }

        public IEnumerable<ClassInfo> ScanFile(FileInfo file)
        {
            return Assembly
                .LoadFile(file.FullName)
                .GetTypes()
                .Select(ScanClass);
        }

        public ClassInfo ScanClass(Type @class)
        {
            var methods = @class
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => !m.IsPrivate)
                .Select(m => m.Name)
                .ToList();

            return new ClassInfo(@class.FullName, methods);
        }
    }
}