using System;

namespace GameCC666
{
    public class Animation
    {
        public Animation()
        {
            Console.WriteLine("使用的是---无参---的构造函数");
        }
        public Animation(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            Console.WriteLine("使用的是---带参数---的构造函数");
        }
        public string Name;
        public int Age;
        public int Weight { get; set; }
        public int Height { get; set; }


        public void GetAnimationName()
        {
            Console.WriteLine("调用了一个public函数！函数名字是GetAnimation（）");
        }
        public void GetAge()
        {
            Console.WriteLine("调用了一个public函数！函数名字是GetAge（）");
        }

        public static string CallMethod()
        {
            return "这是一个静态方法，CallMethod";
        }

        public void SetWeight(int weight)
        {
            this.Weight = weight;
        }
        public void SetHeight(int height)
        {
            this.Height = height;
        }
        public string SayHello(string name)
        {
            return string.Format("Hello:{0}!", name);
        }
    }
}
