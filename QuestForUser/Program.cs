using System;

namespace QuestionsForUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = EnterUser();
            PrintUser(user);
            Console.ReadKey();

            static (string Name, string LastName, int Age, string[] PetName, string[] FavColors) EnterUser()
            {
                (string Name, string LastName, int Age, string[] PetName, string[] FavColors) User;
                Console.WriteLine("Введите свое имя");
                User.Name = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                User.LastName = Console.ReadLine();

                string age;
                int intage;
                do
                {
                    Console.WriteLine("Введите свой возраст");
                    age = Console.ReadLine();
                }
                while (CheckNum(age, out intage));
                User.Age = intage;

                User.PetName = HowManyPets(out User.PetName);
                User.FavColors = GetFavColors();
                return User;
            }
            static void PrintUser((string Name, string LastName, int Age, string[] PetName, string[] FavColors) User)
            {
                Console.WriteLine("Привет {0} {1}!", User.Name, User.LastName);
                Console.WriteLine("Тебе {0} лет", User.Age);
                if (User.PetName != null && User.PetName.Length != 0)
                {
                    Console.Write("Твоих питомцев зовут: ");
                    for (int i = 0; i < User.PetName.Length; i++)
                    {
                        Console.WriteLine(User.PetName[i]);
                    }
                }
                else
                {
                    Console.WriteLine("У вас нет питомцев");
                }


                Console.Write("Твои любимые цвета: ");
                for (int i = 0; i < User.FavColors.Length; i++)
                {
                    Console.WriteLine(User.FavColors[i]);
                }


            }
            static string[] GetFavColors()
            {
                string countFavColors;
                int countFavColorsOut;

                do
                {
                    Console.WriteLine("Сколько у вас любимых цветов?");
                    countFavColors = Console.ReadLine();
                }
                while (CheckNum(countFavColors, out countFavColorsOut));

                var arrayColors = SetArray(countFavColorsOut);
                return arrayColors;
            }
            static string[] HowManyPets(out string[] PetNames)
            {
                PetNames = null;
                string PetsCount;
                int PetsCountOut;

                Console.WriteLine("У вас есть питомцы? Да или Нет");
                var IsPet = Console.ReadLine();

                switch (IsPet)
                {
                    case "Да":
                        do
                        {
                            Console.WriteLine("Сколько у вас питомцев?");
                            PetsCount = Console.ReadLine();
                        }
                        while (CheckNum(PetsCount, out PetsCountOut));
                        PetNames = SetArray(PetsCountOut);
                        break;
                    case "Нет":
                        Console.WriteLine("Питомцев у вас нет");
                        break;
                    default:
                        Console.WriteLine("Введено некорректно. Попробуйте снова");
                        HowManyPets(out PetNames);
                        break;
                }
                return PetNames;
            }

            static bool CheckNum(string number, out int corrnumber)
            {
                if (int.TryParse(number, out int intnum))
                {
                    if (intnum > 0)
                    {
                        corrnumber = intnum;
                        return false;
                    }
                }
                {
                    corrnumber = 0;
                    return true;
                }
            }

            static string[] SetArray(int count)
            {
                var array = new string[count];
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine("Введите {0}", i + 1);
                    array[i] = Console.ReadLine();
                }
                return array;
            }
        }
    }
}
