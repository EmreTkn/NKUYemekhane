using Core.Entities;

namespace Core.Specification
{
    public class MenusWithDateAndIncludes : BaseSpecification<Menu>
    {
        public MenusWithDateAndIncludes(int id) :
            base(m=>m.Id==id)
        {
            AddInclude(m=>m.DinnerTime);
            AddInclude(m=>m.SchoolName);
        }

        public MenusWithDateAndIncludes(MenuSpecParams menuParams) : base(x=>
        (x.DinnerTimeId==menuParams.DinnerTimeId)&&
        (x.SchoolNameId==menuParams.SchoolNameId)&&
        (x.Month==menuParams.Month)&&
        (x.Year==menuParams.Year)&&
        (x.Holiday==false)
        )
        {
            AddInclude(m => m.DinnerTime);
            AddInclude(m => m.SchoolName);
            AddOrderBy(x => x.Day);
        }

        public MenusWithDateAndIncludes(int? schoolId,int? dinnerTimeId):base(x=>x.SchoolNameId==schoolId && x.DinnerTimeId==dinnerTimeId )
        {
            AddInclude(m => m.DinnerTime);
            AddInclude(m => m.SchoolName);
            AddOrderBy(x => x.Day);
        }
    }
}
