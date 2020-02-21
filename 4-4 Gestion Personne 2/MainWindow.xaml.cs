using DataLibrary;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _5_Gestion_Personne_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region VARIABLES MEMBRE et PROPRIETES
        // Instancier une collection qui contient les objets de type Personne
        private ObservableCollection<Personne> _listPersonne;
        public ObservableCollection<Personne> ListPersonne
        {
            get { return _listPersonne; }
            set { _listPersonne = value; }
        }
        
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            ListPersonne = new ObservableCollection<Personne>();
            LB4.ItemsSource = ListPersonne;
        }

        private void AppuyerButton_Click(object sender, RoutedEventArgs e)
        {
            if (NomTB.Text.Length < 1 || PrenomTB.Text.Length < 1)
            {
                MessageBox.Show("Erreur d'encodage du nom ou du prénom", "Error message",
                        MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            }
            else
            {
                AppuyerButton.Foreground = Brushes.Red;
                
                // Ajouter une chaîne de caractère à la collection dela première LB
                LB1.Items.Add(PrenomTB.Text + " " + NomTB.Text);

                // Créer un objet Personne puis ajouter une chaîne de caractère à la collection créée à partir de ToString()
                Personne p = new Personne(NomTB.Text, PrenomTB.Text);
                LB2.Items.Add(p.ToString());

                // Créer un objet Personne puis l'ajouter à la collection créée
                LB3.Items.Add(p);

                // Faut-il faire qqch pour que la listBox 4 se mette à jour quand j'ajoute un objet dedans ?
                ListPersonne.Add(p);
            }
        }

        private void LB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = e.AddedItems[0] as string;
            LabelLB1.Content = "Type =" + s.GetType() + " ; " + s.ToString();
        }

        private void LB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = e.AddedItems[0] as string;
            LabelLB2.Content = "Type =" + s.GetType() + " ; " + s.ToString();
        }

        private void LB3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Personne p = e.AddedItems[0] as Personne;
            LabelLB3.Content = "Type =" + p.GetType() + " ; " + p.ToString();

            NomTB.Text = p.Nom;
            PrenomTB.Text = p.Prenom;
        }

        private void CapitalLettersButton_Click(object sender, RoutedEventArgs e)
        {
            Personne p = LB3.SelectedItem as Personne;
            if (p != null)
            {
                if (p.Nom[0] >= 'a' && p.Nom[0] <= 'z')
                    p.Nom = p.Nom.ToUpper();
                else
                    p.Nom = p.Nom.ToLower();

                if (p.Prenom[0] >= 'a' && p.Nom[0] <= 'z')
                    p.Prenom = p.Prenom.ToUpper();
                else
                    p.Prenom = p.Prenom.ToLower();
                NomTB.Text = p.Nom;
                PrenomTB.Text = p.Prenom;

                // Reset de la ListBox 4 pour affichage en Temps réel de la modification
                // Code pas très joli mais temporairement efficace
                LB4.ItemsSource = null;
                LB4.ItemsSource = ListPersonne;
            }
        }

        private void LB4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count < 1)
                return;
            Personne p = e.AddedItems[0] as Personne;
            LabelLB4.Content = "Type =" + p.GetType() + " ; " + p.ToString();

            // Version 1 : mise à jour des TextBox en fonction de l'élément sélectionné 
            PrenomTB.Text = p.Prenom;
            NomTB.Text = p.Nom;
        }
    }
}

