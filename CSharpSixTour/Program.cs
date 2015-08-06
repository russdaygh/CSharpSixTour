using System;

namespace CSharpSixTour
{
    class Program
    {
        static void Main(string[] args)
        {
            MyContrivedClass myContrivedClass = new MyContrivedClass();

            myContrivedClass.PrintFoo();
        }

        class MyContrivedClass
        {
            private readonly string InternalFoo;

            public MyContrivedClass()
            {
                InternalFoo = "Bar";
            }

            public void PrintFoo()
            {
                Console.WriteLine(InternalFoo);
            }
        }
    }
}
