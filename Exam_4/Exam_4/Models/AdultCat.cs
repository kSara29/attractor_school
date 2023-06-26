using Exam_4.Interfaces;


namespace Exam_4.Models
{
    public class AdultCat: IStrategy
    {
        public Cat FeedCat(Cat cat)
        {
            cat.Satiety += 5;
            cat.Mood += 5;
            return cat;
        }

        public Cat HealCat(Cat cat)
        {
            cat.Health += 5;
            cat.Mood -= 5;
            cat.Satiety -= 5;
            return cat;
        }

        public Cat PlayWithCat(Cat cat)
        {
            cat.Health += 5;
            cat.Mood += 5;
            cat.Satiety -= 5;
            return cat;
        }
    }
}
