using System.Windows;
using System.Windows.Input;

namespace Guenji_Care
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Dropdown-Menü mit Beispiel-Standorten (später dynamisch laden)
            StandortDropdown.Items.Add("Standort A");
            StandortDropdown.Items.Add("Standort B");
            StandortDropdown.Items.Add("Standort C");

            // Initialisierung der Buttons (nicht eingeloggt)
            SetButtonStates(false);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Einfache Authentifizierung (später durch Datenbank ersetzen)
            if (username == "admin" && password == "1234")
            {
                MessageBox.Show("Login erfolgreich!", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);

                // Aktiviere die Buttons und das Dropdown-Menü
                SetButtonStates(true);
                StandortDropdown.IsEnabled = true;

                // Simuliere Auswahl eines Standorts (später dynamisch)
                StandortDropdown.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Ungültiger Benutzername oder Passwort", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Schließt das Fenster
            this.Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Minimiert das Fenster
            this.WindowState = WindowState.Minimized;
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Blockiert das Verschieben des Fensters, wenn auf die Buttons geklickt wird
            e.Handled = false; // Erlaubt das Weiterleiten des Events zum Click-Handler
        }

        // Methode zum Aktivieren/Deaktivieren der Buttons
        private void SetButtonStates(bool isEnabled)
        {
            DienstplanButton.IsEnabled = isEnabled;
            DokumentationButton.IsEnabled = isEnabled;
            MedikamenteButton.IsEnabled = isEnabled;
            PatientenButton.IsEnabled = isEnabled;
            AbrechnungButton.IsEnabled = isEnabled;
            AdministratorButton.IsEnabled = isEnabled;
            BetreuungButton.IsEnabled = isEnabled;
            MitarbeiterButton.IsEnabled = isEnabled;
            LeistungsnachweisButton.IsEnabled = isEnabled;
            VerordnungenButton.IsEnabled = isEnabled;
            FirmenButton.IsEnabled = isEnabled;
            ÜbergabebuchButton.IsEnabled = isEnabled;
        }
    }
}