using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PraktikaIND2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Студенты.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден!");
                Console.ReadKey();
                return;
            }
            Queue<Student> allStudents = new Queue<Student>();
            // Чтение данных из файла
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 7) continue;

                var student = new Student
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    MiddleName = parts[2],
                    GroupNumber = parts[3],
                    Grades = new[] { int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]) }
                };
                allStudents.Enqueue(student);
            }
            // Разделение студентов на две группы с сохранением порядка
            var successfulStudents = allStudents.Where(s => s.IsSessionPassed());
            var otherStudents = allStudents.Where(s => !s.IsSessionPassed());
            // Объединение последовательностей и вывод
            var result = successfulStudents.Concat(otherStudents);
            Console.WriteLine("Результат:");
            foreach (var student in result)
            {
                Console.WriteLine(student);
            }
            Console.ReadKey();
        }
    }
}
