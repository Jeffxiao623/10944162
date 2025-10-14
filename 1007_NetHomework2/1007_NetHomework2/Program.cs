using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1007_NetHomework2
{
    public class Student
    {
        public int StudentId { get; set; }
        public int Chinese { get; set; }
        public int English { get; set; }
        public int Math { get; set; }

        public double CalculateIndividualAverage()
        {
            return (Chinese + English + Math) / 3.0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 在這裡貼上 Main 方法中的所有邏輯程式碼
            List<Student> students = new List<Student>();
            int studentId = -1;

            Console.WriteLine("--- 學生學號及成績輸入系統 ---");
            Console.WriteLine("輸入學號為 0 時結束輸入並計算結果。");
            Console.WriteLine("------------------------------");

            while (true)
            {
                try
                {
                    Console.Write("\n請輸入學號 (輸入 0 結束): ");
                    string idInput = Console.ReadLine();

                    if (!int.TryParse(idInput, out studentId))
                    {
                        Console.WriteLine("錯誤: 學號必須是數字。請重新輸入。");
                        continue;
                    }

                    if (studentId == 0)
                    {
                        break;
                    }

                    Console.Write("  國文成績: ");
                    int chinese = int.Parse(Console.ReadLine());

                    Console.Write("  英文成績: ");
                    int english = int.Parse(Console.ReadLine());

                    Console.Write("  數學成績: ");
                    int math = int.Parse(Console.ReadLine());

                    students.Add(new Student
                    {
                        StudentId = studentId,
                        Chinese = chinese,
                        English = english,
                        Math = math
                    });

                    Console.WriteLine($"-> 學號 {studentId} 的資料已儲存。");
                }
                catch (FormatException)
                {
                    Console.WriteLine("錯誤: 成績必須是數字。請重新輸入該學生的資料。");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"發生錯誤: {ex.Message}。請重新輸入。");
                }
            }

            Console.WriteLine("\n==================================");
            Console.WriteLine("       輸入結束，開始計算結果       ");
            Console.WriteLine("==================================");

            if (students.Count == 0)
            {
                Console.WriteLine("沒有輸入任何學生資料。");
                return;
            }

            Console.WriteLine("\n--- 個人平均成績 ---");
            Console.WriteLine("學號\t國文\t英文\t數學\t個人平均");
            Console.WriteLine("--------------------------------------");

            foreach (var student in students)
            {
                double average = student.CalculateIndividualAverage();
                Console.WriteLine($"{student.StudentId}\t{student.Chinese}\t{student.English}\t{student.Math}\t{average:F2}");
            }

            int totalStudents = students.Count;

            double totalChinese = students.Sum(s => s.Chinese);
            double totalEnglish = students.Sum(s => s.English);
            double totalMath = students.Sum(s => s.Math);

            double classAvgChinese = totalChinese / totalStudents;
            double classAvgEnglish = totalEnglish / totalStudents;
            double classAvgMath = totalMath / totalStudents;

            Console.WriteLine("\n--- 各科班級平均成績 ---");
            Console.WriteLine($"總學生人數: {totalStudents} 人");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"國文班級平均: {classAvgChinese:F2}");
            Console.WriteLine($"英文班級平均: {classAvgEnglish:F2}");
            Console.WriteLine($"數學班級平均: {classAvgMath:F2}");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("\n按任意鍵結束...");
            Console.ReadKey();
        }
    }
}
