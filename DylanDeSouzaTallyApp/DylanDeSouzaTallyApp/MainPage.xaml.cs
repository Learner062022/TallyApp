using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public partial class MainPage : ContentPage
    {
        readonly MainPageViewModel viewModel = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
            SizeChanged += OnMainPageSizeChanged;
        }

        void OnMainPageSizeChanged(object sender, EventArgs e)
        {
            bool isPortrait = Height > Width;

            var layouts = isPortrait
                ? new (Grid grid, int row, int column, int rowSpan, int columnSpan)[]
                {
            (editorGrid, 0, 0, 1, 2),
            (keypad, 1, 0, 1, 2)
                }
                : new (Grid grid, int row, int column, int rowSpan, int columnSpan)[]
                {
            (editorGrid, 0, 0, 2, 1),
            (keypad, 0, 1, 2, 1)
                };

            foreach (var (grid, row, column, rowSpan, columnSpan) in layouts)
                ConfigureLayout(grid, row, column, rowSpan, columnSpan);
        }

        void ConfigureLayout(Grid grid, int row, int column, int rowSpan, int columnSpan)
        {
            Grid.SetRow(grid, row);
            Grid.SetColumn(grid, column);
            Grid.SetRowSpan(grid, rowSpan);
            Grid.SetColumnSpan(grid, columnSpan);
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (int.TryParse(button.Text, out _))
                    viewModel.UpdateNumberEntered(button.Text);
                else
                {
                    switch (button.Text)
                    {
                        case "+":
                            viewModel.AddNumber();
                            break;
                        case "C":
                            viewModel.Clear();
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