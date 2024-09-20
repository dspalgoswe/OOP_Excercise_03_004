using System;
using System.Collections.Generic;

namespace OOP_Excercise_03_004;


// 1. Skapa Stats() i klass Animal. Return type: string
public abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }

    protected Animal(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
    }

    // 3. Skapa Stats(). Gör abstrakt f subklasser och override
    public abstract string Stats();

    public abstract void DoSound();
}

// Subklasser m override f Stats()
public class Horse : Animal
{
    public double Height { get; set; }

    public Horse(string name, double weight, int age, double height)
        : base(name, weight, age)
    {
        Height = height;
    }

    // 2. Override f Stats()
    public override string Stats()
    {
        return $"Horse: Name = {Name}, Weight = {Weight}, Age = {Age}, Height = {Height}";
    }

    public override void DoSound()
    {
        Console.WriteLine("Yiaaahaaa!");
    }
}

public class Dog : Animal, IPerson
{
    public string Breed { get; set; }

    public Dog(string name, double weight, int age, string breed)
        : base(name, weight, age)
    {
        Breed = breed;
    }

    // 2. Override för Stats()
    public override string Stats()
    {
        return $"Dog: Name = {Name}, Weight = {Weight}, Age = {Age}, Breed = {Breed}";
    }

    public override void DoSound()
    {
        Console.WriteLine("Voff!");
    }

    // 15. Skapa en ny metod i klassen Dog
    public string DogSpecificMethod()
    {
        return "Unik metod för hund.";
    }

    public void Talk()
    {
        Console.WriteLine("Vov! Vov!");
    }
}

public class Cat : Animal
{
    public string Color { get; set; }

    public Cat(string name, double weight, int age, string color)
        : base(name, weight, age)
    {
        Color = color;
    }

    public override string Stats()
    {
        return $"Cat: Name = {Name}, Weight = {Weight}, Age = {Age}, Color = {Color}";
    }

    public override void DoSound()
    {
        Console.WriteLine("Mjau!");
    }
}

// 10. Gränssnittet IPerson
public interface IPerson
{
    void Talk();
}

// För huvudprogrammet
class Program
{
    static void Main(string[] args)
    {
        // 3. Skapa lista Animals i Program, ta emot djur
        List<Animal> animals = new List<Animal>
        {
            new Horse("Blixten", 500, 5, 1.6),
            new Dog("Fido", 30, 4, "Tax"),
            new Cat("Misse", 8, 3, "Svart"),
            new Dog("Korven", 25, 2, "Beagle")
        };

        // 5. Skriv djur i listan m h a foreach
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.Stats()); // 11. Skriv ut samtliga Animals Stats
            animal.DoSound(); // 6. Anropa Animals Sound()

            // 7. Check om djur är IPerson
            if (animal is IPerson person)
            {
                person.Talk(); // Anropa Talk()
            }
        }

        // 8. Lista för hundar
        List<Dog> dogs = new List<Dog>();

        // 9. F: Försök att lägga till en häst i listan av hundar.
        // Går ej pga att List<Dog> bara kan ha objekt av typ Dog.

        // 10. F: Typ av lista om alla klasser skall kunna lagras tillsammans?
        // Listan av typen List<Animal>.

        // 13. F: Förklara:
        // Loopa genom alla djur, sedan Stats(), DoSound() och Talk() metoder nør det bær ske.

        // 14. Skrv ut Stats() för hundar via xtrl av typ
        foreach (var animal in animals)
        {
            if (animal is Dog dog)
            {
                Console.WriteLine(dog.Stats());
            }
        }

        // 18. Skriv ut DogSpecificMethod f Dog via foreach
        foreach (var animal in animals)
        {
            if (animal is Dog dog)
            {
                Console.WriteLine(dog.DogSpecificMethod());
            }
        }
    }
}