using GradeBook.Enums;


namespace GradeBook.GradeBooks
{
    //Dodawanie klasy "StandardGradeBook" dziedziczącej po klasie "BaseGradeBook", modyfikator dostępu "public".
   public class StandardGradeBook : BaseGradeBook
    {
        /*Tworzenie konstruktora "StandardGradeBook" przyjmującego parametr "name" typu string, wywołującego konstruktor klasy bazowej z parametrem "name" oraz 
        przypisującego wartość "Type" jako "GradeBookType.Standard". */
       public StandardGradeBook(string name) : base(name)
       {
           Type = GradeBookType.Standard;
       }
    }
}
