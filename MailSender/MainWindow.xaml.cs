using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailSender.Model;
using MailSender.ViewModel;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg = "Do you really want to close this application?";
            MessageBoxResult result = MessageBox.Show(msg, "Mail Sender", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No) e.Cancel = true;
        }

        private void BSend_OnClick(object sender, RoutedEventArgs e)
        {
            var data = (viewModel)DataContext;
            if (tbTo.Text != String.Empty & tbFrom.Text != String.Empty)
            {
                data.MailSender.Send();
                MessageBox.Show("Message has been sent to recipient");
                this.Close();
            }
            else
            {
                MessageBox.Show("You have to fill in all required fields");
            }
        }

        private void BCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CbServer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox item = (ComboBox) sender;
            var selectedItem = (ComboBoxItem)item.SelectedItem;
            if (selectedItem.Content.ToString().Equals("smtp.gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                this.tbLogin.IsEnabled = false;
                this.tbPassword.IsEnabled = false;
            }
            else
            {
                this.tbLogin.IsEnabled = true;
                this.tbPassword.IsEnabled = true;
            }
        }

        private void BApply_OnClick(object sender, RoutedEventArgs e)
        {
            var cbSelectedItem = (ComboBoxItem)this.cbServer.SelectedItem;
            var data = (viewModel)DataContext;
            if (this.tbLogin.Text == string.Empty && this.tbPassword.Text == string.Empty)
            {
                if(this.tbLogin.IsEnabled)
                    MessageBox.Show("You have to enter Credentials!", "Settings", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                data.MailSender.Client.Credentials = new NetworkCredential(this.tbLogin.Text, this.tbPassword.Text);
            }

            data.MailSender.Client.Host = cbSelectedItem.Content.ToString();
        }
    }
}
