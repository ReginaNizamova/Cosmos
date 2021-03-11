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

namespace Cosmos
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        static int fuel = 1000;
        public static MainWindow Window {get; set;}
        class Travel   
        {
            public const long Distance = 2000000000;
            public double Speed;
            static public int NumberTrips = 1;

            static public void Fuel()
            {
                fuel -= 250;
                MainWindow.Window.fuelRocket.Content = fuel;
                
                if (fuel < 250)
                {
                    MainWindow.Window.fuelRocket.Content = "Не хватает топлива";
                    MainWindow.Window.cleanButton.IsEnabled = false;
                    MainWindow.Window.valueButton.IsEnabled = false;
                    return;
                }

            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Window = this;        
        }

        private void Culculate (object sender, RoutedEventArgs e)
        {          
            Travel travel = new Travel {};
            travel.Speed = Convert.ToDouble(Speed.Text);

            Time.Content = Math.Round ((Travel.Distance / travel.Speed) /24,0) + " дней";
            Travel.Fuel();
            CountTrips.Content = Convert.ToInt32(Travel.NumberTrips++);
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            Speed.Text = null;
            Time.Content = null;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            fuel += 1000;
            MainWindow.Window.fuelRocket.Content = fuel;
            MainWindow.Window.cleanButton.IsEnabled = true;
            MainWindow.Window.valueButton.IsEnabled = true;
        }
    }
}
