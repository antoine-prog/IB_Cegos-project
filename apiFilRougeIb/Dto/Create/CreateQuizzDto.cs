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

        public CreateQuizzDto(string name, long user_idUser)
        {
            Name = name;
            User_idUser = user_idUser;
        }
    }
}
