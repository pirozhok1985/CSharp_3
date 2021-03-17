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

namespace MailSender
{
    /// <summary>
    /// Interaction logic for TabSelector.xaml
    /// </summary>
    public partial class TabSelector : UserControl
    {
        public static readonly RoutedEvent NextClickEvent;
        public static readonly RoutedEvent PrevClickEvent;
        public static readonly DependencyProperty PrevTabProperty;
        public static readonly DependencyProperty NextTabProperty;
        static TabSelector()
        {
            NextClickEvent = EventManager.RegisterRoutedEvent("NextClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSelector));
            PrevClickEvent = EventManager.RegisterRoutedEvent("PrevClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSelector));
            PrevTabProperty = DependencyProperty.Register("PrevTab", typeof(string), typeof(TabSelector));
            NextTabProperty = DependencyProperty.Register("NextTab", typeof(string), typeof(TabSelector));
        }

        public TabSelector()
        {
            InitializeComponent();
        }

        public string PrevTab
        {
            get { return (string)GetValue(PrevTabProperty); }
            set { SetValue(PrevTabProperty, value); }
        }

        public string NextTab
        {
            get { return (string) GetValue(NextTabProperty); }
            set { SetValue(NextTabProperty, value);}
        }

        public event RoutedEventHandler PrevClick
        {
            add {AddHandler(TabSelector.PrevClickEvent, value); }
            remove { RemoveHandler(TabSelector.PrevClickEvent, value);}
        }

        public event RoutedEventHandler NextClick
        {
            add { AddHandler(NextClickEvent, value); }
            remove { RemoveHandler(NextClickEvent, value); }
        }

        private void BPrev_OnClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(PrevClickEvent));
        }

        private void BNext_OnClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NextClickEvent));
        }
    }
}
