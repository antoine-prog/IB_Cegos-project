using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllUsersJoinUserAnswersDto : FindAllUsersDto
    {

        public List<Models.UserAnswer> listUserAnswers { get; set; }
        public FindAllUsersJoinUserAnswersDto(FindAllUsersDto user) :
            base(user.FirstName, user.LastName, user.Username, user.Adress, user.Mail, user.Password,
                user.IsAdmin, user.IsCreator, user.IdUser)
        {
            this.listUserAnswers = new Repositories.UserRepository(new Utils.QueryBuilder()).FindAllUserAnswers((long)user.IdUser);
        }    
        

       
    }
    
}
