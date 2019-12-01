using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behvioral.Observer.Event
{
    public class FallsIllEventArgs
    {
        public string Address;
    }

    public class Person
    {
        public void CatchACold()
        {
            FallsIll?.Invoke(this,
              new FallsIllEventArgs { Address = "123 London Road" });
        }

        public event EventHandler<FallsIllEventArgs> FallsIll;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();

            person.FallsIll += CallDoctor;

            person.CatchACold();
        }
        private static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
        }
    }
}
