namespace Monads.Test
{
    public class EmployeeRepository
    {
        public Employee Create(string name)
        {
            return new Employee {Name = name};
        }
    }
}