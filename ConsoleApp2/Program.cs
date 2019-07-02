using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[2] { new Cat("mike"), new Dogs("Bob") };
            foreach (var item in animals)
            {
                if (item is Dogs)
                {
                    item.OnSound();
                } 
            }

            List<Animal> animals1 = new List<Animal>
            {
                new Cat("cat1"),
                new Cat("cat2"),
                new Dogs("dog1"),
                new Dogs("dog2"),
            };

            var dogs = from animal in animals1
                       where animal is Cat
                       select animal;
            foreach (var item in dogs)
            {
                item.OnSound();
            }
            

            Func<int, int, string> equal = (x, y) => x == y ? "equal" : "not equal";
            Console.WriteLine(equal(2,2));
            Action<string> func = x => { Console.WriteLine("You input: {0}", x); };
            func("dsd");
            Console.ReadLine();
        }
    }

    abstract class Animal
    {
        protected string name { get; set; }

        protected abstract string color { get; set; }
        public abstract void OnSound();
    }

    class Dogs : Animal,ISound
    {
        private string nickname;
        private string sound;
        public Dogs()
        {
            name = "Dogs";
            sound = "Wongwong";
        }

        public Dogs(string nickname) : this() => this.nickname = nickname;

        protected override string color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string getSound()
        {
            return sound;
        }

        public override void OnSound()
        {
            Console.WriteLine("{0} speak {1}", nickname,sound);
        }

        public void speakSound()
        {
            Console.WriteLine("{0} speak {1}", nickname, sound);
        }
    }

    class Cat : Animal
    {
        private string nickname;
        private string sound;
        public Cat()
        {
            name = "Cat";
            sound = "miaomiao";
        }

        public Cat(string nickname):this() => this.nickname = nickname;

        protected override string color { get; set; }

        public override void OnSound()
        {
            Console.WriteLine("{0} speak {1}", nickname, sound);
        }
    }


    interface ISound
    {
        string getSound();
        void speakSound();
    }

}
