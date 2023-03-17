using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using TeamClass_Library;

namespace FinalExam_CSI_124_Programming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //Login Page    

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidateUser();
        }

        public void ValidateUser()
        {
            string userInputeName = txtUserName.Text;
            string userPassword = psPassword.Password;

            foreach (Manager manager in Data.managers)
            {
                if (manager.CheckName(userInputeName))
                {
                    if (manager.ValidateUser(userInputeName, userPassword))
                    {
                        //This will run when the user has properly logged in
                        Data.currentManager = manager;

                        if (Data.currentManager.Role == Manager.Position.General_Manager)
                        {
                            new TeamRoster().Show();
                        }
                        else
                        {
                            MessageBox.Show("Manager");
                        }

                    }

                }
            }
        }//ValidateUser
    }//Class
}//namespace
