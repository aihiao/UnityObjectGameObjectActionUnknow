using System;

namespace ActionTUnknow
{
    public class People
    {
        public string name;
    }

    public class Man : People
    {

    }

    public class Woman : People
    {

    }

    public static class Tools
    {
        public static void Create(Action<string, bool, Man> a)
        {
            string identity = "Boss";

            if (a != null)
            {
                Man man = new Man();
                man.name = "Dawei";
                a.Invoke(identity, true, man);
            }
        }

        public static void Create(Action<string, bool, People> a)
        {
            string identity = "Manager";

            if (a != null)
            {
                People people = new People();
                people.name = "Lucy";
                a.Invoke(identity, true, people);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Tools.Create(CreatePeople); // 这里调用没有出现二义性, 在Unity中却出现了二义性

            Console.ReadKey();
        }

        public static void CreatePeople(string identity, bool confirmIdentity, People people)
        {
            if (string.IsNullOrEmpty(identity) || people == null)
            {
                return;
            }

            Console.WriteLine(identity + " want create a " + people.name + (confirmIdentity ? " and identity confirm success." : " but identify confirm failed."));
            if (confirmIdentity)
            {
                Console.WriteLine("Create " + people.name + " success.");
            }
        }

        public static void CreateMan(string identity, bool confirmIdentity, Man man)
        {
            if (string.IsNullOrEmpty(identity) || man == null)
            {
                return;
            }

            Console.WriteLine(identity + " want create a " + man.name + (confirmIdentity ? " and identity confirm success." : " but identify confirm failed."));
            if (confirmIdentity)
            {
                Console.WriteLine("Create " + man.name + " success.");
            }
        }

    }
}
