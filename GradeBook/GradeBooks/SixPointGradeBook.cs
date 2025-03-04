using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    //Dodanie klasy "SixPointGradeBook" dziedziczącej po klasie "BaseGradeBook".
    public class SixPointGradeBook : BaseGradeBook
    {
        //Tworzenie konstruktora "SixPointGradeBook" przyjmującego parametr "name" typu string, wywołującego konstruktor klasy bazowej z parametrem "name" oraz drugim parametrem "isWeighted", przypisującego wartość "Type" jako "GradeBookType.SixPoint".
        public SixPointGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.SixPoint;
        }
        //Nadpisywanie metody "GetLetterGrade" przyjmującej parametr "averageGrade" typu double, zwracającej wartość typu char.
        public override char GetLetterGrade(double averageGrade)
        {
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 95 to zwróć '6' -> celujący.
            if (averageGrade >= 95)
                return '6';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 85 to zwróć '5' -> bardzo dobry.
            if (averageGrade >= 85)
                return '5';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 75 to zwróć '4' -> dobry.
            if (averageGrade >= 75)
                return '4';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 65 to zwróć '3' -> dostateczny.
            if (averageGrade >= 65)
                return '3';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 55 to zwróć '2' -> dopuszczający.
            if (averageGrade >= 55)
                return '2';
            //Jeżeli żaden z powyższych warunków nie zostanie spełniony, zwróć '1' -> niedostateczny.
            else
                return '1';
        }
    }
}