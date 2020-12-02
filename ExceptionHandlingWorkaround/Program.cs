using System;

namespace ExceptionHandlingWorkaround
{
    class Program
    {
        static void Main(string[] args)
        {
            Matematik matematik = new Matematik();

            try
            {
                Console.WriteLine(matematik.Bol(10, 0));
            }
            catch(DivideByZeroException exception) //Known exception management
            {
                Console.WriteLine("Payda sıfır olamaz.");
            }
            catch (Exception exception) //Unknown exception management
            {
                Console.WriteLine("Bir hata oluştu. Yöneticinize danışınız.");

                Console.WriteLine($"Sisteme loglanacak. Kullanıcı görmeyecek. {exception.Message}");
            }

           
        }


    }

    class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Bol(int sayi1, int sayi2)
        {
            return sayi1 / sayi2;
        }
    }
}
