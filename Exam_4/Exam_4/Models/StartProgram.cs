using System;
using System.Collections.Generic;
using ConsoleTables;
using System.Linq;
using System.Data;
using System.Text;

namespace Exam_4
{
    public class StartProgram
    {
        public void Start()
        {
            JsonData data = new JsonData();
            List<Cat> listCats = data.GetProducts();
            
            while (true)
            {
                if (listCats.Count == 0)
                {
                    Console.Write("Список пуст! Вы можете добавить своего первого котика");
                    listCats = AddNewCat(data, listCats);
                }
                else
                {
                    DisplayCatsTable(listCats);
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("\t1: покормить");
                    Console.WriteLine("\t2: поиграть");
                    Console.WriteLine("\t3: к ветеринару");
                    Console.WriteLine("\t4: следующий день");
                    Console.WriteLine("\t5: завести нового питомца");
                    Console.WriteLine("\t6: сортировать таблицу");
                    Console.WriteLine("\t7: выход");
                    Console.Write("Ваш ответ: ");

                    string userChoiceString = Console.ReadLine();
                    bool eneterCheck = CheckEnter(userChoiceString);
                    while (!eneterCheck)
                    {
                        Console.Write("Введите число: ");
                        userChoiceString = Console.ReadLine();
                        eneterCheck = CheckEnter(userChoiceString);
                    }

                    int userChoice = Convert.ToInt32(userChoiceString);
                    switch (userChoice)
                    {
                        case 1:
                            listCats = FeedCat(listCats, data);
                            break;
                        case 2:
                            listCats = PlayWithCat(listCats, data);
                            break;
                        case 3:
                            listCats = HealCat(listCats, data);
                            break;
                        case 4:
                            listCats = NextDay(listCats, data);
                            break;
                        case 5:
                            AddNewCat(data, listCats);
                            break;
                        case 6:
                            listCats = SortTable(data, listCats);
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Write("Такого пункта не существует (1-7): ");
                            userChoiceString = Console.ReadLine();
                            eneterCheck = Check(userChoiceString, 1, 7);

                            while (!eneterCheck)
                            {
                                Console.Write("Должно быть число (1-6): ");
                                userChoiceString = Console.ReadLine();
                                eneterCheck = Check(userChoiceString, 1, 7);
                            }
                            userChoice = Convert.ToInt32(userChoiceString);
                            break;
                    }
                }
            }
        }

        public List<Cat> AddNewCat(JsonData data, List<Cat> listCats)
        {
            Console.Write("\nВведите имя: ");
            string newCatName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newCatName) || newCatName.Length < 3)
            {
                Console.WriteLine("Имя питомца не может оставаться пустым или быть короче 3 символов!");
                Console.Write("Введите имя: ");
                newCatName = Console.ReadLine();
            }

            Console.Write("Введите возраст: ");
            string newCatAgeString = Console.ReadLine();
            bool ageCheck = Check(newCatAgeString, 1, 18);

            while (!ageCheck)
            {
                Console.WriteLine("Должно быть число в диапазоне от 1 до 18");
                Console.Write("Введите возраст: ");
                newCatAgeString = Console.ReadLine();
                ageCheck = Check(newCatAgeString, 1, 18);
            }

            int newCatAge = Convert.ToInt32(newCatAgeString);

            Cat newCat = new Cat("", 0, "ChildCat");
            switch (newCatAge)
            {
                case int range when (range >= 1 && range <= 5):
                    newCat = new Cat(newCatName, newCatAge, "ChildCat");
                    break;

                case int range when (range >= 6 && range <= 10):
                    newCat = new Cat(newCatName, newCatAge, "AdultCat");
                    break;

                case int range when (range >= 11):
                    newCat = new Cat(newCatName, newCatAge, "OldCat");
                    break;
            }

            listCats.Add(newCat);
            data.SerializeTasks(listCats);
            return listCats;
        }

        public void DisplayCatsTable(List<Cat> listCats)
        {
            int index = listCats.Count;
            int count = index - index + 1;
            var table = new ConsoleTable("#", "имя", "возраст", "здоровье", "настроение", "сытость", "средний уровень");
            
            foreach (var cat in listCats)
            {
                if(cat.IsCatAction)
                {
                    switch(cat.ActionsType)
                    {
                        case Actions.play:
                            Console.WriteLine($"Вы играли с котом {cat.Name}");
                            break;
                        
                        case Actions.feed:
                            Console.WriteLine($"Вы кормили кота {cat.Name}");
                            break;

                        case Actions.heal:
                            Console.WriteLine($"Вы лечили кота {cat.Name}");
                            break;
                    }

                    table.AddRow(count, " * " + cat.Name, cat.Age, cat.Health, cat.Mood, cat.Satiety, cat.AvgLevel);
                }

                else
                    table.AddRow(count, cat.Name, cat.Age, cat.Health, cat.Mood, cat.Satiety, cat.AvgLevel);
                count++;
            }
            table.Write(Format.Alternative);
        }

        static Cat ChooseCat(List<Cat> listCats, JsonData jsonData)
        {
            List<Cat> selectedCats = new List<Cat>();
            Console.Write("\nВыберите кота: \n\t1. по имени \n\t2. по номеру\nВаш ответ: ");

            string userChoiceSelectionString = Console.ReadLine();
            bool сheck = Check(userChoiceSelectionString, 1, 2);

            while (!сheck)
            {
                Console.Write("Ваш ответ: ");
                userChoiceSelectionString = Console.ReadLine();
                сheck = Check(userChoiceSelectionString, 1, 2);
            }

            int userChoiceSelection = Convert.ToInt32(userChoiceSelectionString);

            Cat userChoiceCat = new Cat("", 0, "ChildCat"); 

            if (userChoiceSelection == 1)
            {
                Console.Write("Введите имя: ");
                string userEnteredName = Console.ReadLine();
                foreach(Cat cat in listCats)
                {
                    if (cat.Name.ToUpper().Equals(userEnteredName.ToUpper()))
                        selectedCats.Add(cat);
                }

                if(selectedCats.Count > 1)
                {
                    Console.Write($"Есть несколько котиков с таким именем (всего: {selectedCats.Count}). Выберите нужного по айди: ");
                    int userSelectedCatId = Convert.ToInt32(Console.ReadLine()) - 1;
                    userChoiceCat = listCats[userSelectedCatId];
                }
                else if(selectedCats.Count == 1)
                    userChoiceCat = selectedCats[0];
            }
            else
            {
                Console.Write("Введите номер кота: ");

                string userSelectedCatIdString = Console.ReadLine();
                bool сheckId = Check(userSelectedCatIdString, 1, listCats.Count);

                while (!сheckId)
                {
                    Console.Write("Ваш ответ: ");
                    userSelectedCatIdString = Console.ReadLine();
                    сheckId = Check(userSelectedCatIdString, 1, listCats.Count);
                }

                int userSelectedCatId = Convert.ToInt32(userSelectedCatIdString) - 1;
                userChoiceCat = listCats[userSelectedCatId];

            }

            bool checkName = true;
            while (checkName)
            {
                if (userChoiceCat.Name.Equals(""))
                {
                    Console.Write("Введите имя: ");
                    string userEnteredName = Console.ReadLine();
                    foreach (Cat cat in listCats)
                    {
                        if (cat.Name.ToUpper().Equals(userEnteredName.ToUpper()))
                            selectedCats.Add(cat);
                    }
                    if (selectedCats.Count > 1)
                    {
                        Console.Write($"Есть несколько котиков с таким именем (всего: {selectedCats.Count}). Выберите нужного по айди: ");
                        int userSelectedCatId = Convert.ToInt32(Console.ReadLine()) - 1;
                        userChoiceCat = listCats[userSelectedCatId];
                    }
                    else if (selectedCats.Count == 1)
                        userChoiceCat = selectedCats[0];
                }
                else checkName = false;
            }
            return userChoiceCat;
        }

        static List<Cat> FeedCat(List<Cat> listCats, JsonData jsonData)
        {
            Cat selectedCat = ChooseCat(listCats, jsonData);
            Random rand = new Random();
            int random = rand.Next(1, 101);
            bool isPoisen = false;

            if (random <= 25)
            {
                selectedCat = PoisenCat(selectedCat, jsonData);
                isPoisen = true;
                selectedCat.AvgLevel = (selectedCat.Satiety + selectedCat.Mood + selectedCat.Health) / 3;

                if (selectedCat.Health <= 0)
                {
                    Console.WriteLine($"Кот {selectedCat.Name} умер");
                    listCats.Remove(selectedCat);
                }
                jsonData.SerializeTasks(listCats);
                listCats = jsonData.GetProducts();
            }

            if (!selectedCat.IsCatAction && !isPoisen)
            {
                selectedCat.FeedCat();
                selectedCat.IsCatAction = true;
                selectedCat.ActionsType = Actions.feed;
                selectedCat.AvgLevel = (selectedCat.Satiety + selectedCat.Mood + selectedCat.Health) / 3;
                Console.WriteLine($"Вы покормили котика {selectedCat.Name}");
                jsonData.SerializeTasks(listCats);
                listCats = jsonData.GetProducts();
            }

            Console.WriteLine("\n");

            return listCats;
        }

        static List<Cat> PlayWithCat(List<Cat> listCats, JsonData jsonData)
        {
            Cat selectedCat = ChooseCat(listCats, jsonData);
            Random rand = new Random();
            int random = rand.Next(1, 101);
            bool isAccident = false;

            if (random <= 25)
            {
                selectedCat = AccidentCat(selectedCat, jsonData);
                isAccident = true;
                selectedCat.AvgLevel = (selectedCat.Satiety + selectedCat.Mood + selectedCat.Health) / 3;
                Console.WriteLine($"Кот {selectedCat.Name} умер");

                if (selectedCat.Health <= 0)
                {
                    listCats.Remove(selectedCat);
                    Console.WriteLine($"Кот {selectedCat.Name} умер");
                }
                jsonData.SerializeTasks(listCats);
                listCats = jsonData.GetProducts();
            }

            if (!selectedCat.IsCatAction && !isAccident)
            {
                selectedCat.PlayWithCat();
                selectedCat.IsCatAction = true;
                selectedCat.ActionsType = Actions.play;
                selectedCat.AvgLevel = (selectedCat.Satiety + selectedCat.Mood + selectedCat.Health) / 3;
                Console.WriteLine($"Вы поиграли с котиком {selectedCat.Name}");

                jsonData.SerializeTasks(listCats);
                listCats = jsonData.GetProducts();
            }

            Console.WriteLine("\n");

            return listCats;
        }

        static List<Cat> HealCat(List<Cat> listCats, JsonData jsonData)
        {
            Cat selectedCat = ChooseCat(listCats, jsonData);

            if (!selectedCat.IsCatAction)
            {
                selectedCat.HealCat();
                selectedCat.IsCatAction = true;
                selectedCat.ActionsType = Actions.heal;
                selectedCat.AvgLevel = (selectedCat.Satiety + selectedCat.Mood + selectedCat.Health) / 3;
                Console.WriteLine($"Вы полечили котика {selectedCat.Name}");

                jsonData.SerializeTasks(listCats);
                listCats = jsonData.GetProducts();
            }

            Console.WriteLine("\n");
            return listCats;
        }

        static List<Cat> NextDay(List<Cat> listCats, JsonData jsonData)
        {
            Console.WriteLine("\nНаступил следующий день...");
            Random random = new Random();
            foreach(Cat cat in listCats)
            {
                cat.Satiety -= random.Next(1,6);

                int moodRandom = random.Next(-3, 4);
                if(moodRandom >= 0)
                    cat.Mood -= moodRandom;
                else cat.Mood += moodRandom;

                int healthRandom = random.Next(-3, 4);
                if (healthRandom >= 0)
                    cat.Health -= healthRandom;
                else cat.Health += healthRandom;

                cat.AvgLevel = (cat.Satiety + cat.Mood + cat.Health) / 3;
                cat.IsCatAction = false;
            }

            jsonData.SerializeTasks(listCats);
            listCats = jsonData.GetProducts();

            return listCats;
        }

        static Cat PoisenCat(Cat selectedCat, JsonData jsonData)
        {
            selectedCat.Mood /= 2;
            selectedCat.Health /= 2;
            Console.WriteLine("Кот отравился");
            return selectedCat;
        }

        static Cat AccidentCat(Cat selectedCat, JsonData jsonData)
        {
            selectedCat.Mood /= 2;
            selectedCat.Health /= 2;

            Console.WriteLine("Кот травмировался");
            return selectedCat;
        }

        public bool CheckEnter(string enteredString)
        {
            int intCheck;
            bool isNumber = int.TryParse(enteredString, out intCheck);
            return isNumber;
        }

        static bool Check(string ageString, int minValue, int maxValue)
        {
            bool ageCheckInt = CheckInt(ageString);
            if (ageCheckInt)
            {
                bool ageCheckRange = CheckRange(Convert.ToInt32(ageString), minValue, maxValue);
                if (ageCheckRange)
                    return true;
                return false;
            }
            return false;
        }


        static bool CheckInt(string ageString)
        {
            int ageCheck;
            bool isNumber = int.TryParse(ageString, out ageCheck);
            return isNumber;
        }

        static bool CheckRange(int age, int minValue, int maxValue)
        {
            if (age < minValue || age > maxValue)
                return false;
            return true;
        }

        public List<Cat> SortTable(JsonData jsonData, List<Cat> listCats)
        {
            Console.WriteLine("Сортировать по:\n\t1. имени \n\t2. возрасту \n\t3. здоровью \n\t4. настроению \n\t5. сытости \n\t6. среднему уровню");
            Console.Write("Ваш ответ: ");
            string userSortParameter = Console.ReadLine();
            bool check = Check(userSortParameter, 1, 6);

            while (!check)
            {
                Console.WriteLine("Должно быть число в диапазоне от 1 до 6");
                Console.Write("Введите возраст: ");
                userSortParameter = Console.ReadLine();
                check = Check(userSortParameter, 1, 6);
            }

            int sortParameter = Convert.ToInt32(userSortParameter);

            switch(sortParameter)
            {
                case 1:
                    listCats = listCats.OrderByDescending(t => t.Name).ToList();
                    break;
                case 2:
                    listCats = listCats.OrderByDescending(t => t.Age).ToList();
                    break;
                case 3:
                    listCats = listCats.OrderByDescending(t => t.Health).ToList();
                    break;
                case 4:
                    listCats = listCats.OrderByDescending(t => t.Mood).ToList();
                    break;
                case 5:
                    listCats = listCats.OrderByDescending(t => t.Satiety).ToList();
                    break;
                case 6:
                    listCats = listCats.OrderByDescending(t => t.AvgLevel).ToList();
                    break;
                default:
                    Console.Write("Такого пункта не существует. Выберите один из предложенных: ");
                    userSortParameter = Console.ReadLine();
                    check = Check(userSortParameter, 1, 6);

                    while (!check)
                    {
                        Console.Write("Должно быть число в диапазоне от 1 до 6: ");
                        userSortParameter = Console.ReadLine();
                        check = Check(userSortParameter, 1, 6);
                    }
                    sortParameter = Convert.ToInt32(userSortParameter);
                    break;
            }

            jsonData.SerializeTasks(listCats);
            listCats = jsonData.GetProducts();

            return listCats;
        }
    }
}
