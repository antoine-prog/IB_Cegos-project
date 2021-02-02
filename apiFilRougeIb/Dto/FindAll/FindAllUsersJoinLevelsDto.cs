using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllUsersJoinLevelsDto : FindAllUsersDto
    {
        public string Level { get; set; }
        public FindAllUsersJoinLevelsDto(string firstName, string lastName, string username, string adress, string mail, string password, bool isAdmin, bool isCreator, long level_idLevel, long? idUser = null) : 
            base(firstName, lastName, username, adress, mail, password, isAdmin, isCreator, level_idLevel, idUser)
        {
            this.Level = new Repositories.LevelRepository(new Utils.QueryBuilder()).Find(Level_idLevel).Title;
        }
    }
}
