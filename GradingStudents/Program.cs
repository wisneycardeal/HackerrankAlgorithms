using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingStudents {
    class Program {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] grades = new int[n];
            for (int i = 0; i < n; i++) {
                int grade = Convert.ToInt32(Console.ReadLine());
                if (grade < 38) {
                    grades[i] = grade;
                } else {
                    int newGrade = grade;
                    int dif = 5 - (grade % 5);
                    
                    if (dif < 3)
                        newGrade = grade + dif;
                    
                    grades[i] = newGrade;
                }
            }

            grades.ToList().ForEach(g => Console.WriteLine(g.ToString()));

            Console.ReadLine();
        }
    }
}
