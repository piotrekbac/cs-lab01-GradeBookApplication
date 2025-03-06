using GradeBook.Enums;


namespace GradeBook.GradeBooks
{
    //Dodawanie klasy "StandardGradeBook" dziedziczącej po klasie "BaseGradeBook", modyfikator dostępu "public".
   public class StandardGradeBook : BaseGradeBook
    {
        /*Tworzenie konstruktora "StandardGradeBook" przyjmującego parametr "name" typu string, wywołującego konstruktor klasy bazowej z parametrem "name" oraz 
        przypisującego wartość "Type" jako "GradeBookType.Standard". */
        //Aktualizujemy konstruktor klasy "StandardGradeBook" dodając parametr "isWeighted" typu bool jako drugi parametr oraz wywołując konstruktor klasy bazowej z dwoma parametrami.
       public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
       {
           Type = GradeBookType.Standard;
       }
    }
}
