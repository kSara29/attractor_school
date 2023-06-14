using home_work_29;

public class EmployeeSalaryComparer<T>: IComparer<T> where T: Employee
{
    public int Compare(T x, T y)
    {
        if(x.salary > y.salary) 
            return 1;
        if(x.salary < y.salary) 
            return -1;
        else 
            return 0;
    }
}