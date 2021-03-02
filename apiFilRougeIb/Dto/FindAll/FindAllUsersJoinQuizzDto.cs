using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{

    public class FindAllUsersJoinQuizzDto : FindAllUsersDto
    {

        public List<Models.Quizz>? ListQuizz{ get; set; }
        public FindAllUsersJoinQuizzDto(FindAllUsersDto user) :
            base(user.FirstName, user.LastName, user.Username, user.Adress, user.Mail, user.Password, user.IsAdmin, user.IsCreator, user.IdUser)
        {
            this.ListQuizz = new Repositories.QuizzRepository(new Utils.QueryBuilder()).FindUser((long)user.IdUser);
            Console.WriteLine(this.ListQuizz.Count);
        }

    }
}


