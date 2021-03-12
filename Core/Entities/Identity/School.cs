using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Identity
{
    public class School
    {
        public int Id { get; set; }
        public int SchoolNameId { get; set; }
        public int DinnerTimeId { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
