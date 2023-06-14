namespace home_work_29
{
    public class Program

    {
        static void Main(string[] args)
        {
            List<Employee> employeesList = new List<Employee>();
            employeesList.Add(new Employee("Стивен", "Дэй", 2000, 23.122));
            employeesList.Add(new Employee("Алиса", "Линк", 1995, 15.99));
            employeesList.Add(new Employee("Линда", "Дрю", 2005, 57.399));
            employeesList.Add(new Employee("Оливия", "Уайт", 1999, 34.65));
            employeesList.Add(new Employee("Джон", "Блэк", 2001, 46.234));
            employeesList.Add(new Employee("Микки", "Маус", 1978, 67.43));

            EmployeeNameComparer<Employee> nameComparer= new EmployeeNameComparer<Employee>();
            EmployeeSurnameComparer<Employee> surnameComparer= new EmployeeSurnameComparer<Employee>();
            EmployeeBirthYearComparer<Employee> birthYearComparer= new EmployeeBirthYearComparer<Employee>();
            EmployeeSalaryComparer<Employee> salaryComparer= new EmployeeSalaryComparer<Employee>();

            Console.WriteLine("\nИсходынй список сотрудников: \n");
            foreach(Employee employee in employeesList)
                Console.WriteLine(employee);


            Console.WriteLine("\nСотрудники отсортированные по имени: \n");
            employeesList.Sort(nameComparer);
            foreach(Employee employee in employeesList)
                Console.WriteLine(employee);

            Console.WriteLine("\nСотрудники отсортированные по фамилии: \n");
            employeesList.Sort(surnameComparer);
            foreach(Employee employee in employeesList)
                Console.WriteLine(employee);

            Console.WriteLine("\nСотрудники отсортированные по году рождения: \n");
            employeesList.Sort(birthYearComparer);
            foreach(Employee employee in employeesList)
                Console.WriteLine(employee);
            
            Console.WriteLine("\nСотрудники отсортированные по зарплате: \n");
            employeesList.Sort(salaryComparer);
            foreach(Employee employee in employeesList)
                Console.WriteLine(employee);


            EmployeeEnum employees = new EmployeeEnum();
            employees.Add(new Employee("Богдан", "Иванов", 2005, 57.399));
            employees.Add(new Employee("Тимур", "Айгазинов", 1999, 34.65));
            employees.Add(new Employee("Оливер", "Твист", 2001, 46.234));
            employees.Add(new Employee("Мишель", "Обама", 1978, 67.43));

            Console.WriteLine("\nИсходынй список сотрудников: \n");
            foreach(Employee employee in employees)
                Console.WriteLine(employee);
        }
    }
}