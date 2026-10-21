
using System;
using System.Windows;

namespace forlularzwpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string imie = FirstNameTextBox.Text;
            string nazwisko = LastNameTextBox.Text;
            string wiekTekst = AgeTextBox.Text;
            string informacje = AdditionalInfoTextBox.Text;

            if (string.IsNullOrWhiteSpace(imie) ||
                string.IsNullOrWhiteSpace(nazwisko) ||
                string.IsNullOrWhiteSpace(wiekTekst))
            {
                StatusTextBlock.Text = "Uzupełnij imię, nazwisko i wiek!";
                return;
            }

            if (!int.TryParse(wiekTekst, out int wiek) || wiek <= 0)
            {
                StatusTextBlock.Text = "Podaj prawidłowy wiek!";
                return;
            }

            if (!MaleRadioButton.IsChecked == true &&
                !FemaleRadioButton.IsChecked == true)
            {
                StatusTextBlock.Text = "Wybierz płeć!";
                return;
            }

            string plec = MaleRadioButton.IsChecked == true
                ? "Mężczyzna"
                : "Kobieta";

            if (BirthDatePicker.SelectedDate == null)
            {
                StatusTextBlock.Text = "Wybierz datę urodzenia!";
                return;
            }

            DateTime dataUrodzenia = BirthDatePicker.SelectedDate.Value;

            if (dataUrodzenia.Date > DateTime.Today)
            {
                StatusTextBlock.Text =
                    "Data urodzenia nie może być z przyszłości!";
                return;
            }

            StatusTextBlock.Text =
                $"Zapisano dane użytkownika:\n" +
                $"Imię: {imie}\n" +
                $"Nazwisko: {nazwisko}\n" +
                $"Wiek: {wiek}\n" +
                $"Płeć: {plec}\n" +
                $"Data urodzenia: {dataUrodzenia:dd.MM.yyyy}\n" +
                $"Dodatkowe informacje: {informacje}";
        }
    }
}
