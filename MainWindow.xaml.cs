using HomeWorkBankWorkers.BankSystem;
using HomeWorkBankWorkers.BankSystem.BankWorkers;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWorkBankWorkers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        internal Worker Employee { get; set; }
        public ObservableCollection<BankClient> BankClients { get; set; }
        internal MainWindow(Worker employee)
        {
            InitializeComponent();
            Employee = employee;
            BankClients = new ObservableCollection<BankClient>();
            ListBoxDataClients.ItemsSource = BankClients;
            SetMenuAccessSetting(Employee);
        }

        private void ListBoxDataClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxDataClients.SelectedItem is BankClient client)
            {
                TextBoxNameClient.Text = Employee.GetName(client);
                TextBoxSurNameClient.Text = Employee.GetSurName(client);
                TextBoxPatronymicClient.Text = Employee.GetPatronymic(client);
                TextBoxPhoneNumberClient.Text = Employee.GetPhoneNumber(client);
                TextBoxPussportSeriesNumberClient.Text = Employee.GetPassportSeriesNumber(client);
            }
            else
            {
                TextBoxNameClient.Text = string.Empty;
                TextBoxSurNameClient.Text = string.Empty;
                TextBoxPatronymicClient.Text = string.Empty;
                TextBoxPhoneNumberClient.Text = string.Empty;
                TextBoxPussportSeriesNumberClient.Text = string.Empty;
            }
        }

        private void ButtonSaveChange_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxDataClients.SelectedItem is BankClient client)
            {
                if (!Employee.SetName(client, TextBoxNameClient.Text))
                    TextBoxNameClient.Text = Employee.GetName(client);
                if (!Employee.SetSurName(client, TextBoxSurNameClient.Text))
                    TextBoxSurNameClient.Text = Employee.GetSurName(client);
                if (!Employee.SetPatronymic(client, TextBoxPatronymicClient.Text))
                    TextBoxPatronymicClient.Text = Employee.GetPatronymic(client);
                if (!Employee.SetPhoneNumber(client, TextBoxPhoneNumberClient.Text))
                    TextBoxPhoneNumberClient.Text = Employee.GetPhoneNumber(client);
                if (!Employee.SetPassportSeriesNumber(client, TextBoxPussportSeriesNumberClient.Text))
                    TextBoxPussportSeriesNumberClient.Text = Employee.GetPassportSeriesNumber(client);
            }
        }
        private void SetMenuAccessSetting(Worker worker)
        {
            if (worker is Consultant)
            {
                TextBoxNameClient.IsEnabled = false;
                TextBoxSurNameClient.IsEnabled = false;
                TextBoxPatronymicClient.IsEnabled = false;
                TextBoxPhoneNumberClient.IsEnabled = true;
                TextBoxPussportSeriesNumberClient.IsEnabled = false;
            }
            if (worker is Manager)
            {
                TextBoxNameClient.IsEnabled = true;
                TextBoxSurNameClient.IsEnabled = true;
                TextBoxPatronymicClient.IsEnabled = true;
                TextBoxPhoneNumberClient.IsEnabled = true;
                TextBoxPussportSeriesNumberClient.IsEnabled = true;
            }
        }

        private void MenuItemSaveClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "BankClients"; 
            dialog.DefaultExt = ".json"; 
            dialog.Filter = "JSON file (.json)|*.json"; 

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                Debug.WriteLine(filename);
                File.WriteAllText(filename, JsonConvert.SerializeObject(BankClients));
            }
        }

        private void MenuItemOpenClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "BankClients";
            dialog.DefaultExt = ".json";
            dialog.Filter = "JSON file (.json)|*.json";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                BankClients = JsonConvert.DeserializeObject<ObservableCollection<BankClient>>(File.ReadAllText(filename));
                ListBoxDataClients.ItemsSource = BankClients;
            }
        }
        private void MenuItemChangeUser_Click(object sender, RoutedEventArgs e)
        {
            WorkerSelection workerSelection = new WorkerSelection();
            workerSelection.Show();
            this.Close();
        }
    }
}
