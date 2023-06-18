using homework_30;

class Employee
{

    [MyPropertyInfo(SerializationName = "Имя сотрудника")]
    public string Name { get; set; }

    [MyPropertyInfo(SerializationName = "Опыт работы")]
    public int Experience { get; set; }

}