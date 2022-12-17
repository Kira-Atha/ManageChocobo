using ChocoboManagement.DataAccess.DAO;
using ChocoboManagement.DataAccess.IDAO;
using ChocoboManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ChocoboManagement.Views {

    public partial class ChocoboEditWindow : Window, INotifyPropertyChanged {

        private IChocoboDAO _chocoboDAO;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private Chocobo _chocobo;

        public Chocobo Chocobo {
            get { return _chocobo; }
            set {
                _chocobo = value;
                OnPropertyChanged();
            }
        }
        public ChocoboEditWindow() {
            InitializeComponent();
            DataContext = this;
            Chocobo = new Chocobo();
            _chocoboDAO = new ChocoboDAO();
        }

        public ChocoboEditWindow(Chocobo chocobo) : this() {
            Chocobo = chocobo;

        }
        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void SaveChocoboModification_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(Chocobo.ChocoboName)) {
                MessageBox.Show("Le nom du chocobo ne peut pas être vide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                if (Chocobo.Id == 0) {
                    _chocoboDAO.AddChocobo(Chocobo);
                } else {
                    _chocoboDAO.ModifyChocobo(Chocobo);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}