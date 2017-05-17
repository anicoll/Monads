using System;

namespace Monads.Test
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime? Age { get; set; }

        public Try<bool> IsNameKees()
        {
            return Try<bool>.Invoke(() => Name == "Kees");
        }

        public Try<Employee> WillThrowException()
        {
            throw new NullReferenceException();
        }

        public Try<Employee> WillThrowTryException()
        {
            throw new TryException(Name);
        }
    }
}