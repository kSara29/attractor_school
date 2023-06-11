namespace lab_work_28
{
    public class Program
    {
        static void Main(string[] args)
        {
            string playedPath = "playedWords.txt";
            bool exists = File.Exists(playedPath);
            if (!exists) File.Create(playedPath).Close();

            List<string> gameWords = ReadFile("game.txt");
            string randomGameWord = ChooseWord(gameWords);
            string encryptedWord = EncryptingWord(randomGameWord);

            bool game = true;
            int tries = 0;
            int counter = randomGameWord.Length + 5;

            Console.Write("Укажите уровень сложности:");
            int gameLevel = Convert.ToInt32(Console.ReadLine());
            
            encryptedWord = SetGameLevel(gameLevel, randomGameWord, encryptedWord, tries);
            
            while(game)
            {
                if(counter == 0)
                {
                    Console.WriteLine($"No, there is no such letter in this word. Your number of tries left: {counter}");
                    Console.WriteLine($"Game over! The word was '{randomGameWord}'");
                    File.AppendAllText(playedPath, randomGameWord + '\n');
                    game = false;
                    break;
                }

                tries ++;
                Console.WriteLine('\n' + encryptedWord);
                Console.Write("Введите букву: ");
                string enteredLetter = Console.ReadLine();
                Console.WriteLine($"У вас есть {counter - 1} попыток");
                encryptedWord = DecodingWord(encryptedWord, randomGameWord, enteredLetter, tries);

                if(encryptedWord == randomGameWord)
                {
                    game = false;
                    Console.WriteLine($"\nYou win! The word was '{randomGameWord}'. You won in {tries} tries.");
                    File.AppendAllText(playedPath, randomGameWord + '\n');
                }

                counter --;
            }
        }


        static string EncryptingWord(string randomGameWord)
        {
            string encryptedWord = "";
            foreach(char letter in randomGameWord) encryptedWord += '*';   
            return encryptedWord;
        }

        static string DecodingWord(string encryptedWord, string gameWord, string userLetter, int tries)
        {
            int counter = 0;
            if(gameWord.ToUpper() == userLetter.ToUpper()) return userLetter;
            else
            {
                for(int i = 0; i < gameWord.Length; i++)
                {
                    if(userLetter.ToUpper() == gameWord[i].ToString().ToUpper())
                    {
                        encryptedWord = encryptedWord.Substring(0, i) + gameWord[i].ToString() + encryptedWord.Substring(i + 1);
                        counter ++;
                    }
                    else if(userLetter.ToUpper() != gameWord[i].ToString().ToUpper() && i == gameWord.Length - 1 && counter == 0)
                    {
                        DrawHangman(gameWord.Length + 5, tries);
                        break;
                    }
                }
                return encryptedWord;
            }
        }

        static string ChooseWord(List<string> gameWords)
        {
            List<string> playedWords = ReadFile("playedWords.txt");
            gameWords.RemoveAll(playedWords.Contains);

            if(gameWords.Count == 0)
            {
                Console.WriteLine("Все слова разыграны");
                Environment.Exit(0);
                return null;
            }
            else
            {
                Random random = new Random();
                int randomNumber = random.Next(0, gameWords.Count);

                string randomGameWord = gameWords[randomNumber];           
                return randomGameWord;
            }
        }

        static List<string> ReadFile(string path)
        {
            List<string> gameWords = new List<string>();
            string[] words = File.ReadAllLines(path);

            foreach (string word in words) gameWords.Add(word);
            return gameWords;
        }

        static string SetGameLevel(int level, string gameWord, string encryptedWord, int tries)
        {
            Random rand = new Random();
            List<int> indexPosition = new List<int>();
            int randomIndexOfLetter;
            switch(level)
            {
                case(1):
                    while(indexPosition.Count < 3)
                    {
                        randomIndexOfLetter = rand.Next(0, gameWord.Length);
                        if(!indexPosition.Contains(randomIndexOfLetter))
                        {
                            indexPosition.Add(randomIndexOfLetter);
                            encryptedWord = DecodingWord(encryptedWord, gameWord, gameWord[randomIndexOfLetter].ToString(), tries);
                        }
                    }
                    break;
                case(2):
                    while(indexPosition.Count < 2)
                    {
                        randomIndexOfLetter = rand.Next(0, gameWord.Length);
                        if(!indexPosition.Contains(randomIndexOfLetter))
                        {
                            indexPosition.Add(randomIndexOfLetter);
                            encryptedWord = DecodingWord(encryptedWord, gameWord, gameWord[randomIndexOfLetter].ToString(), tries);
                        }
                    }
                    break;
                case(3):
                    while(indexPosition.Count < 1)
                    {
                        randomIndexOfLetter = rand.Next(0, gameWord.Length);
                        if(!indexPosition.Contains(randomIndexOfLetter))
                        {
                            indexPosition.Add(randomIndexOfLetter);
                            encryptedWord = DecodingWord(encryptedWord, gameWord, gameWord[randomIndexOfLetter].ToString(), tries);
                        }
                    }
                    break;
                case(4):
                    break;
            }
            
            return encryptedWord;
        }

        static void DrawHangman(int totalTriels, int userTries)
        {
            switch(totalTriels)
            {
                case(8):
                    switch(userTries)
                    {
                        case(1): Console.WriteLine("\n" + "|\\_____");
                            break;
                        case(2): Console.WriteLine("\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(3): Console.WriteLine("\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(4): Console.WriteLine("\n" + " _" + "\n" + "|/" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(5): Console.WriteLine(
@"
_______
|/      |
|
|
|
|
|\______
");
                            break;
                        case(6): Console.WriteLine(
@"
_______
|/      |
|       O
|
|
|
|\______
");
                            break;
                        case(7): Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|
|
|\______
");
                            break;
                        case(8): Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|      / \
|
|\______
");
                            break;
                    }
                    break;
                
                case(9):
                    switch(userTries)
                    {
                        case(1): 
                            Console.WriteLine("\n" + "|\\_____");
                            break;
                        case(2): Console.WriteLine("\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(3): Console.WriteLine("\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(4): Console.WriteLine("\n" + " _" + "\n" + "|/" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(5): Console.WriteLine(
@"
_______
|/      
|
|
|
|
|\______
");
                            break;
                        case(6): Console.WriteLine(
@"
_______
|/      |
|       
|
|
|
|\______
");
                            break;
                        case(7): Console.WriteLine(
@"
_______
|/      |
|       O
|      
|
|
|\______
");
                            break;
                        case(8): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|      
|
|\______
");
                            break;
                        case(9): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|      / \
|
|\______
");
                            break;
                    }
                    break;

                case(11):
                    switch(userTries)
                    {
                        case(1): 
                            Console.WriteLine("\n" + "|\\_____");
                            break;
                        case(2): Console.WriteLine("\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(3): Console.WriteLine("\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(4): Console.WriteLine("\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(5): Console.WriteLine("\n" + "|" + "\n"  + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(6): Console.WriteLine("\n" + "|/" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(7): Console.WriteLine(
@"
_______
|/      
|       
|      
|
|
|\______
");
                            break;
                        case(8): 
                        Console.WriteLine(
@"
_______
|/      |
|      
|      
|      
|
|\______
");
                            break;
                        case(9): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      
|      
|
|\______
");
                            break;
                        case(10): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|      
|
|\______
");
                            break;  
                        case(11): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|      / \
|
|\______
");
                            break;                                                      
                    }
                    break;  

                case(12):
                    switch(userTries)
                    {
                        case(1): 
                            Console.WriteLine("\n" + "|\\_____");
                            break;
                        case(2): Console.WriteLine("\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(3): Console.WriteLine("\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(4): Console.WriteLine("\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(5): Console.WriteLine("\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(6): Console.WriteLine("\n" + "|/" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|" + "\n" + "|\\_____");
                            break;
                        case(7): Console.WriteLine(
@"
_______
|/      
|       
|      
|
|
|\______
");
                            break;
                        case(8): 
                        Console.WriteLine(
@"
_______
|/      |
|      
|      
|      
|
|\______
");
                            break;
                        case(9): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      
|      
|
|\______
");
                            break;
                        case(10): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|      
|
|\______
");
                            break;  
                        case(11): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|      / 
|
|\______
");
                            break;    
                        case(12): 
                        Console.WriteLine(
@"
_______
|/      |
|       O
|      /0\
|      / \
|
|\______
");
                            break; 
                    }
                    break;              
            } 
        }
    }
}