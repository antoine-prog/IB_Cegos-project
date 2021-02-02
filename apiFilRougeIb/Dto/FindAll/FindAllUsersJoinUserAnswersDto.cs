using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllUsersJoinUserAnswersDto : FindAllUsersDto
    {
        public string ok;
        public List<Models.UserAnswer> listUserAnswers;
        public FindAllUsersJoinUserAnswersDto(FindAllUsersDto user) :
            base(user.FirstName, user.LastName, user.Username, user.Adress, user.Mail, user.Password, user.IsAdmin, user.IsCreator, user.Level_idLevel, user.IdUser)
        {
            this.ok = "ok";
            this.listUserAnswers = new Repositories.UserRepository(new Utils.QueryBuilder()).FindAllUserAnswers((long)user.IdUser);
            Console.WriteLine("Dans le constructeur :");
            this.Affichage();
        }

        public void Affichage()
        {
           foreach (Models.UserAnswer u in this.listUserAnswers)
            {
                Console.WriteLine(u.ToString());
            }
        }
    }
    
}
