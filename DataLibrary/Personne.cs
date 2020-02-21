using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataLibrary
{
    public class Personne : INotifyPropertyChanged
    {
        #region var membre et propriétés

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    //NotifyPropertyChanged();
                }
            }
        }

        private string _prenom;
        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    //NotifyPropertyChanged();
                }
            }
        }

        #endregion
        public Personne() : this("", "")
        { }
        
        public Personne(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public override string ToString()
        {
            return Nom + " " + Prenom + " ";
        }

        public bool IsValid()
        {
            if (Nom.Length > 0 && Prenom.Length > 0)
                return true;
            else
                return false;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
