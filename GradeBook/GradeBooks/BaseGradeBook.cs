﻿using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeBook.GradeBooks
{
    //Nadajemy wartość abstrakcyjną klasie "BaseGradeBook".
    public abstract class BaseGradeBook
    {
        public string Name { get; set; }

        //Dodawanie nowej własciowści "Type" do klasy "BaseGradeBook" typu "GradeBookType", modyfikator dostępu "public".
        public GradeBookType Type { get; set; }

        //Dodawanie nowej własciowści "IsWeighted" do klasy "BaseGradeBook" typu "bool", modyfikator dostępu "public".
        public bool IsWeighted { get; set; }
        
        public List<Student> Students { get; set; }

        public BaseGradeBook(string name, bool isWeighted)
        {
            Name = name;
            //Poprawne przypisanie wartości IsWeighted do własciwości "IsWeighted" na podstawie przekazywanego parametru "IsWeighted".
            IsWeighted = isWeighted;
            Students = new List<Student>();

        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
                throw new ArgumentException("A Name is required to add a student to a gradebook.");
            Students.Add(student);
            //Wywołanie metody Save() służy automatycznemu zapisywaniu po dodaniu ucznia. 
            Save();
        }

        public void RemoveStudent(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A Name is required to remove a student from a gradebook.");
            var student = Students.FirstOrDefault(e => e.Name == name);
            if (student == null)
            {
                Console.WriteLine("Student {0} was not found, try again.", name);
                return;
            }
            Students.Remove(student);
            //Wywołanie metody Save() służy automatycznemu zapisywaniu po usunięciu ucznia.
            Save();
        }

        public void AddGrade(string name, double score)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A Name is required to add a grade to a student.");
            var student = Students.FirstOrDefault(e => e.Name == name);
            if (student == null)
            {
                Console.WriteLine("Student {0} was not found, try again.", name);
                return;
            }
            student.AddGrade(score);
            //Wywołanie metody Save() służy automatycznemu zapisywaniu po dodaniu oceny.
            Save();
        }

        public void RemoveGrade(string name, double score)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A Name is required to remove a grade from a student.");
            var student = Students.FirstOrDefault(e => e.Name == name);
            if (student == null)
            {
                Console.WriteLine("Student {0} was not found, try again.", name);
                return;
            }
            student.RemoveGrade(score);
            //Wywołanie metody Save() służy automatycznemu zapisywaniu po usunięciu oceny.
            Save();
        }

        public void ListStudents()
        {
            foreach (var student in Students)
            {
                Console.WriteLine("{0} : {1} : {2}", student.Name, student.Type, student.Enrollment);
            }
        }

        public static BaseGradeBook Load(string name)
        {
            if (!File.Exists(name + ".gdbk"))
            {
                Console.WriteLine("Gradebook could not be found.");
                return null;
            }

            using (var file = new FileStream(name + ".gdbk", FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(file))
                {
                    var json = reader.ReadToEnd();
                    return ConvertToGradeBook(json);
                }
            }
        }

        public void Save()
        {
            using (var file = new FileStream(Name + ".gdbk", FileMode.Create, FileAccess.Write))
            {
                using (var writer = new StreamWriter(file))
                {
                    var json = JsonConvert.SerializeObject(this);
                    writer.Write(json);
                }
            }
        }
        //Aktualizacja metody "GetGPA" przyjmującej dwa parametry: "letterGrade" typu "char" oraz "studentType" typu "StudentType", zwracającej wartość typu double.
        public virtual double GetGPA(char letterGrade, StudentType studentType)
        {
            //Dodanie zmiennej "gpa" typu double, przypisanie wartości 0.
            var gpa = 0;

            //Instrukcja switch, która sprawdza wartość zmiennej "letterGrade".
            switch (letterGrade)
            {
                //Jeżeli wartość zmiennej "letterGrade" to 'A', to przypisz do zmiennej "gpa" wartość 4.
                case 'A':
                    gpa = 4;
                    break;
                //Jeżeli wartość zmiennej "letterGrade" to 'B', to przypisz do zmiennej "gpa" wartość 3.
                case 'B':
                    gpa = 3;
                    break;
                //Jeżeli wartość zmiennej "letterGrade" to 'C', to przypisz do zmiennej "gpa" wartość 2.
                case 'C':
                    gpa = 2;
                    break;
                //Jeżeli wartość zmiennej "letterGrade" to 'D', to przypisz do zmiennej "gpa" wartość 1.
                case 'D':
                    gpa = 1;
                    break;
                //Jeżeli wartość zmiennej "letterGrade" to 'F', to przypisz do zmiennej "gpa" wartość 0.
                case 'F':
                    gpa = 0;
                    break;
            }

            //Sprawdzenie czy wartość zmiennej "IsWeighted" to "true" oraz czy wartość zmiennej "studentType" to "Honors" lub "DualEnrolled".
            if (IsWeighted && (studentType == StudentType.Honors || studentType == StudentType.DualEnrolled))
            {
                //Zwiększenie wartości zmiennej "gpa" o 1.
                gpa++;
            }
            //Zwrócenie wartości zmiennej "gpa".
            return gpa;
        }

        public virtual void CalculateStatistics()
        {
            var allStudentsPoints = 0d;
            var campusPoints = 0d;
            var statePoints = 0d;
            var nationalPoints = 0d;
            var internationalPoints = 0d;
            var standardPoints = 0d;
            var honorPoints = 0d;
            var dualEnrolledPoints = 0d;

            foreach (var student in Students)
            {
                student.LetterGrade = GetLetterGrade(student.AverageGrade);
                student.GPA = GetGPA(student.LetterGrade, student.Type);

                Console.WriteLine("{0} ({1}:{2}) GPA: {3}.", student.Name, student.LetterGrade, student.AverageGrade, student.GPA);
                allStudentsPoints += student.AverageGrade;

                switch (student.Enrollment)
                {
                    case EnrollmentType.Campus:
                        campusPoints += student.AverageGrade;
                        break;
                    case EnrollmentType.State:
                        statePoints += student.AverageGrade;
                        break;
                    case EnrollmentType.National:
                        nationalPoints += student.AverageGrade;
                        break;
                    case EnrollmentType.International:
                        internationalPoints += student.AverageGrade;
                        break;
                }

                switch (student.Type)
                {
                    case StudentType.Standard:
                        standardPoints += student.AverageGrade;
                        break;
                    case StudentType.Honors:
                        honorPoints += student.AverageGrade;
                        break;
                    case StudentType.DualEnrolled:
                        dualEnrolledPoints += student.AverageGrade;
                        break;
                }
            }

            // #todo refactor into it's own method with calculations performed here
            Console.WriteLine("Average Grade of all students is " + (allStudentsPoints / Students.Count));
            if (campusPoints != 0)
                Console.WriteLine("Average for only local students is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.Campus).Count()));
            if (statePoints != 0)
                Console.WriteLine("Average for only state students (excluding local) is " + (statePoints / Students.Where(e => e.Enrollment == EnrollmentType.State).Count()));
            if (nationalPoints != 0)
                Console.WriteLine("Average for only national students (excluding state and local) is " + (nationalPoints / Students.Where(e => e.Enrollment == EnrollmentType.National).Count()));
            if (internationalPoints != 0)
                Console.WriteLine("Average for only international students is " + (internationalPoints / Students.Where(e => e.Enrollment == EnrollmentType.International).Count()));
            if (standardPoints != 0)
                Console.WriteLine("Average for students excluding honors and dual enrollment is " + (standardPoints / Students.Where(e => e.Type == StudentType.Standard).Count()));
            if (honorPoints != 0)
                Console.WriteLine("Average for only honors students is " + (honorPoints / Students.Where(e => e.Type == StudentType.Honors).Count()));
            if (dualEnrolledPoints != 0)
                Console.WriteLine("Average for only dual enrolled students is " + (dualEnrolledPoints / Students.Where(e => e.Type == StudentType.DualEnrolled).Count()));
        }

        public virtual void CalculateStudentStatistics(string name)
        {
            var student = Students.FirstOrDefault(e => e.Name == name);
            student.LetterGrade = GetLetterGrade(student.AverageGrade);
            student.GPA = GetGPA(student.LetterGrade, student.Type);

            Console.WriteLine("{0} ({1}:{2}) GPA: {3}.", student.Name, student.LetterGrade, student.AverageGrade, student.GPA);
            Console.WriteLine();
            Console.WriteLine("Grades:");
            foreach (var grade in student.Grades)
            {
                Console.WriteLine(grade);
            }
        }

        public virtual char GetLetterGrade(double averageGrade)
        {
            if (averageGrade >= 90)
                return 'A';
            else if (averageGrade >= 80)
                return 'B';
            else if (averageGrade >= 70)
                return 'C';
            else if (averageGrade >= 60)
                return 'D';
            else
                return 'F';
        }

        /// <summary>
        ///     Converts json to the appropriate gradebook type.
        ///     Note: This method contains code that is not recommended practice.
        ///     This has been used as a compromise to avoid adding additional complexity to the learner.
        /// </summary>
        /// <returns>The to gradebook.</returns>
        /// <param name="json">Json.</param>
        public static dynamic ConvertToGradeBook(string json)
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            var jobject = JsonConvert.DeserializeObject<JObject>(json);
            var gradeBookType = jobject.Property("Type")?.Value?.ToString();

            // Check if StandardGradeBook exists
            if ((from assembly in AppDomain.CurrentDomain.GetAssemblies()
                 from type in assembly.GetTypes()
                 where type.FullName == "GradeBook.GradeBooks.StandardGradeBook"
                 select type).FirstOrDefault() == null)
                gradeBookType = "Base";
            else
            {
                if (string.IsNullOrEmpty(gradeBookType))
                    gradeBookType = "Standard";
                else
                    gradeBookType = Enum.GetName(gradebookEnum, int.Parse(gradeBookType));
            }

            // Get GradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks." + gradeBookType + "GradeBook"
                             select type).FirstOrDefault();


            // Protection code
            if (gradebook == null)
                gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.StandardGradeBook"
                             select type).FirstOrDefault();
            
            return JsonConvert.DeserializeObject(json, gradebook);
        }
    }
}
