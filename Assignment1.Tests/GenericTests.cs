using Assignment1;
using System;
using System.Collections.Generic;
using Xunit;

namespace Assignment1.Tests
{

    public class Person : IComparable<Person> {

        public Person(int age)  {
            Age = age;
        } 

        public int Age {get; set;}

        public int CompareTo(Person other) {

            if (other != null) 
                return Age.CompareTo(other.Age);

            throw new ArgumentException("Object is not a Person");
        }
    }

    public class Student : Person {

        public Student(int age) : base(age) {

        }
    }

    public class GenericTests
    {
        [Fact]
        public void GreaterCount_returns_3_with_5_elements() {

            Console.WriteLine("hit here!!");

            // Arrange
            List<Student> students = new List<Student>();

            for (int i = 1; i < 6; i++)
            {
                students.Add(new Student(i));
            }

            Student student = new Student(4);
            var expected = 3;

            // Act
            var count = Generics.GreaterCount<Student, Person>(students, student);

            // Assert
            Assert.Equal(count, expected);
        }
    }
}
