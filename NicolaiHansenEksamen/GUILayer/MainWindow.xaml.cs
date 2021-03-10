using NicolaiHansenEksamen.DataLayer;
using NicolaiHansenEksamen.GUILayer;
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

namespace NicolaiHansenEksamen
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

        string name;
        
        private void ChckNameTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ChckNameTbx.Clear();
        }

        private void ChckNameBtn_Click(object sender, RoutedEventArgs e)
        {

            name = ChckNameTbx.Text;


            Services service = new Services();
            bool names = service.getName(name);
            
            
                if(names == true)
                {
                    ChckNameResultLbl.Content = "Spilleren findes";
                }
                else
                {
                    ChckNameResultLbl.Content = "Spilleren findes ikke";
                }   
            
        }

        private void SpillereBtn_Click(object sender, RoutedEventArgs e)
        {
            Spillere p = new Spillere();
            p.Show();
        }
    }
}
