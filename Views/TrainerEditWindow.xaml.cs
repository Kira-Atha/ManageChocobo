using ChocoboManagement.DataAccess.DAO;
using ChocoboManagement.DataAccess.IDAO;
using ChocoboManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class TrainerEditWindow : Window, INotifyPropertyChanged {

        // Implémenter les Interfaces DAO pour une question d'indépendance
        private readonly ITrainerDAO _trainerDAO;
        private readonly IStableDAO _stableDAO;
        private readonly ITrainerStableDAO _trainerStableDAO;

        // Permettra le binding de données

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        // Init ce dont j'aurais besoin : l'entraîneur, les étables et ses étables. 
        private Trainer _trainer;

        public Trainer Trainer {
            get { return _trainer; }
            set {
                _trainer = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Stable> _stables;

        public ObservableCollection<Stable> Stables {
            get { return _stables; }
            set {
                _stables = value;
                OnPropertyChanged();
            }
        }

        private Stable _selectedStable;

        public Stable SelectedStable {
            get { return _selectedStable; }
            set {
                _selectedStable = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Stable> _trainerStables;

        public ObservableCollection<Stable> TrainerStables {
            get { return _trainerStables; }
            set {
                _trainerStables = value;
                OnPropertyChanged();
            }
        }

        // Constructeur par défaut
        public TrainerEditWindow() {
            InitializeComponent();
            DataContext = this;
            Trainer = new Trainer();
            _trainerDAO = new TrainerDAO();
            _stableDAO = new StableDAO();
            _trainerStableDAO = new TrainerStableDAO();
            var stables = _stableDAO.GetStables();
            Stables = new ObservableCollection<Stable>(stables);
        }

        // Appel au constructeur par défaut + récupérer les étables de l'entraîneur sélectionné
        public TrainerEditWindow(Trainer trainer) : this() {
            Trainer = trainer;

            List<Stable> trainerStables = _stableDAO.GetStableByTrainerId(Trainer.Id);
            TrainerStables = new ObservableCollection<Stable>(trainerStables);
        }

        private void AddStable_Click(object sender, RoutedEventArgs e) {
            if (SelectedStable == null) {
                MessageBox.Show("Sélectionner une étable à ajouter ! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TrainerStables.Any(p => p.Id == SelectedStable.Id)) {
                MessageBox.Show("Cet entraîneur possède déjà cette étable. Veuillez en choisir une autre !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            TrainerStables.Add(SelectedStable);
            TrainerStable trainerStable = new TrainerStable();
            trainerStable.TrainerId = Trainer.Id;
            trainerStable.StableId = SelectedStable.Id;
            _trainerStableDAO.AddTrainerStable(trainerStable);
        }

        private void SaveTrainerModification_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(Trainer.TrainerFirstname) || string.IsNullOrWhiteSpace(Trainer.TrainerLastname)) {
                MessageBox.Show("Pas de champ vide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                if (Trainer.Id == 0) {
                    _trainerDAO.AddTrainer(Trainer);
                } else {
                    _trainerDAO.ModifyTrainer(Trainer);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
