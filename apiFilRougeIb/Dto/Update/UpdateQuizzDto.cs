using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Update
{
    public class UpdateQuizzDto
    {
        public string Name { get; set; }
        public long User_idUser { get; set; }

        public UpdateQuizzDto(string name, long user_idUser)
        {
            Name = name;
            User_idUser = user_idUser;
        }


    }
}
