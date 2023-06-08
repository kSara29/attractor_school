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
            Console.WriteLine($"У вас есть {counter} попыток");

            encryptedWord = SetGameLevel(gameLevel, randomGameWord, encryptedWord);
            
            while(game)
            {
                tries ++;
                Console.WriteLine('\n' + encryptedWord);
                Console.Write("Введите букву: ");
                string enteredLetter = Console.ReadLine();

                encryptedWord = DecodingWord(encryptedWord, randomGameWord, enteredLetter);

                if(encryptedWord == randomGameWord)
                {
                    game = false;
                    Console.WriteLine($"You win! The word was '{randomGameWord}'. You won in {tries} tries.");
                    File.AppendAllText(playedPath, randomGameWord + '\n');
                } 

                if(counter == 0)
                {
                    Console.WriteLine($"No, there is no such letter in this word. Your number of tries left: {counter}");
                    Console.WriteLine($"Game over! The word was '{randomGameWord}'");
                    File.AppendAllText(playedPath, randomGameWord + '\n');
                    game = false;
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

        static string DecodingWord(string encryptedWord, string gameWord, string userLetter)
        {
            if(gameWord.ToUpper() == userLetter.ToUpper()) return userLetter;
            else
            {
                for(int i = 0; i < gameWord.Length; i++)
                {
                    if(userLetter.ToUpper() == gameWord[i].ToString().ToUpper()) 
                        encryptedWord = encryptedWord.Substring(0, i) + gameWord[i].ToString() + encryptedWord.Substring(i + 1);
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

        static string SetGameLevel(int level, string gameWord, string encryptedWord)
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
                            encryptedWord = DecodingWord(encryptedWord, gameWord, gameWord[randomIndexOfLetter].ToString());
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
                            encryptedWord = DecodingWord(encryptedWord, gameWord, gameWord[randomIndexOfLetter].ToString());
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
                            encryptedWord = DecodingWord(encryptedWord, gameWord, gameWord[randomIndexOfLetter].ToString());
                        }
                    }
                    break;
                case(4):
                    break;
            }
            
            return encryptedWord;
        }
    }
}