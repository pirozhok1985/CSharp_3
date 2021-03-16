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
        public TabSelector()
        {
            InitializeComponent();
        }

        public string PrevTab
        {
            get { return (string)GetValue(PrevTabProperty); }
            set { SetValue(PrevTabProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrevTab.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrevTabProperty =
            DependencyProperty.Register("PrevTab", typeof(string), typeof(TabSelector));

        public string NextTab
        {
            get { return (string) GetValue(NextTabProperty); }
            set { SetValue(NextTabProperty, value);}
        }

        public static readonly DependencyProperty NextTabProperty = 
            DependencyProperty.Register("NextTab", typeof(string),typeof(TabSelector));

        public static readonly RoutedEvent PrevClickEvent = EventManager.RegisterRoutedEvent("PrevClick",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSelector));

        public event RoutedEventHandler PrevClick
        {
            add {AddHandler(TabSelector.PrevClickEvent, value); }
            remove { RemoveHandler(TabSelector.PrevClickEvent, value);}
        }

        public static readonly RoutedEvent NextClickEvent = EventManager.RegisterRoutedEvent("NextClick",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSelector));

        public event RoutedEventHandler NextClick
        {
            add { AddHandler(TabSelector.NextClickEvent, value); }
            remove { RemoveHandler(TabSelector.NextClickEvent, value); }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if ((Button) e.Source == bNext)
            {
                RaiseEvent(new RoutedEventArgs(TabSelector.NextClickEvent, this));
            }
            else if ((Button)e.Source == bPrev)
            {
                RaiseEvent(new RoutedEventArgs(TabSelector.PrevClickEvent, this));
            }
        }
    }
}
