using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_Class_base_exr
{
    abstract class Worker
    {
        public string name, position, work_day = "";

        public Worker(string n)
        {
            name = n;
        }
        public string call()
        {
            return ",calling ";
        }
        public string write_code()
        {
            return ",writing code ";
        }
        public string relax()
        {
            return ",relaxing ";
        }
        public abstract void fill_work_day();
    }
    class Developer : Worker
    {
        public Developer(string n) : base(n)
        {
            position = "developer";
        }
        public override void fill_work_day()
        {
            work_day += write_code();
            work_day += call();
            work_day += relax();
            work_day += write_code();
            Console.WriteLine(work_day);
            Console.WriteLine();
        }
    }
    class Manager : Worker
    {
        private Random rnd;
        public Manager(string n) : base(n)
        {
            rnd = new Random();
            position = "manager";
        }
        public override void fill_work_day()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 11);
            for(int i = 0; i < x; i++)
            {
                work_day += call();
            }
            work_day += relax();
            x = rnd.Next(1, 6);
            for(int i = 0; i < x; i++)
            {
                work_day += call();
            }
            Console.WriteLine(work_day);
            Console.WriteLine();
        }
    }
    class Team
    {
        private string team_name;
        private Worker[] list;
        private int index;
        public Team(string name)
        {
            team_name = name;
            list = new Worker[100];
            index = 0;
        }
        public void add_worker(Worker person)
        {
            list[index] = person;
            index++;
        }
        public void get_info()
        {
            Console.WriteLine(team_name);
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(list[i].name);
            }
            Console.WriteLine();
        }
        public void get_more_info()
        {
            Console.WriteLine(team_name);
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(list[i].name + " - " + list[i].position + " - " + list[i].work_day);
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Developer dev_1 = new Developer("vladislavov vladic vladislavovich");
            Developer dev_2 = new Developer("petriv petya olegovich");
            Developer dev_3 = new Developer("markovichov mark markovich");
            Manager man_1 = new Manager("olegov oleg olegovich");
            Manager man_2 = new Manager("Alphonov Alphon Alphonovich");
            Team team = new Team("Goods");

            dev_1.fill_work_day();
            dev_2.fill_work_day();
            dev_3.fill_work_day();
            man_1.fill_work_day();
            man_2.fill_work_day();
            team.add_worker(dev_1);
            team.add_worker(dev_2);
            team.add_worker(dev_3);
            team.get_info();
            team.get_more_info();
            team.add_worker(dev_2);
            team.add_worker(man_1);
            team.get_info();
            team.get_more_info();
            Console.ReadLine();
        }
    }
}
