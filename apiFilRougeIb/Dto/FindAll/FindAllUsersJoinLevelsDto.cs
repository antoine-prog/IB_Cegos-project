using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllUsersJoinLevelsDto : FindAllUsersDto
    {
        public string Level { get; set; }
        public FindAllUsersJoinLevelsDto(FindAllUsersDto user) : 
            base(user.FirstName, user.LastName, user.Username, user.Adress, user.Mail, user.Password, user.IsAdmin, user.IsCreator,user. Level_idLevel,user. IdUser)
        {
            this.Level = new Repositories.LevelRepository(new Utils.QueryBuilder()).Find(Level_idLevel).Title;
        }
    }
}
