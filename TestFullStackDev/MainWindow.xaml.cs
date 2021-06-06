using System.Windows;
using System.Windows.Controls;

namespace TestFullStackDev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (TV.SelectedItem is TreeViewItem selectedItem)
            {
                selectedItem.Items.Add(new TreeViewItem
                {
                    Header = $"{selectedItem.Header}_{selectedItem.Items.Count + 1}"
                });
            }
            else
            {
                TV.Items.Add(new TreeViewItem
                {
                    Header =$"Node {TV.Items.Count + 1}"
                });
            }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            //Проверка, что есть выбранный элемент
            if (TV.SelectedItem == null) return;

            var selectedItem = (TreeViewItem) TV.SelectedItem;

            if (selectedItem.Parent is TreeViewItem parent)
            {
                parent.Items.Remove(selectedItem);
            }
            else
            {
                TV.Items.Remove(selectedItem);
            }
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            TV.Items.Clear();
        }

        //Убрать фокус, чтобы добавить элемент в корень дерева
        private void TV_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TV.SelectedItem is TreeViewItem selectedItem)
                selectedItem.IsSelected = false;
        }
    }
}
