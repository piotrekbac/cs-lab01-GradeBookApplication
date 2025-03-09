using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    //Dodanie klasy "WseiGradeBook" dziedziczącej po klasie "BaseGradeBook".
    public class WseiGradeBook : BaseGradeBook
    {
        /*Tworzenie konstruktora "WseiGradeBook" przyjmującego parametr "name" typu string, wywołującego konstruktor klasy bazowej z parametrem "name" oraz 
        przypiującego wartość "Type" jako "GradeBookType.Wsei" dodajemy bool jako drugi parametr. */
        public WseiGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Wsei;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 90 to zwróć '5' czyli odpowiednik wartości 5 w ocenie -> bardzo dobry.
            if (averageGrade >= 90)
                return '5';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 80 to zwróć 'B' czyli odpowiednik wartości 4  w ocenie -> +dobry.
            if (averageGrade >= 80)
                return 'B';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 70 to zwróć '4' czyli odpowiednik wartości 4 w ocenie -> dobry.
            if (averageGrade >= 70)
                return '4';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 60 to zwróć 'C' czyli odpowiednik wartości 3 w ocenie -> +dostateczny.
            if (averageGrade >= 60)
                return 'C';
            //Warunek mówiący o tym, że jeżeli średnia ocen jest większa lub równa 50 to zwróć '3' czyli odpowiednik wartości 3 w ocenie -> dostateczny.
            if (averageGrade >= 50)
                return '3';
            //Jeżeli żaden z powyższych warunków nie zostanie spełniony, zwróć '2' czyli odpowiednik wartości 2 w ocenie -> dopuszczający (niezdany).
            else
                return '2';
        }
    }
}
