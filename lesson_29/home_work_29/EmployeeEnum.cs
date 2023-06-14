using System.Collections;

namespace home_work_29
{
    public class EmployeeEnum: IEnumerable<Employee>, IEnumerator<Employee>
    {
        private List<Employee> employees;
        private int index;

        public EmployeeEnum()
        {
            employees = new List<Employee>();
            index = -1;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if(index == employees.Count - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get { return employees[index]; }
        }

        Employee IEnumerator<Employee>.Current
        {
            get {return (Employee)Current; }
        }
        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public void Dispose()
        {
            
        }
    }
}