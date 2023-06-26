using Exam_4.Interfaces;
using Exam_4.Models;
using System;

namespace Exam_4
{
    public class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Satiety { get; set; }
        public int Mood { get; set; }
        public int Health { get; set; }
        public int AvgLevel { get; set; }
        public bool IsCatAction { get; set; } = false;
        public Actions ActionsType { get; set; }
        private IStrategy _strategy;
        public string Strategy { get => _strategy.GetType().Name.ToString(); }

        Random random = new Random();

        public Cat( string name, int age, string strategy) 
        {
            Name = name;
            Age = age;
            Satiety = random.Next(20, 81);
            Mood = random.Next(20, 81);
            Health = random.Next(20, 81);
            AvgLevel = (Satiety + Mood + Health) / 3;

            switch (strategy)
            {
                case ("ChildCat"):
                    this._strategy = new ChildCat();
                    this.SetStrategy(new ChildCat());
                    break;

                case ("AdultCat"):
                    this._strategy = new AdultCat();
                    this.SetStrategy(new AdultCat());
                    break;

                case ("OldCat"):
                    this._strategy = new OldCat();
                    this.SetStrategy(new OldCat());
                    break;
            }
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void FeedCat()
        {
            this._strategy.FeedCat(this);
        }

        public void HealCat() 
        {
            this._strategy.HealCat(this);
        }

        public void PlayWithCat()
        {
            this._strategy.PlayWithCat(this);
        }
    }

    public enum Actions
    {
        feed, 
        play,
        heal
    }
}
