using GradeBook.GradeBooks;
using System;
using System.Windows;

namespace GradeBookApp
{
    //definicja klasy MainWindow dziedziczącej po klasie Window z przestrzeni nazw System.Windows
    public partial class MainWindow : Window
    {
        //konstruktor klasy MainWindow
        public MainWindow()
        {
            //wywołanie metody InitializeComponent - inicjalizacja komponentów
            InitializeComponent();
            //wywołanie metody LoadGradeBooks - wczytanie listy dostępnych plików z rozszerzeniem .gdbk
            LoadGradeBooks();
        }

        //metoda LoadGradeBooks - wczytanie listy dostępnych plików z rozszerzeniem .gdbk
        private void LoadGradeBooks()
        {
            //wyczyszczenie listy GradeBooksListBox
            GradeBooksListBox.Items.Clear();
            //inicjowanie dla każdego pliku w katalogu bieżącym z rozszerzeniem .gdbk
            foreach (var file in System.IO.Directory.GetFiles(Environment.CurrentDirectory, "*.gdbk"))
            {
                //dodanie nazwy pliku bez rozszerzenia do listy GradeBooksListBox
                GradeBooksListBox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file));
            }
        }

        //obsługa zdarzenia Click dla przycisku CreateGradeBookButton - utworzenie nowego pliku z ocenami
        private void CreateGradeBookButton_Click(object sender, RoutedEventArgs e)
        {
            //pobranie nazwy pliku z TextBoxa GradeBookNameTextBox
            var name = GradeBookNameTextBox.Text;
            //pobranie typu ocen z ComboBoxa GradeBookTypeComboBox
            var type = ((ComboBoxItem)GradeBookTypeComboBox.SelectedItem).Content.ToString().ToLower();
            //pobranie wartości z CheckBoxa IsWeightedCheckBox
            var isWeighted = IsWeightedCheckBox.IsChecked ?? false;

            //utworzenie nowego obiektu klasy BaseGradeBook w zależności od wybranego typu ocen
            BaseGradeBook gradeBook;

            //wybór typu ocen i utworzenie obiektu klasy dziedziczącej po BaseGradeBook
            switch (type)
            {
                //dla typu "standard" utwórz obiekt klasy StandardGradeBook
                case "standard":
                    gradeBook = new StandardGradeBook(name, isWeighted);
                    break;
                //dla typu "ranked" utwórz obiekt klasy RankedGradeBook
                case "ranked":
                    gradeBook = new RankedGradeBook(name, isWeighted);
                    break;
                //dla typu "esnu" utwórz obiekt klasy ESNUGradeBook
                case "esnu":
                    gradeBook = new ESNUGradeBook(name, isWeighted);
                    break;
                //dla typu "onetofour" utwórz obiekt klasy OneToFourGradeBook
                case "onetofour":
                    gradeBook = new OneToFourGradeBook(name, isWeighted);
                    break;
                //dla typu "sixpoint" utwórz obiekt klasy SixPointGradeBook
                case "sixpoint":
                    gradeBook = new SixPointGradeBook(name, isWeighted);
                    break;
                //dla typu "wsei" utwórz obiekt klasy WseiGradeBook
                case "wsei":
                    gradeBook = new WseiGradeBook(name, isWeighted);
                    break;
                //dla pozostałych typów wyświetl komunikat o błędzie
                default:
                    MessageBox.Show($"{type} is not a supported type of gradebook, please try again");
                    return;
            }

            //wyświetlenie komunikatu o utworzeniu nowego pliku z ocenami
            gradeBook.Save();
            //wyświetlenie komunikatu o utworzeniu nowego pliku z ocenami
            LoadGradeBooks();
        }
    }
}