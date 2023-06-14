using home_work_29;

public class EmployeeSurnameComparer<T>: IComparer<T> where T: Employee
{
    public int Compare(T x, T y)
    {
        return String.Compare(x.surname, y.surname);
    }
}