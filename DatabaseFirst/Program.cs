using DatabaseFirst.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwindDbContext dbContext = new NorthwindDbContext();

            //var Categories = dbContext.Categories.FromSqlRaw("select * from Categories");
            //int Count = 2;

            //var Categories = dbContext.Categories.FromSqlInterpolated($"select top({Count})* from Categories");

            //foreach (var item in Categories)
            //    Console.WriteLine(item);

            //dbContext.Database.ExecuteSqlRaw("update Categories set CategoryName = 'NewCategory'  where CategoryID = 2");
            //dbContext.Database.ExecuteSqlInterpolated($"update Categories set CategoryName = 'NewCategory'  where CategoryID = 2");

        }
    }
}
