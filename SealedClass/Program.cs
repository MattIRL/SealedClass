namespace SealedClass
{
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }

    }

    sealed class Executive : Employee
    {
        public string Title { get; set; }
        public double Salary;

        public Executive()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Title = string.Empty;
            Salary = 0;
        }
        public Executive(int id, string firstName, string lastName, string title, double salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            Salary = salary;
        }
        public override double Pay()
        {
            return this.Salary;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Employee object
            Employee george = new Employee(5, "George", "Costanza");
            george.Pay();

            // Executive object created using parameterized constructor
            Executive oliver = new Executive(10, "Oliver", "Warbucks", "Chief Operations Officer", 345000);
            Console.WriteLine($"\n{oliver.Fullname()}'s annual salary is ${oliver.Pay()}");

            //Executive object created using the default constructor
            Executive max = new Executive();
            max.Id = 256;
            max.FirstName = "Maximillian";
            max.LastName = "Veers";
            max.Title = "Chief Executive Officer";
            max.Salary = 501000;
            Console.WriteLine($"\n{max.Fullname()}'s annual salary is ${max.Pay()}");

        }
    }
}
