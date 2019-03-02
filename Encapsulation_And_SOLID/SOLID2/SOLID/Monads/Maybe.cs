using System;
using NullGuard;
using SOLID.Monads;

namespace SOLID.Maybe
{
    public struct Maybe<T> : IEquatable<Maybe<T>> where T : class
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (HasNoValue)
                {
                    throw new InvalidOperationException();
                }

                return _value;
            }
        }

        public bool HasValue => _value != null;
        public bool HasNoValue => !HasValue;

        private Maybe([AllowNull] T value)
        {
            _value = value;
        }

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> From(T obj)
        {
            return new Maybe<T>(obj);
        }

        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (maybe.HasNoValue)
            {
                return false;
            }

            return maybe.Value.Equals(value);
        }

        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return !(maybe == value);
        }

        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (obj is T)
            {
                obj = new Maybe<T>((T) obj);
            }

            if (!(obj is Maybe<T>))
            {
                return false;
            }

            var other = (Maybe<T>) obj;
            return Equals(other);
        }

        public bool Equals(Maybe<T> other)
        {
            if (HasNoValue && other.HasNoValue)
            {
                return true;
            }

            if (HasNoValue || other.HasNoValue)
            {
                return false;
            }

            return _value.Equals(other._value);
        }

        public override int GetHashCode()
        {
            if (HasNoValue)
            {
                return 0;
            }

            return _value.GetHashCode();
        }

        public override string ToString()
        {
            if (HasNoValue)
            {
                return "No value";
            }

            return Value.ToString();
        }
    }

    public static class MaybeExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage)
            where T : class
        {
            if (maybe.HasNoValue)
            {
                return Result.Fail<T>(errorMessage);
            }

            return Result.Success(maybe.Value);
        }

        [return: AllowNull]
        public static T Unwrap<T>(this Maybe<T> maybe, [AllowNull] T defaultValue = null)
            where T : class
        {
            return maybe.Unwrap(x => x, defaultValue);
        }

        public static K Unwrap<T, K>(this Maybe<T> maybe, Func<T, K> selector, K defaultValue = default(K))
            where T : class
        {
            if (maybe.HasValue)
            {
                return selector(maybe.Value);
            }

            return defaultValue;
        }

        public static Maybe<T> Where<T>(this Maybe<T> maybe, Func<T, bool> predicate)
            where T : class
        {
            if (maybe.HasNoValue)
            {
                return null;
            }

            if (predicate(maybe.Value))
            {
                return maybe;
            }

            return null;
        }

        public static Maybe<K> Select<T, K>(this Maybe<T> maybe, Func<T, K> selector)
            where T : class
            where K : class
        {
            if (maybe.HasNoValue)
            {
                return null;
            }

            return selector(maybe.Value);
        }

        public static Maybe<K> Select<T, K>(this Maybe<T> maybe, Func<T, Maybe<K>> selector)
            where T : class
            where K : class
        {
            if (maybe.HasNoValue)
            {
                return null;
            }

            return selector(maybe.Value);
        }

        public static void Execute<T>(this Maybe<T> maybe, Action<T> action)
            where T : class
        {
            if (maybe.HasNoValue)
            {
                return;
            }

            action(maybe.Value);
        }
    }
}