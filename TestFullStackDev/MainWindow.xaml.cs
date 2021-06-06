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
            
            TV.SelectedItemChanged += (s, a) =>
            {
                if (a.NewValue == null)
                {
                    Remove_Button.IsEnabled = false;
                    Edit_Button.IsEnabled = false;
                }
                else
                {
                    Remove_Button.IsEnabled = true;
                    Edit_Button.IsEnabled = true;
                }
            };
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            //Если есть выбранный элемент, то добавляем новый в его вложение
            if (TV.SelectedItem is TreeViewItem selectedItem)
            {
                selectedItem.Items.Add(new TreeViewItem
                {
                    Header = $"{selectedItem.Header}_{selectedItem.Items.Count + 1}"
                });

                selectedItem.IsExpanded = true;
            }
            //В противном случае в корень
            else
            {
                TV.Items.Add(new TreeViewItem
                {
                    Header = $"Node {TV.Items.Count + 1}"
                });
            }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
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
            if (TV.SelectedItem == null) return;

            var inputBox = new InputBox("Enter a new header here.");
            var result = inputBox.ShowDialog();
            
            //Если была нажата кнопка Cancel
            if (result != true) return;

            var selectedItem = (TreeViewItem)TV.SelectedItem;
            selectedItem.Header = inputBox.TextBox.Text;
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e) =>
            TV.Items.Clear();

        //Убрать фокус, чтобы добавить элемент в корень дерева
        private void TV_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TV.SelectedItem is TreeViewItem selectedItem)
                selectedItem.IsSelected = false;
        }
    }
}