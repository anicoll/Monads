using System;

namespace Monads
{
    /// <summary>
    ///     Success{T} is a <see cref="Try{T}" /> subclass that holds a value of type {T} after successful invoking a
    ///     <see cref="Try{T}.Map{U}" />.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Success<T> : Try<T>
    {
        private readonly T _value;

        public Success(T value)
        {
            this._value = value;
        }

        public override T Value => _value;

        public override bool IsSuccess => true;

        public override bool IsFailure => false;

        public override T Get()
        {
            return _value;
        }

        public override T GetOrDefault()
        {
            return _value;
        }

        public override T GetOrElse(T other)
        {
            return _value;
        }

        public override Try<T> OrElse(Func<T> other)
        {
            return this;
        }

        public override Try<U> Map<U>(Func<T, U> mapper)
        {
            return Try<U>.Invoke(() => mapper.Invoke(_value));
        }

        public override Try<U> FlatMap<U>(Func<T, Try<U>> mapper)
        {
            return Try<U>.Invoke(() => mapper.Invoke(_value).Get());
        }

        public override Try<T> Recover(Func<Exception, T> mapper)
        {
            return this;
        }

        public override Try<T> Recover<U>(Func<Exception, T> mapper)
        {
            return this;
        }

        public override Try<T> Filter(Predicate<T> predicate)
        {
            try
            {
                var result = predicate.Invoke(_value);

                if (result)
                    return this;

                return new Failure<T>("There are no results from applying the predicate");
            }
            catch
            {
                return new Failure<T>("There are no results from applying the predicate");
            }
        }

        public override Try<T> Set(Action<T> setter)
        {
            try
            {
                setter.Invoke(_value);

                return this;
            }
            catch (Exception ex)
            {
                return new Failure<T>(ex);
            }
        }
    }
}