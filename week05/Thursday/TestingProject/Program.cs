using System;
using System.Collections.Generic;
using System.Linq;
using Animals;
using FastAndFurious;
using People;

namespace TestingProject
{
	public class Program
	{
		private static void Main()
		{
			//TestCars();
			//TestAnimals();
			TestPeople();
		}

		private static void TestCars()
		{
			Car car = new Audi();

			Console.WriteLine("Is Audi eco friendly : {0}", car.IsEcoFriendly(false));

			car = new Volkswagen();

			Console.WriteLine();

			Console.WriteLine("Is Volkswagen eco friendly : {0}", car.IsEcoFriendly(false));

			Console.WriteLine("Volkswagen mileage: {0}", ((Volkswagen) car).GetMileage());
		}

		private static void TestAnimals()
		{
			var animals = new List<Animal> {new Cat(), new Dog(), new Crocodile(), new Owl(), new Shark()};


			foreach (var animal in animals.OfType<ILandAnimal>())
			{
				Console.WriteLine(animal.Greet());
			}
		}

		private static void TestPeople()
		{
			var people = new List<Person>() { new Adult(Gender.Male) , new Adult(Gender.Female) , new Child(Gender.Male) };

			foreach (var person in people)
			{
				Console.WriteLine(person.ToString());
			}
		}
	}
}