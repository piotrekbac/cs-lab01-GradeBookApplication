using GradeBook.GradeBooks;
using System;
using System.Windows;

namespace GradeBookApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGradeBooks();
        }

        private void LoadGradeBooks()
        {
            GradeBooksListBox.Items.Clear();
            foreach (var file in System.IO.Directory.GetFiles(Environment.CurrentDirectory, "*.gdbk"))
            {
                GradeBooksListBox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file));
            }
        }

        private void CreateGradeBookButton_Click(object sender, RoutedEventArgs e)
        {
            var name = GradeBookNameTextBox.Text;
            var type = ((ComboBoxItem)GradeBookTypeComboBox.SelectedItem).Content.ToString().ToLower();
            var isWeighted = IsWeightedCheckBox.IsChecked ?? false;

            BaseGradeBook gradeBook;

            switch (type)
            {
                case "standard":
                    gradeBook = new StandardGradeBook(name, isWeighted);
                    break;
                case "ranked":
                    gradeBook = new RankedGradeBook(name, isWeighted);
                    break;
                case "esnu":
                    gradeBook = new ESNUGradeBook(name, isWeighted);
                    break;
                case "onetofour":
                    gradeBook = new OneToFourGradeBook(name, isWeighted);
                    break;
                case "sixpoint":
                    gradeBook = new SixPointGradeBook(name, isWeighted);
                    break;
                case "wsei":
                    gradeBook = new WseiGradeBook(name, isWeighted);
                    break;
                default:
                    MessageBox.Show($"{type} is not a supported type of gradebook, please try again");
                    return;
            }

            gradeBook.Save();
            LoadGradeBooks();
        }
    }
}