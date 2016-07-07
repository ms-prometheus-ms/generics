using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus
{
    class Program3
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IGreeter<Human> posipaka1 = new Greeter<Human>();
            IGreeter<Gaidamaka> posipaka2 = new Greeter<Human>();
            IGreeter<Human> posipaka3 = new Greeter<Gaidamaka>();

            posipaka3.findSomebodySimilar("Київ").Speak();

            posipaka3 = new Greeter<Human>();

            posipaka3.findSomebodySimilar("Київ").Speak();

            Console.ReadKey();
        }

        interface IGreeter<in T>
        {
             void Greet(T somebody);
             T findSomebodySimilar(string word);
        }

        class Greeter<T> : IGreeter<T>
            where T: Human, new()
        {
            public string TypeName
            {
                get
                {
                    return "[Greeter type T with typeof(T) = '" + typeof(T).ToString() + "']";
                }
            }

            public Greeter()
            {
                Console.WriteLine(this.TypeName + " has been created!");
            }

            public void Greet(T somebody)
            {
                Console.WriteLine(somebody.ToString() + "! Вас шанобливо вітає {" + this.ToString() + "}");
            }
            public T findSomebodySimilar(string word)
            {
                Console.WriteLine(this.TypeName + " found: ");
                if (new T() is Gaidamaka)
                {
                    return (T)((word != "Київ") ? (Human)new GaidamakaZhytomyrskiy() : new GaidamakaKyivskiy());
                }
                return (T)new Human();
            }

        public override string ToString()
            {
                return "Зразок з іменем типу: " + TypeName;
            }
        }

        class Human
        {
            public override string ToString()
            {
                return "Human";
            }
            virtual public void Speak()
            {
                Console.WriteLine(ToString() + " is here!");
            }
        }

        class Gaidamaka: Human
        {
            public override string ToString()
            {
                return "Гайдамака";
            }

            override public void Speak()
            {
                Console.WriteLine(this.ToString() + " вже тут!");
            }
        }

        class GaidamakaZhytomyrskiy : Gaidamaka
        {
            public override string ToString()
            {
                return "Гайдамака житомирський";
            }
        }

        class GaidamakaKyivskiy : Gaidamaka
        {
            public override string ToString()
            {
                return "Гайдамака київський";
            }
        }

        class AmericanSoldier: Human
        {
            public override string ToString()
            {
                return "AmericanSoldier";
            }

            override public void Speak()
            {
                Console.WriteLine(this.ToString() + " here! Sir, Yes sir.");
            }
        }


    }
}
