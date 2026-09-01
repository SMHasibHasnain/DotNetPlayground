class Program
{
    public static void Main(string[] args)
    {
        Animal animal = new Animal();
        Sounds sounds = new Sounds();

        animal.Sound(sounds.Cat);
        animal.Sound(sounds.Tiger);
        animal.Sound(sounds.Cow);
    }
}

class Animal
{
    public delegate void AnimalSound();
    public void Sound(AnimalSound sound)
    {
        sound();
    }
}

class Sounds
{
    public void Tiger()
    {
        System.Console.WriteLine("Halum.... Halum....");
    }

    public void Cat()
    {
        System.Console.WriteLine("Meoww.... Meoww....");
    }

    public void Cow()
    {
        System.Console.WriteLine("Hambaa.... Hambaa....");
    }
}