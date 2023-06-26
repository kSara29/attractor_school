using Exam_4.Interfaces;


namespace Exam_4.Models
{
    class ChildCat : IStrategy
    {
        public Cat FeedCat(Cat cat)
        {
            cat.Satiety += 7;
            cat.Mood += 7;
            return cat;
        }

        public Cat HealCat(Cat cat)
        {
            cat.Health += 7;
            cat.Mood -= 3;
            cat.Satiety -= 3;
            return cat;
        }

        public Cat PlayWithCat(Cat cat)
        {
            cat.Health += 7;
            cat.Mood += 7;
            cat.Satiety -= 3;
            return cat;
        }
    }
}
