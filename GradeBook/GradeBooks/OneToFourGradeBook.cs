using System;
using GradeBook.Enums;
using GradeBook.UserInterfaces;

namespace GradeBook.GradeBooks
{
    //Dodanie klasy "OneToFourGradeBook" dziedziczącej po klasie "BaseGradeBook".
    public class OneToFourGradeBook : BaseGradeBook
    {
        //Tworzenie konstruktora "OneToFourGradeBook" przyjmującego parametr "name" typu string, wywołującego konstruktor klasy bazowej z parametrem "name" oraz drugim parametrem "isWeighted", przypisującego wartość "Type" jako "GradeBookType.OneToFour".
        public OneToFourGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            //Przypisanie wartości "Type" jako "GradeBookType.OneToFour".
            Type = GradeBookType.OneToFour;
        }
        //Nadpisywanie metody "GetLetterGrade" przyjmującej parametr "averageGrade" typu double, zwracającej wartość typu char.
        public override char GetLetterGrade(double averageGrade)
        {
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 90 to zwróć '4'.
            if (averageGrade >= 90)
                return '4';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 75 to zwróć '3'.
            if (averageGrade >= 75)
                return '3';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 60 to zwróć '2'.
            if (averageGrade >= 60)
                return '2';
            //Jeżeli żaden z powyższych warunków nie zostanie spełniony, zwróć '1'.
            else
                return '1';
        }
    } 
}