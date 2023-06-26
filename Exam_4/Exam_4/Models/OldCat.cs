using Exam_4.Interfaces;

namespace Exam_4.Models
{
    public class OldCat: IStrategy
    {
        public Cat FeedCat(Cat cat)
        {
            cat.Satiety += 4;
            cat.Mood += 4;
            return cat;
        }

        public Cat HealCat(Cat cat)
        {
            cat.Health += 4;
            cat.Mood -= 6;
            cat.Satiety -= 6;
            return cat;
        }

        public Cat PlayWithCat(Cat cat)
        {
            cat.Health += 4;
            cat.Mood += 4;
            cat.Satiety -= 6;
            return cat;
        }
    }
}
