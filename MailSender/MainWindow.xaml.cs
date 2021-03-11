using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    }
}
