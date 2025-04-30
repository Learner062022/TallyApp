using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        readonly MainPageModel model;
        string _numberEntered = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<string> NumbersEntered { get; }

        public MainPageViewModel()
        {
            model = new MainPageModel();
            NumbersEntered = new ObservableCollection<string>();
            ButtonCommand = new Command<string>(UpdateNumberEntered);
            AddCommand = new Command(AddNumber);
            ClearCommand = new Command(Clear);
        }

        public ICommand ButtonCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand ClearCommand { get; }

        public string NumberEntered
        {
            get => _numberEntered;
            set
            {
                if (_numberEntered != value)
                {
                    _numberEntered = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FormattedNumbers));
                }
            }
        }

        public int Total => model.GetTotal();

        public string FormattedNumbers
        {
            get
            {
                var formattedNumbers = string.Empty;

                if (NumbersEntered.Count > 0)
                    formattedNumbers = string.Join("\n+ ", NumbersEntered);

                if (!string.IsNullOrEmpty(NumberEntered))
                    formattedNumbers += (NumbersEntered.Count > 0 ? "\n+ " : "") + NumberEntered;

                return formattedNumbers;
            }
        }

        public void UpdateNumberEntered(string text)
        {
            if (text == "+")
                AddCurrentNumberToCollection();
            else
                NumberEntered += text;
        }

        private void AddCurrentNumberToCollection()
        {
            if (!string.IsNullOrEmpty(NumberEntered))
            {
                NumbersEntered.Add(NumberEntered);
                NumberEntered = string.Empty;
                OnPropertyChanged(nameof(FormattedNumbers));
            }
        }

        public void AddNumber()
        {
            if (int.TryParse(NumberEntered, out int result))
            {
                model.AddNumber(result);
                NumbersEntered.Add(NumberEntered);
                NumberEntered = string.Empty;
                OnPropertyChanged(nameof(Total));
                OnPropertyChanged(nameof(FormattedNumbers));
            }
        }

        public void Clear()
        {
            model.ClearNumbers();
            NumbersEntered.Clear();
            NumberEntered = string.Empty;
            OnPropertyChanged(nameof(Total));
            OnPropertyChanged(nameof(FormattedNumbers));
        }
    }
}