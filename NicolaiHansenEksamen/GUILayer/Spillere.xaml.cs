using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NicolaiHansenEksamen.DataLayer;

namespace NicolaiHansenEksamen.GUILayer
{
    /// <summary>
    /// Interaction logic for Spillere.xaml
    /// </summary>
    public partial class Spillere : Window
    {
        DatabaseHandler database = new DatabaseHandler();
        public Spillere()
        {
            
            InitializeComponent();
        }

        private void RegPlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            insertInto();
            clearTextBoxes();
        }

        private void clearTextBoxes() //Metode som nulstiller alle textboxene
        {
            RegPlayerNameTbx.Text = "";
            RegPlayerSmnNameTbx.Text = "";
            RegPlayerRankTbx.Text = "";
            RegPlayerPhnTbx.Text = "";
            RegPlayerTrnTbx.Text = "";
        }
        
        private void insertInto() 
        {
            database.insertPlayerData(RegPlayerNameTbx.Text, RegPlayerSmnNameTbx.Text, RegPlayerRankTbx.Text, int.Parse(RegPlayerPhnTbx.Text), RegPlayerTrnTbx.Text);
        }

        private void PlayerInfoSearchTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            PlayerInfoSearchTbx.Clear();
        }

        private void displayPlayerInfo()
        {
            SpillerInfo spillerInfo = database.getPlayerData(PlayerInfoSearchTbx.Text);
            PlayerDispIDLbl.Content = spillerInfo.Id;
            PlayerDispNameLbl.Content = spillerInfo.Name;
            PlayerDispSmnNameLbl.Content = spillerInfo.SummonerName;
            PlayerDispRankLbl.Content = spillerInfo.Rank;
            PlayerDispPhnNmbLbl.Content = spillerInfo.PhoneNumber;
            PlayerDispTurnLbl.Content = spillerInfo.TournamentType;
        }

        private void PlayerInfoSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            displayPlayerInfo();
        }

        private void RegPlayerTrnTbx_KeyDown(object sender, KeyEventArgs e) //Event på sidste textbox i registreringen som gør at hvis man trykker "Enter" trykker den på knappen "Tilføj"
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                RegPlayerBtn_Click(sender, e);
            }
        }
        private void PlayerInfoSearchTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                PlayerInfoSearchBtn_Click(sender, e);
            }
        }

        
    }
}
