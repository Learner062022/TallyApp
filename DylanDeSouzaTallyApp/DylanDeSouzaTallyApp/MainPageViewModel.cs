using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly MainPageModel _model;
        private string _numberEntered;
        private string _numericString;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<string> NumbersEntered { get; }

        public MainPageViewModel()
        {
            _model = new MainPageModel();
            NumbersEntered = new ObservableCollection<string>();
            ButtonCommand = new Command<string>(UpdateNumberEntered);
            AddCommand = new Command(AddNumber);
            ClearCommand = new Command(Clear);
        }

        public ICommand ButtonCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand ClearCommand { get; }

        public string NumericString
        {
            get => _numericString;
            set
            {
                if (_numericString != value)
                {
                    _numericString = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NumberEntered
        {
            get => _numberEntered;
            set
            {
                if (_numberEntered != value)
                {
                    _numberEntered = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Total => _model.GetTotal();

        public void UpdateNumericString()
        {
            NumericString = NumbersEntered.Count == 0 && string.IsNullOrEmpty(NumberEntered)
                ? string.Empty
                : GenerateNumericString();
        }

        private string GenerateNumericString()
        {
            var numericString = string.Join("\n+ ", NumbersEntered);

            if (!string.IsNullOrEmpty(NumberEntered))
            {
                numericString += (NumbersEntered.Count > 0 ? " " : string.Empty) + NumberEntered;
            }
            else if (NumbersEntered.Count > 0)
            {
                numericString += "\n+ ";
            }

            return numericString;
        }

        public void UpdateNumberEntered(string text)
        {
            if (int.TryParse(text, out _))
            {
                NumberEntered += text;
                UpdateNumericString();
            }
            else if (text == "+") AddCurrentNumberToCollection();
        }

        private void AddCurrentNumberToCollection()
        {
            if (!string.IsNullOrEmpty(NumberEntered))
            {
                NumbersEntered.Add(NumberEntered);
                NumberEntered = string.Empty;
                UpdateNumericString();
            }
        }

        public void AddNumber()
        {
            if (int.TryParse(NumberEntered.Replace("+ ", ""), out int result))
            {
                _model.AddNumber(result);
                NumbersEntered.Add(NumberEntered);
                NumericString = string.Join("\n+ ", NumbersEntered);
                NumberEntered = string.Empty;
                NotifyPropertiesChanged(nameof(Total), nameof(NumericString));
            }
        }

        public void Clear()
        {
            _model.ClearNumbers();
            NumbersEntered.Clear();
            NumberEntered = string.Empty;
            NumericString = string.Empty;
            NotifyPropertiesChanged(nameof(Total), nameof(NumericString));
        }

        void NotifyPropertiesChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                OnPropertyChanged(propertyName);
            }
        }
    }
}