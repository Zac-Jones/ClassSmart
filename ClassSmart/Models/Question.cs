﻿using ClassSmart.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Models
{
    internal class Question
    {
        public int Id { get; set; }
        public QuestionType Type { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
