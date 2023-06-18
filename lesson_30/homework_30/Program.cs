namespace homework_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee { Name = "Ivanov Ivan", Experience = 5 };
            MySerializer<Employee> employeeSerializer = new MySerializer<Employee>(employee);

            string serializedEmployee = employeeSerializer.Serialize();
            string ser = employeeSerializer.SerializedExtra();

            Console.WriteLine(serializedEmployee);

            Console.WriteLine("\nBonus task");
            Console.WriteLine(ser);
        }

    } 
}

