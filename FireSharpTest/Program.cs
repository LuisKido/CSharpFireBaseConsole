using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string secret = "YOUR_SECRET_DB_TOKEN";
            string path = "YOUR_DB_BASEPATH";

            FireBaseImplementation bd = new FireBaseImplementation(secret, path);

            //var result = bd.Insert();
            //var result = bd.GetPerson("99");
            //var result = bd.Update("99");
            //var result = bd.Delete("99");
            var result = bd.GetAllPersons();

            foreach(var x in result)
            {
                Console.WriteLine(x);
            }
            
            Console.ReadLine();

        }

    }
}
