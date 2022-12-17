using ChocoboManagement.DataAccess.DAO;
using ChocoboManagement.DataAccess.IDAO;
using ChocoboManagement.Models;
using ChocoboManagement.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChocoboManagement {
    public partial class MainWindow : Window, INotifyPropertyChanged {

        private readonly ITrainerDAO _trainerDAO;
        private readonly IStableDAO _stableDAO;
        private readonly IChocoboDAO _chocoboDAO;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        // Va juste notifier le xaml que la liste en question ( un string ) et dire que cette propriété a changé. C'est le xaml qui va parcourir tous les bindings qu'il a ( mainw fait un binding sur trainers, prop biindée donc je raffraichis ) 
        private Trainer _selectedTrainer;

        public Trainer SelectedTrainer {
            get { return _selectedTrainer; }
            set {
                _selectedTrainer = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Trainer> _trainers;
        public ObservableCollection<Trainer> Trainers {
            get { return _trainers; }
            set {
                _trainers = value;
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
        private ObservableCollection<Stable> _stables;
        public ObservableCollection<Stable> Stables {
            get { return _stables; }
            set {
                _stables = value;
                OnPropertyChanged();
            }
        }

        private Chocobo _selectedChocobo;

        public Chocobo SelectedChocobo {
            get { return _selectedChocobo; }
            set {
                _selectedChocobo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Chocobo> _chocobos;
        public ObservableCollection<Chocobo> Chocobos {
            get { return _chocobos; }
            set {
                _chocobos = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Chocobo> _stableChocobos;

        public ObservableCollection<Chocobo> StableChocobos {
            get { return _stableChocobos; }
            set {
                _stableChocobos = value;
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

        private ObservableCollection<Chocobo> _chocobosAvailables;

        public ObservableCollection<Chocobo> ChocobosAvailables {
            get { return _chocobosAvailables; }
            set { _chocobosAvailables = value;
                OnPropertyChanged();
            }
        }

        public MainWindow() {
            InitializeComponent();
            DataContext = this;
            _trainerDAO = new TrainerDAO();
            _stableDAO = new StableDAO();
            _chocoboDAO = new ChocoboDAO();

            List<Trainer> trainers = _trainerDAO.GetTrainers();
            Trainers = new ObservableCollection<Trainer>(trainers);

            List<Stable> stables = _stableDAO.GetStables();
            Stables = new ObservableCollection<Stable>(stables);

            // Tous=>
            List<Chocobo> chocobos = _chocoboDAO.GetChocobos();
            Chocobos = new ObservableCollection<Chocobo>(chocobos);

            LoadChocobosAvailables();
        }

        private void TrainerAdd_Click(object sender, RoutedEventArgs e) {
            TrainerEditWindow trainerEditWindow = new TrainerEditWindow();
            trainerEditWindow.Show();
            this.Close();
        }

        private void TrainerModify_Click(object sender, RoutedEventArgs e) {
            if (SelectedTrainer == null) {
                MessageBox.Show("Sélectionner un entraîneur à modifier !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            TrainerEditWindow trainerEditWindow = new TrainerEditWindow(SelectedTrainer);
            trainerEditWindow.Show();
            this.Close();
        }
        private void TrainerDelete_Click(object sender, RoutedEventArgs e) {
            if (SelectedTrainer == null) {
                MessageBox.Show("Sélectionner un entraîneur à congédier ! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _trainerDAO.DeleteTrainer(SelectedTrainer);
            Trainers.Remove(SelectedTrainer);
        }
        private void StableAdd_Click(object sender, RoutedEventArgs e) {
            StableEditWindow stableEditWindow = new StableEditWindow();
            stableEditWindow.Show();
            this.Close();
        }
        private void StableModify_Click(object sender, RoutedEventArgs e) {
            if (SelectedStable == null) {
                MessageBox.Show("Sélectionner une étable à modifier !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            StableEditWindow stableEditWindow = new StableEditWindow(SelectedStable);
            stableEditWindow.Show();
            this.Close();
        }

        private void StableDelete_Click(object sender, RoutedEventArgs e) {
            if (SelectedStable == null) {
                MessageBox.Show("Sélectionner une étable à vendre ! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _stableDAO.DeleteStable(SelectedStable);
            Stables.Remove(SelectedStable);
            LoadChocobosAvailables();
        }

        public void LoadChocobosAvailables() {
            List<Chocobo> chocobosAvailables = _chocoboDAO.GetChocobosAvailables();
            ChocobosAvailables = new ObservableCollection<Chocobo>(chocobosAvailables);
        }
        private void ChocoboAdd_Click(object sender, RoutedEventArgs e) {
            ChocoboEditWindow chocoboEditWindow = new ChocoboEditWindow();
            chocoboEditWindow.Show();
            this.Close();
        }

        private void ChocoboModify_Click(object sender, RoutedEventArgs e) {
            if (SelectedChocobo == null) {
                MessageBox.Show("Sélectionner un chocobo à modifier ! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ChocoboEditWindow chocoboEditWindow = new ChocoboEditWindow(SelectedChocobo);
            chocoboEditWindow.Show();
            this.Close();
        }
        private void ChocoboDelete_Click(object sender, RoutedEventArgs e) {
            if (SelectedChocobo == null) {
                MessageBox.Show("Sélectionner un chocobo à relâcher ! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _chocoboDAO.DeleteChocobo(SelectedChocobo);
            ChocobosAvailables.Remove(SelectedChocobo);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // Lancé à chaque fois que je clique sur un élément
            if (SelectedStable != null && SelectedStable.Id != 0) {
                List<Chocobo> stableChocobos = _chocoboDAO.GetStableChocobosByStableId(SelectedStable.Id);
                StableChocobos = new ObservableCollection<Chocobo>(stableChocobos);
            }
            if (SelectedTrainer != null && SelectedTrainer.Id != 0) {
                List<Stable> trainerStable = _stableDAO.GetStableByTrainerId(SelectedTrainer.Id);
                TrainerStables = new ObservableCollection<Stable>(trainerStable);
            }
        }
    }
}
