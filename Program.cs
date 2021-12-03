using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            var a = new MXAPICLASS();
            var b = a.ListofUsers("1","10");
            //Console.WriteLine(b.Result.Content);
            b = a.CreateUser("asgdyugy1232g1iuy223", false, "dasyggayhs@gmail.com", "steven", "universe");            
            //Console.WriteLine(b.Result);
        }        
    }
}
