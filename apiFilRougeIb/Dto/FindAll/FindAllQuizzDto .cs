using apiFilRougeIb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuizzDto : Quizz
    {

        public FindAllQuizzDto() { }


        public FindAllQuizzDto(string name, long user_idUser, long Theme_idTheme, string code,
            DateTime? dateClosed, int level_idlevel, int? timer,long? idQuizz = null)
            : base(name,user_idUser,Theme_idTheme,code,dateClosed,level_idlevel,timer,idQuizz)
        {
  
        }



    }
}
