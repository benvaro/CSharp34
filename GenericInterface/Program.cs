using System;

namespace GenericInterface
{
    class Program
    {
        interface IStack<T> // узагальнений інтерфейс
        {
            void Push(T element);
            T Pop();
            bool IsEmpty { get; }
            T Top();
        }

        class Stack<T> : IStack<T>
        {
            T[] stack;
            int top = -1;
            int size = 10;

            public Stack()
            {
                stack = new T[size];
            }
            //public bool IsEmpty => top == -1;
            public bool IsEmpty
            {
                get
                {
                    return top == -1;
                }
            }
            public T Pop()
            {
                if (!this.IsEmpty)
                    return stack[top--];
                else
                    throw new Exception("Stack is empty");
            }

            public void Push(T element)
            {
                if (top == size - 1)
                {
                    size *= 2;
                    Array.Resize(ref stack, size);
                }
                stack[++top] = element;
            }

            public T Top()
            {
                if (this.IsEmpty)
                    throw new Exception("Stack is empty");
                return stack[top];
            }
        }
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string[] words = { "red", "green", "blue", "black", "magenta", "olive" };
            foreach (var item in words)
            {
                stack.Push(item);
            }
            Console.WriteLine($"Top: {stack.Top()}");
            Console.WriteLine("Remove from stack");
            while (!stack.IsEmpty)
            {
                Console.WriteLine(stack.Pop());
            }
            try
            {
                Console.WriteLine(stack.Top());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
