using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Caretest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Dropdown für Standorte füllen
            StandortDropdown.Items.Add("ElderlyCare - 41");
            StandortDropdown.Items.Add("ElderlyCare - 42");
            StandortDropdown.Items.Add("ElderlyCare - 43");
            StandortDropdown.SelectedIndex = 0; // Standardauswahl

            // Command für die Enter-Taste zuweisen
            LoginCommand = new RelayCommand(ExecuteLogin);
            DataContext = this;

            // Event-Handler für die Funktionsbuttons hinzufügen
            if (Funktion1Button != null) Funktion1Button.Click += FunktionButton_Click;
            if (Funktion2Button != null) Funktion2Button.Click += FunktionButton_Click;
            if (Funktion3Button != null) Funktion3Button.Click += FunktionButton_Click;
        }

        // Command für die Enter-Taste
        public ICommand? LoginCommand { get; }

        // Methode, die beim Drücken der Enter-Taste ausgeführt wird
        private void ExecuteLogin(object? parameter)
        {
            // Rufe den Login-Button-Handler auf
#pragma warning disable CS8625 // Ein NULL-Literal kann nicht in einen Non-Nullable-Verweistyp konvertiert werden.
            LoginButton_Click(null, null);
#pragma warning restore CS8625 // Ein NULL-Literal kann nicht in einen Non-Nullable-Verweistyp konvertiert werden.
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Überprüfen, ob alle Felder ausgefüllt sind
            if (string.IsNullOrWhiteSpace(BenutzernameEingabe?.Text) || string.IsNullOrWhiteSpace(PasswortEingabe?.Password))
            {
                MessageBox.Show("Bitte Benutzername und Passwort eingeben.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Simulierte Login-Logik
            string standort = StandortDropdown.SelectedItem?.ToString() ?? "Unbekannter Standort";
            string benutzername = BenutzernameEingabe.Text;

            // Login erfolgreich -> UI aktualisieren
            LoginContainer.Visibility = Visibility.Collapsed; // Äußerer Container ausblenden
            PostLoginInfoPanel.Visibility = Visibility.Visible; // Post-Login-Infos einblenden

            // Post-Login-Informationen anzeigen
            StandortAnzeige.Text = $"{standort}";
            BenutzernameAnzeige.Text = $"{benutzername}";

            // Funktionsbuttons aktivieren
            if (Funktion1Button != null) Funktion1Button.IsEnabled = true;
            if (Funktion2Button != null) Funktion2Button.IsEnabled = true;
            if (Funktion3Button != null) Funktion3Button.IsEnabled = true;
        }

        // Event-Handler für die Funktionsbuttons
        private void FunktionButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton && clickedButton.Content is string funktion)
            {
                // Neues Vollbildfenster erstellen und anzeigen
                VollbildFunktionWindow funktionWindow = new VollbildFunktionWindow(funktion);
                funktionWindow.WindowState = WindowState.Maximized; // Vollbildmodus
                funktionWindow.Show();
            }
        }
    }

    // RelayCommand-Implementierung
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    // Neues Fenster für die Funktionen
    public partial class VollbildFunktionWindow : Window
    {
        public VollbildFunktionWindow(string? funktion)
        {
            InitializeComponent();
            Title = funktion ?? "Unbekannte Funktion"; // Fallback-Wert, falls funktion null ist
            // Hier kannst du die spezifische Logik für die jeweilige Funktion implementieren
            // Zum Beispiel: Content = new Funktion1UserControl(); usw.
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}