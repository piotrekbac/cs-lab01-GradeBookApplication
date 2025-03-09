using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    //Dodanie klasy "ESNUGradeBook" dziedziczącej po klasie "BaseGradeBook".
    public class ESNUGradeBook : BaseGradeBook
    {
        //Tworzenie konstruktora "ESNUGradeBook" przyjmującego parametr "name" typu string, wywołującego konstruktor klasy bazowej z parametrem "name" oraz drugim parametrem "isWeighted", przypisującego wartość "Type" jako "GradeBookType.Wsei".
        public ESNUGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.ESNU;
        }
        //Nadpisywanie metody "GetLetterGrade" przyjmującej parametr "averageGrade" typu double, zwracającej wartość typu char.
        public override char GetLetterGrade(double averageGrade)
        {
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 90 to zwróć 'E' niczym Excellent bądź też Elegancko.
            if (averageGrade >= 90)
                return 'E';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 80 to zwróć 'S' czyli Satisfactory bądź też Super.
            if (averageGrade >= 70)
                return 'S';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 60 to zwróć 'N' czyli Needs Improvement bądź też Nieźle.
            if (averageGrade >= 50)
                return 'N';
            //Jeżeli żaden z powyższych warunków nie zostanie spełniony, zwróć 'U' czyli Unsatisfactory bądź też "Uwalone".
            else
                return 'U';
        }
    }
}
