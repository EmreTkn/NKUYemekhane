

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string SchoolNumber { get; set; }
        public string Token { get; set; }

    }
}
