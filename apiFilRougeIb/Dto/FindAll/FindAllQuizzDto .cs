using apiFilRougeIb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.FindAll
{
    public class FindAllQuizzDto : Quizz
    {


        public FindAllQuizzDto(string name, long user_idUser, long Theme_idTheme, string code,
            DateTime? dateFermeture, int level_idlevel, string? comment, int? timer,
            long? idQuizz = null)
            : base(name,user_idUser,Theme_idTheme,code,dateFermeture,level_idlevel,comment,timer,idQuizz)
        {
  
        }


    }
}
