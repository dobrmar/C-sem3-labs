using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5
{
    public partial class MainWindow : Window
    {

        private ListOfCompositions CompList = new ListOfCompositions(); 

        public MainWindow()
        {

            InitializeComponent();
            Compositions.ItemsSource = CompList.CompList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CompList.AddComposition(NewComp()))
            {
                MessageBox.Show("Композиция уже в списке");
            }
            Compositions.Items.Refresh();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CompList.RemoveComposition(NewComp()))
            {
                MessageBox.Show("Композиция не найдена");
            }
            Compositions.Items.Refresh();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            string str = searchBox.Text;
            if (string.IsNullOrWhiteSpace(str)) return;
            List<Composition> res = CompList.SearchComposition(str);
            if (res.Any())
            {
                MessageBox.Show($"Результаты поиска по {str}:\n{string.Join("\n", res.Select(c => $"{c.AuthorName} - {c.Name}"))}");
            }
            else
            {
                MessageBox.Show($"Ничего не найдено по {str}");
            }
            
        }

        private Composition NewComp()
        {
            string AuthorName = Microsoft.VisualBasic.Interaction.InputBox("Введите автора:");           
            while (string.IsNullOrWhiteSpace(AuthorName))
            {
                MessageBox.Show("Обязательное значение");
                AuthorName = Microsoft.VisualBasic.Interaction.InputBox("Введите автора:");
            }
            string Name = Microsoft.VisualBasic.Interaction.InputBox("Введите название:");
            while (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Обязательное значение");
                Name = Microsoft.VisualBasic.Interaction.InputBox("Введите название:");
            }
            return new Composition(AuthorName, Name);
        }
    }
}
