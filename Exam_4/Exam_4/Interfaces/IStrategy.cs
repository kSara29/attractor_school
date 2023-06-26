using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_4.Interfaces
{
    public interface IStrategy
    {
        Cat FeedCat(Cat cat);
        Cat HealCat(Cat cat);
        Cat PlayWithCat(Cat cat);
    }
}
