﻿using ClassSmart.Forms.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSmart.Forms
{
    public partial class QuizAttemptForm : Form
    {
        public QuizAttemptForm(Models.Quiz quiz, ClassViewQuizzesForm classViewQuizzesForm)
        {
            InitializeComponent();
        }
    }
}
