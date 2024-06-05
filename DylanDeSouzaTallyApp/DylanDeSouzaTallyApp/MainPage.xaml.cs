using System;
using System.Xml.Schema;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            SizeChanged += MainPageSizeChanged;
            BindingContext = _viewModel;
        }

        void MainPageSizeChanged(object sender, EventArgs e)
        {
            bool isPortrait = Height > Width;

            if (isPortrait)
            {
                
                Grid.SetRow(talliedNums, 0);
                Grid.SetColumn(talliedNums, 0);
                Grid.SetRow(keypad, 1);
                Grid.SetColumn(keypad, 0);
            }
            else
            {
                Grid.SetRow(talliedNums, 0);
                Grid.SetColumn(talliedNums, 0);
                Grid.SetRow(keypad, 0);
                Grid.SetColumn(keypad, 1);
            }
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (int.TryParse(button.Text, out int _))
            {
                _viewModel.UpdateNumberEntered(button.Text);
            }
            else
            {
                if (button.Text == "+")
                {
                    _viewModel.AddNumber();
                }
                else
                {
                    _viewModel.Clear();
                }
            }
        }
    }
}