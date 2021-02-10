﻿using CrudUsingDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingDapper.IServices
{
    public interface IStudentService
    {
        Student Save(Student oStudent);
        List<Student> Gets();
        Student Get(int studenId);
        string Delete(int studenId);
    }
}
