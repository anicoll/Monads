using System;
using System.Reflection;

namespace Monads
{
    public class Failure<T> : Try<T>
    {
        private readonly Exception _exception;

        public Failure(Exception e)
        {
            _exception = e;
        }

        public Failure(string message, params object[] p)
        {
            _exception = new TryException(message, p);
        }

        public override bool IsSuccess => false;

        public override bool IsFailure => true;

        public override T Value
        {
            get { throw _exception; }
        }

        public override T Get()
        {
            throw _exception;
        }


        public override T GetOrDefault()
        {
            return default(T);
        }

        public override T GetOrElse(T other)
        {
            return other;
        }

        public override Try<T> OrElse(Func<T> other)
        {
            return Invoke(other);
        }


        public override Try<U> Map<U>(Func<T, U> mapper)
        {
            return new Failure<U>(_exception);
        }

        public override Try<U> FlatMap<U>(Func<T, Try<U>> mapper)
        {
            return new Failure<U>(_exception);
        }

        public override Try<T> Recover(Func<Exception, T> mapper)
        {
            try
            {
                return new Success<T>(mapper.Invoke(_exception));
            }
            catch
            {
                return new Failure<T>(_exception);
            }
        }

        public override Try<T> Recover<U>(Func<Exception, T> recover)
        {
//            return (exception.GetType().IsAssignableFrom(typeof (U))) ? Recover(recover) : this;
            return _exception.GetType().GetTypeInfo().IsAssignableFrom(typeof(U)) ? Recover(recover) : this;
        }

        public override Try<T> Filter(Predicate<T> predicate)
        {
            return this;
        }

        public override Try<T> Set(Action<T> setter)
        {
            return this;
        }
    }
}