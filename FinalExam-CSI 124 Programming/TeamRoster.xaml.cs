using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using System.Windows.Shapes;
using CsvHelper;
using TeamClass_Library;

namespace FinalExam_CSI_124_Programming
{
    /// <summary>
    /// Interaction logic for TeamRoster.xaml
    /// </summary>
    public partial class TeamRoster : Window
    {
        List<Player> players = new List<Player>();
        public TeamRoster()
        {
            InitializeComponent();
            CreateNameFile(Data.FullTeamFilePath());
            ReadFullList();
            UpdateListView();
        }
        private void CreateNameFile(string filePath)
        {
            FileStream tryout = File.OpenRead(filePath);
            tryout.Close();
            tryout.Dispose();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string first = txtFirstName.Text;   
            string last = txtLastName.Text;
            string number = txtNumber.Text;
            double salary = double.Parse(txtSalary.Text);

            players.Add(new Player(first, last, number, salary));    
            SaveList();
            UpdateListView();
        }

        public void SaveList()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            string filePath = Data.FullTeamFilePath();

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(players);
                writer.Flush();
            }
        } // SaveList

        public void ReadFullList()
        {
            string filePath = Data.FullTeamFilePath();

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                // Pull the entire csv file as a list of Player
                // For this to work, class must have a default constructor,
                // and properties must be the EXACT SAME NAME AND SPELLING AS HEADERS IN CSV
                players = csv.GetRecords<Player>().ToList();
            }

        }
        public void UpdateListView()
        {
            lvRoster.Items.Clear();

            foreach (Player player in players)
            {
                lvRoster.Items.Add(player);
            }
        }

        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            players.Sort();
            UpdateListView();
        }

        private void btnSortSalary_Click(object sender, RoutedEventArgs e)
        {
            PlayerSort_Salary psSalary = new PlayerSort_Salary();
            players.Sort(psSalary); 
            UpdateListView();
        }

      
    }
}
