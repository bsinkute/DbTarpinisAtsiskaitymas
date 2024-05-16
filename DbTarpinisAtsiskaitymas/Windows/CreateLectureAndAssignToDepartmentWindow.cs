﻿using DbTarpinisAtsiskaitymas.Helpers;
using DbTarpinisAtsiskaitymas.Interfaces;
using DbTarpinisAtsiskaitymas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTarpinisAtsiskaitymas.Windows
{
    public class CreateLectureAndAssignToDepartmentWindow
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly ILectureService _lectureService;

        public CreateLectureAndAssignToDepartmentWindow(IStudentService studentService, IDepartmentService departmentService, ILectureService lectureService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _lectureService = lectureService;
        }

        public async Task CreateLectureAndAssignToDepartment()
        {
            Console.Write("Enter lecture name: ");
            string lectureName = Console.ReadLine();

            var departments = await _departmentService.GetAllDepartments();
            var departmentId = ConsoleHelper.SelectDepartment(departments);
        }
    }
}