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

    public partial class StableEditWindow : Window, INotifyPropertyChanged {


        private readonly IStableDAO _stableDAO;
        private readonly IChocoboDAO _chocoboDAO;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
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

        private Stable _stable;
        public Stable Stable {
            get { return _stable; }
            set {
                _stable = value;
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

        private ObservableCollection<Chocobo> _chocobosAvailables;

        public ObservableCollection<Chocobo> ChocobosAvailables {
            get { return _chocobosAvailables; }
            set { _chocobosAvailables = value;
                OnPropertyChanged();
            }
        }
        public StableEditWindow() {
            InitializeComponent();
            DataContext = this;
            Stable = new Stable();
            _stableDAO = new StableDAO();
            _chocoboDAO = new ChocoboDAO();
            var chocobos = _chocoboDAO.GetChocobos();
            Chocobos = new ObservableCollection<Chocobo>(chocobos);

            List<Chocobo> chocobosAvailables = _chocoboDAO.GetChocobosAvailables();
            ChocobosAvailables = new ObservableCollection<Chocobo>(chocobosAvailables);

        }
        public StableEditWindow(Stable stable) : this() {
            Stable = stable;
            List<Chocobo> stableChocobos = _chocoboDAO.GetStableChocobosByStableId(Stable.Id);
            StableChocobos = new ObservableCollection<Chocobo>(stableChocobos);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddChocobo_Click(object sender, RoutedEventArgs e) {
            if (SelectedChocobo == null) {
                MessageBox.Show("Sélectionner un chocobo à ajouter ! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (StableChocobos.Any(p => p.Id == SelectedChocobo.Id)) {
                MessageBox.Show("Cette étable contient déjà ce chocobo. Veuillez en choisir un autre !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SelectedChocobo.StableId = Stable.Id;
            _chocoboDAO.AddStableChocobo(SelectedChocobo);
            
            // Mettre à jour les chocobos dans la collection l'écurie quand celui-ci est ajouté
            StableChocobos.Add(SelectedChocobo);

            ChocobosAvailables.Remove(SelectedChocobo);
            // Mettre à jour les chocobos dans la collection l'écurie quand celui-ci est ajouté
           

            // Permettre sauvegarde et ajouter ->
            // Uniquement l'ajouter dans la collection mais la jointure la faire quand c'est "Ok" => Sauvegarder
            // Attention BDD erreur !!!!!!!! 
            // Pour permettre l'ajour et la sauvegarde " en même temps "
            // Quand je sauvegarde l'étable, va remplir l'identifiant dans l'observable et quand j'appuie sur save génère un id et je parcours la collection et j'applique un update de chocobo. Si y a des chocobos qui ont déjà l'id, déjà associé
            // à l'étable. Si stable == null, chocobo libre. 

            // OU
            // Contexte déconnecté -> Quand je fais un new contexte au lieu de récupérer le même. Le new context il sait pas d'où il vient le chocobo. N'est pas responsable du chargement de chocobo. Donc pas """ connecté """
            // Pas sûr que ça marche. 
            // Si je vois dans mon étable il y a une liste de chocobo etable.chocobo.add(le chocobo en question) et quand je fais un save du chocobo dans l'étable. 

            // ==> Pas implémenté
        }
        private void SaveStableModification_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(Stable.StableName) || (string.IsNullOrWhiteSpace(Stable.Description))) {
                MessageBox.Show("Pas de champ vide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                if (Stable.Id == 0) {
                    _stableDAO.AddStable(Stable);
                } else {
                    _stableDAO.ModifyStable(Stable);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void ToAdoptChocobo_Click(object sender, RoutedEventArgs e) {
            if (SelectedChocobo == null) {
                MessageBox.Show("Sélectionner un chocobo à mettre en adoption ! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SelectedChocobo.StableId = null;
            // Va update et mettre à null C'est vrai que le nom n'a pas vraiment de sens mais inutile de recrééer une méthode dans le DAO qui fait le même.
            _chocoboDAO.AddStableChocobo(SelectedChocobo);
            // Réafficher le chocobo dans ceux disponibles
            ChocobosAvailables.Add(SelectedChocobo);
            StableChocobos.Remove(SelectedChocobo);
        }
    }
}
