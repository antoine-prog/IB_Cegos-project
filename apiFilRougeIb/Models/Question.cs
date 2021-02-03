﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Models
{
    public class Question

    {

        public long? IdQuestion { get; set; }
        public string Title { get; set; }
        public long Level_idLevel { get; set; }

        public Question() { }

        public Question(string title, long level_idLevel, long? idQuestion = null)
        {
            IdQuestion = idQuestion;
            Title = title;
            
            Level_idLevel = level_idLevel;


        }

    }
}
