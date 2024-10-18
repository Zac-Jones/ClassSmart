﻿using ClassSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSmart.Data.Repositories
{
    public interface IClassRepository
    {
        Class GetClassByTeacherId(int teacherId);
        void AddClass(Class newClass);
    }
}