using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Dto.Create
{
    public class CreateQuizzDto { 

        public string Name { get; set; }
        public long User_idUser { get; set; }
        public long Theme_idTheme { get; set; }
        public string Code { get; set; }
        public string? Comment { get; set; }
        public DateTime? DateFermeture { get; set; }
        public int? Timer { get; set; }
        public int Level_idLevel { get; set; }

        public CreateQuizzDto(string name, long user_idUser, long Theme_idTheme,int level_idlevel, string code, DateTime? dateFermeture, string? comment, int? timer, long? idQuizz = null)
        {
            this.Name = name;
            this.Level_idLevel = level_idlevel;
            this.User_idUser = user_idUser;
            this.Theme_idTheme = Theme_idTheme;
            this.Code = code;
            this.Comment = comment;
            this.DateFermeture = dateFermeture;
            this.Timer = timer;
        }
    }
}
