using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateQuizzDto
    {
        public string Name { get; set; }
        public long User_idUser { get; set; }
        public long Theme_idTheme { get; set; }

        public CreateQuizzDto(string name, long user_idUser,   long Theme_idTheme)
        {
            this.Name = name;
            this.User_idUser = user_idUser;
            this.Theme_idTheme = Theme_idTheme; 
    }
    }
}
