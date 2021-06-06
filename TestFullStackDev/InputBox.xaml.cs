using System.Windows;

namespace TestFullStackDev
{
    /// <summary>
    /// Логика взаимодействия для InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        public InputBox(string message)
        {
            InitializeComponent();
            Message_TextBlock.Text = message;

            TextBox.KeyUp += (s, a) =>
            {
                if (string.IsNullOrEmpty(TextBox.Text))
                {
                    Validation_TextBlock.Visibility = Visibility.Visible;
                    Ok_Button.IsEnabled = false;
                }
                else
                {
                    Validation_TextBlock.Visibility = Visibility.Hidden;
                    Ok_Button.IsEnabled = true;
                }
            };
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e) =>
            DialogResult = true;

        private void Cancel_Button_Click(object sender, RoutedEventArgs e) =>
            DialogResult = false;
    }
}