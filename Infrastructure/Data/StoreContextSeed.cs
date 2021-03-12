using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
      
      
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var menus = context.Menus.ToList();
                var mounth = DateTimeOffset.Now.Month;
                var year = DateTimeOffset.Now.Year;
                
                if (!menus.Any())
                {
                    await CalculateDaysAsync(context, mounth, year,1,1);
                }

                if ((menus.Any(x=>x.Month!=mounth))&&(!menus.Any(x=>x.Month==mounth)))
                {
                    await CalculateDaysAsync(context, mounth, year,1,1);
                }


            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(e.Message);
            }
        }

        public static async Task CalculateDaysAsync(StoreContext context, int mounth, int year,int dinnerTimeId,int schoolId)
        {
            if (mounth == 4 || mounth == 6 || mounth == 9 || mounth == 11)
            {
               
                for (int i = 1; i <= 30; i++)
                {
                    var item = new Menu
                    {
                        DinnerTimeId = dinnerTimeId,
                        Month = mounth,
                        Day = i,
                        Year = year,
                        SchoolNameId = schoolId,
                        Price = 10
                    };
                    DateTime date = new DateTime(item.Year, item.Month, item.Day);
                    var keko = (int)date.DayOfWeek;
                    if (keko == 6 || keko == 0)
                    {
                        item.Holiday = true;
                    }

                    context.Menus.Add(item);
                }
                await context.SaveChangesAsync();
                
            }
            else if (mounth == 2)
            {
                for (int i = 1; i <= 28; i++)
                {
                    var item = new Menu
                    {
                        DinnerTimeId = dinnerTimeId,
                        Month = mounth,
                        Day = i,
                        Year = year,
                        SchoolNameId = schoolId,
                        Price = 10,
                        FoodFirst="Pilav",
                        FoodSecond="Kuru Fasulye",
                        FoodThird="Ayran",
                        FoodFourth="Salata"
                    };
                    DateTime date = new DateTime(item.Year, item.Month, item.Day);
                    var keko = (int)date.DayOfWeek;
                    if (keko==6||keko==0)
                    {
                        item.Holiday = true;
                    }
                    context.Menus.Add(item);
                }
                await context.SaveChangesAsync();
            }
            else
            {
                for (int i = 1; i <= 31; i++)
                {
                    var item = new Menu
                    {
                        DinnerTimeId = dinnerTimeId,
                        Month = mounth,
                        Day = i,
                        Year = year,
                        SchoolNameId = schoolId,
                        Price = 10
                    };
                    DateTime date = new DateTime(item.Year, item.Month, item.Day);
                    var keko = (int)date.DayOfWeek;
                    if (keko == 6 || keko == 0)
                    {
                        item.Holiday = true;
                    }
                    context.Menus.Add(item);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
