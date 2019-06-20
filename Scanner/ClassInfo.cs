using System.Collections.Generic;

namespace Scanner
{
    public class ClassInfo
    {
        public ClassInfo(string name, List<string> methods)
        {
            Name = name;
            Methods = methods;
        }

        public string Name { get; }
        public List<string> Methods { get; }
    }
}