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
        public DateTime? DateClosed { get; set; }
        public int? Timer { get; set; }
        public int Level_idLevel { get; set; }

        public CreateQuizzDto(string name, long user_idUser, long theme_idTheme, string code, DateTime? dateClosed, int? timer, int level_idlevel)
        {
            this.Name = name;
            this.Level_idLevel = level_idlevel;
            this.User_idUser = user_idUser;
            this.Theme_idTheme = theme_idTheme;
            this.Code = code;
            this.DateClosed = dateClosed;
            this.Timer = timer;
        }
    }
}
