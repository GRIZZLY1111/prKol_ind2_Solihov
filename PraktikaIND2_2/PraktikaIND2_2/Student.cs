using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktikaIND2_2
{
    class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string GroupNumber { get; set; }
        public int[] Grades { get; set; }
        //Проверка на сдачу экзамена
        public bool IsSessionPassed()
        {
            return Grades.All(grade => grade >= 3);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, Группа: {GroupNumber}, Оценки: {string.Join(", ", Grades)}";
        }
    }
}
