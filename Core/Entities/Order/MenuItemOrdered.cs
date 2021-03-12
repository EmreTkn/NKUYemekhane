

namespace Core.Entities.Order
{
    public class MenuItemOrdered
    {
       

        public MenuItemOrdered()
        {
            
        }

        public MenuItemOrdered(int menuItemId, string menuName, int menuDay, int menuMonth, int menuYear,string schoolName,string dinnerTime)
        {
            MenuItemId = menuItemId;
            MenuName = menuName;
            MenuDay = menuDay;
            MenuMonth = menuMonth;
            MenuYear = menuYear;
            SchoolName = schoolName;
            DinnerTime = dinnerTime;
        }
        public int MenuItemId { get; set; }
        public string MenuName { get; set; }
        public int MenuDay { get; set; }
        public int MenuMonth { get; set; }
        public int MenuYear { get; set; }
        public string SchoolName { get; set; }
        public string DinnerTime { get; set; }
    }
}
