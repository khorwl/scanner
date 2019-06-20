using System;

namespace MyLibrary
{
    public class MyClass
    {
        public void Public()
        {
            Console.WriteLine("First");
        }

        protected void Protected()
        {
            Console.WriteLine("Second");
        }

        private void Private()
        {
            Console.WriteLine("Third");
        }

        public static void PublicStatic()
        {
            Console.WriteLine("First");
        }

        protected static void ProtectedStatic()
        {
            Console.WriteLine("Second");
        }

        private static void PrivateStatic()
        {
            Console.WriteLine("Third");
        }
    }
}
