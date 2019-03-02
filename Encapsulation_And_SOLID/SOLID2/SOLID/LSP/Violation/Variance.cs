namespace SOLID.LSP.Violation
{

    class Animal { }

    class Dog : Animal { }

    class Cat : Animal { }            

    public interface IPoppable<out T>
    {
        T Pop();
    }

    public interface IPushable<in T>
    {
        void Push(T val);
    }

    public class Stack<T> : IPoppable<T>, IPushable<T>
    {
        private int position;
        readonly T[] data = new T[100];
        public void Push(T obj)
        {
            data[position++] = obj;
        }

        public T Pop()
        {
            return data[--position];
        }
    }

    public class Amin
    {
        public static void Check()
        {
            var dogs = new Stack<Dog>();
            dogs.Push(new Dog());

            //IPoppable<Animal> animals = dogs;

            IPushable<Animal> animals = new Stack<Animal>();
            IPushable<Cat> cats = animals; //allowed
            cats.Push(new Cat());
            //Stack<Animal> animals = dogs;
        }
    }
}
