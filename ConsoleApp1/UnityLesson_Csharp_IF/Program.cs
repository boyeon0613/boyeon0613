using System;
//모든 변수는 항상 false가 기본값 000000
namespace UnityLesson_Csharp_IF
{
    class Program
    {
        static bool doPrint = true;
        static void Main(string[] args)
        {
            if (doPrint == true)
            {
              Console.WriteLine("Hello World!");
            }
        }
    }
}
