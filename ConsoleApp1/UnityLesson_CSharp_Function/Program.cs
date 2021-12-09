using System;

namespace UnityLesson_CSharp_Function
{
    class Program
    {
        static bool doPrintHelloWorld = true;
        static bool doPrintSomething = true;

        static void Main(string[] args)


        {  // 함수 호출시 함수이름 (); 형태로 호출한다.
            if (doPrintHelloWorld == true)
            {
                PrintHelloWorld();
            }
            else
            {
                Console.WriteLine("do nothing");
            }
            // parameter : 함수 호출시 입력 변수
            //string 안은 큰따옴표
            string something = "unity Hola!";

            if (doPrintSomething == true)
            {
                PrintSomoething(something);
            }
        }
        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
        static void PrintSomoething(string something)
        {
            Console.WriteLine(something);
        }
    }
}
