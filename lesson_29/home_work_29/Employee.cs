namespace home_work_29
{
    public class Employee
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int birthYear { get; set; }
        public double salary { get; set; }

        public Employee(string name, string surname, int birthYear, double salary)
        {
            this.name = name;
            this.surname = surname;
            this.birthYear = birthYear;
            this.salary = salary;
        }

        public override string ToString()
        {
            return ($"Имя: {name}, фамилия: {surname}, год рождения: {birthYear}, зарплата : {salary}");
        }
    }
}