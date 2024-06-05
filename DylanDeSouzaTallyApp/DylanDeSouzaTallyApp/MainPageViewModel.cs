using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        MainPageModel _model;
        string _numberEntered;
        string _numericString;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> NumbersEntered { get; set; }

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

        public void UpdateNumericString()
        {
            if (NumbersEntered.Count == 0 && string.IsNullOrEmpty(NumberEntered))
            {
                NumericString = "";
            }
            else
            {
                NumericString = string.Join("\n+ ", NumbersEntered);
                if (!string.IsNullOrEmpty(NumberEntered))
                {
                    NumericString += NumbersEntered.Count > 0 ? " " : string.Empty + NumberEntered;
                }
                else if (NumbersEntered.Count > 0)
                {
                    NumericString += "\n+ ";
                }
            }
        }

        public void UpdateNumberEntered(string text)
        {
            if (int.TryParse(text, out int _))
            {
                NumberEntered += text;
                UpdateNumericString();
            }
            else if (text == "+")
            {
                if (string.IsNullOrEmpty(NumberEntered))
                {
                    NumbersEntered.Add(NumberEntered);
                    NumberEntered = "";
                    UpdateNumericString();
                }
            }
        }

        public void AddNumber()
        {
            if (int.TryParse(NumberEntered.Replace("+ ", ""), out int result))
            {
                _model.AddNumber(result);
                NumbersEntered.Add(NumberEntered);
                NumericString = string.Join("\n+ ", NumbersEntered);
                NumberEntered = "";
                OnPropertyChanged(nameof(Total));
                OnPropertyChanged(nameof(NumericString));
            }
        }

        public int Total => _model.GetTotal();

        public void Clear()
        {
            _model.ClearNumbers();
            NumbersEntered.Clear();
            NumberEntered = "";
            NumericString = "";
            OnPropertyChanged(nameof(Total));
            OnPropertyChanged(nameof(NumericString));
        }
    }
}