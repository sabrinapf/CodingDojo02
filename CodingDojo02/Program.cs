/*
 * Coding Dojo 02
 * Sabrina Pfeiffer
 * wi16b012
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo02
{
    /* 
     * Class Stack of T
     * = GENERIC TYPE PARAMETER (= placeholder for a specific type that a client specifies when they instantiate a variable of the generic type)
     * fields: current element
     * methods: push, pop, peek
     */
    class Stack<T>
    {
        // field: current element
        private Element<T> currentElement;

        // methods
        public void Push(T item)
        {
            // first, check if the current element is empty => item would become the first item with no successor
            if (currentElement == null)
            {
                // currentElement becomes a new Element
                currentElement = new Element<T>();
                // the value of the item is stored @ the current element
                currentElement.CurrentElement = item;
                // the successor of the element is null
                currentElement.ElementSuccessor = null;
            }
            // if the current element is not empty
            else
            {
                // create a new temp. element
                Element<T> temp = new Element<T>();
                // the value of the item is stored @ the temp. element 
                temp.CurrentElement = item;
                // the value of the successing item (at the moment still the current element) is stored @ the successing element
                temp.ElementSuccessor = currentElement;
                // the current element is overwritten by the temp. element 
                currentElement = temp;
            }
        }
        // pop returns & deletes the current element
        public T Pop()
        {
            // first, check if current element is empty. Throw exception (null reference exception) if empty
            if (currentElement == null)
            {
                throw new NullReferenceException();
            }
            // if current element is not empty
            else
            {
                // create a new  variable (which has to be deleted), where value of the current element is stored
                T delete = currentElement.CurrentElement;
                // store successing value in current element => successing element becomes current element
                currentElement = currentElement.ElementSuccessor;
                // returns the deleted value
                return delete;
            }
        }
        // peek shows the current element (without deleting it)
        public T Peek()
        {
            // first, check if current element is empty. Throw exception (null reference exception) if empty
            if (currentElement == null)
            {
                throw new NullReferenceException();
            }
            // if current element is not empty, show current value
            else
            {
                return currentElement.CurrentElement;
            }
        }
    }
    /*
     * Class Element
     * fields: type, successor (to link the elements)
     * methods: get&set, get&setSuccessor 
     */
    class Element<T>
    {
        // fields
        // T = current Element
        private T currentElement;
        // Successor contains more information than just the successor (also: successor of successor, ...)
        private Element<T> elementSuccessor;

        // methods
        // get & set for element itself
        public T CurrentElement
        {
            get
            {
                return currentElement;
            }
            set
            {
                currentElement = value;
            }
        }
        // get & set for successor
        public Element<T> ElementSuccessor
        {
            get
            {
                return elementSuccessor;
            }
            set
            {
                elementSuccessor = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Testing
             */

            // int
            Stack<int> integers = new Stack<int>();
            integers.Push(1);
            Console.WriteLine("on top is {0}", integers.Peek());
            integers.Push(2);
            integers.Push(3);
            integers.Push(4);
            integers.Push(5);
            Console.WriteLine("on top is {0}", integers.Peek());
            Console.WriteLine("deleted: {0}", integers.Pop());
            Console.WriteLine("on top is {0}", integers.Peek());
            Console.WriteLine("deleted: {0}", integers.Pop());
            Console.WriteLine("on top is {0}", integers.Peek());
            Console.WriteLine();

            // string
            Stack<string> strings = new Stack<string>();
            strings.Push("test_01");
            Console.WriteLine("on top is {0}", strings.Peek());
            strings.Push("test_02");
            strings.Push("test_03");
            strings.Push("test_04");
            strings.Push("test_05");
            Console.WriteLine("on top is {0}", strings.Peek());
            Console.WriteLine("deleted: {0}", strings.Pop());
            Console.WriteLine("on top is {0}", strings.Peek());
            Console.WriteLine("deleted: {0}", strings.Pop());
            Console.WriteLine("on top is {0}", strings.Peek());
            Console.WriteLine();

            // object student
            Student student1 = new Student("Student 1", 1);
            Student student2 = new Student("Student 2", 2);
            Student student3 = new Student("Student 3", 3);
            Student student4 = new Student("Student 4", 4);
            Student student5 = new Student("Student 5", 5);

            Stack<Student> students = new Stack<Student>();
            students.Push(student1);
            Console.WriteLine("on top is {0}", students.Peek());
            students.Push(student2);
            students.Push(student3);
            students.Push(student4);
            students.Push(student5);
            Console.WriteLine("on top is {0}", students.Peek());
            Console.WriteLine("deleted: {0}", students.Pop());
            Console.WriteLine("on top is {0}", students.Peek());
            Console.WriteLine("deleted: {0}", students.Pop());
            Console.WriteLine("on top is {0}", students.Peek());
        }
    }
    // Class Student for testing
    class Student
    {
        private string name;
        private int id;

        // get & set
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        // constructor
        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
        // override ToString() method 
        public override string ToString()
        {
            return String.Format("{0}, {1}", Name, Id);
        }
    }
}
