using System;
using GradeBook.Enums;
using System.Linq;  

namespace GradeBook.GradeBooks
{
    //Dodawanie klasy "RankedGradeBook" dziedziczącej po klasie "BaseGradeBook", modyfikator dostępu "public".
    public class RankedGradeBook : BaseGradeBook
    {
        /*Tworzenie konstruktora "RankedGradeBook" przyjmującego parametr "name" typu string, wywołującego konstruktor klasy bazowej z parametrem "name" oraz 
        przypiującego wartość "Type" jako "GradeBookType.Ranked".*/
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        //Nadpisywanie metody "GetLetterGrade" przyjmującej parametr "averageGrade" typu double, zwracającej wartość typu char.
        public override char GetLetterGrade(double averageGrade)
        {
            //Sprawdzenie czy liczba studentów wynosi 5, jeżeli jest ona mniejsza niż 5, to zostanie rzucony wyjątek "InvalidOperationException".
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("There are less then 5 students!");
            }

            //Obliczenie 20% liczby studentów w klasie.
            var prog20procentKlasy = (int)Math.Ceiling(Students.Count * 0.2);
            //Utworzenie listy "oceny" zawierającej oceny studentów posortowane malejąco, wybierając średnie oceny studentów, a następnie zamieniając je na listę.
            var oceny = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            //Sprawdzenie czy  ocena studenta jest w top 20% w klasie, jeżeli tak to zwróć 'A'.
            if (oceny[prog20procentKlasy - 1] <= averageGrade)
                return 'A';
            //Sprawdzenie czy ocena ucznia jest między top 20%, a top 40% w klasie, jeżeli tak to zwróć 'B'.
            else if (oceny[prog20procentKlasy * 2 - 1] <= averageGrade)
                return 'B';
            //Sprawdzenie czy ocena ucznia jest między top 40%, a top 60% w klasie, jeżeli tak to zwróć 'C'.
            else if (oceny[prog20procentKlasy * 3 - 1] <= averageGrade)
                return 'C';
            //Sprawdzenie czy ocena ucznia jest między top 60%, a top 80% w klasie, jeżeli tak to zwróć 'D'.
            else if (oceny[prog20procentKlasy * 4 - 1] <= averageGrade)
                return 'D';
            //Jeżeli żaden z powyższych warunków nie zostanie spełniony, zwróć 'F'.
            else
                return 'F';
        }

        //Nadpisywanie metody "CalculateStatistics".
        public void CalculateStatistics()
        {
            //Sprawdzenie czy liczba studentów wynosi 5, jeżeli jest ona mniejsza niż 5, to zostanie wyświetlony komunikat "Ranked grading requires at least 5 students.".
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            //Wywołanie metody "CalculateStatistics" z klasy bazowej jezeli liczba studentów wynosi 5 lub więcej.
            base.CalculateStatistics();
        }

        //Nadpisywanie metody "CalculateStudentStatistics" przyjmującej parametr "name" typu string, dla konkretnego ucznia.
        public void CalculateStudentStatistics(string name)
        {
            //Sprawdzenie czy liczba studentów wynosi 5, jeżeli jest ona mniejsza niż 5, to zostanie wyświetlony komunikat "Ranked grading requires at least 5 students.".
            if (Students.Count < 5)
            {
                Console.WriteLine("anked grading requires at least 5 students.");
                return;
            }
            //Wywołanie metody "CalculateStudentStatistics" z parametrem name, z klasy bazowej jezeli liczba studentów wynosi 5 lub więcej.
            base.CalculateStudentStatistics(name);
        }
    }
}