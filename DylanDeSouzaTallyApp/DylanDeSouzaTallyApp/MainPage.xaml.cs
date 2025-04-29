using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public partial class MainPage : ContentPage
    {
        readonly MainPageViewModel _viewModel = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel;
            SizeChanged += OnMainPageSizeChanged;
        }

        void OnMainPageSizeChanged(object sender, EventArgs e)
        {
            bool isPortrait = Height > Width;

            if (isPortrait) ConfigureGridLayout(editorGrid, keypad, 0, 0, 1, 2, 1, 0, 1, 2);
            else ConfigureGridLayout(editorGrid, keypad, 0, 0, 2, 1, 0, 1, 2, 1);
        }

        void ConfigureGridLayout(
            Grid editorGrid, Grid keypad,
            int editorRow, int editorColumn, int editorRowSpan, int editorColumnSpan,
            int keypadRow, int keypadColumn, int keypadRowSpan, int keypadColumnSpan)
        {
            Grid.SetRow(editorGrid, editorRow);
            Grid.SetColumn(editorGrid, editorColumn);
            Grid.SetRowSpan(editorGrid, editorRowSpan);
            Grid.SetColumnSpan(editorGrid, editorColumnSpan);

            Grid.SetRow(keypad, keypadRow);
            Grid.SetColumn(keypad, keypadColumn);
            Grid.SetRowSpan(keypad, keypadRowSpan);
            Grid.SetColumnSpan(keypad, keypadColumnSpan);
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (int.TryParse(button.Text, out _))
                {
                    _viewModel.UpdateNumberEntered(button.Text);
                }
                else
                {
                    switch (button.Text)
                    {
                        case "+":
                            _viewModel.AddNumber();
                            break;
                        case "C":
                            _viewModel.Clear();
                            break;
                        default:
                            Debug.WriteLine($"Unexpected button text: {button.Text}");
                            break;
                    }
                }
            }
        }
    }
}