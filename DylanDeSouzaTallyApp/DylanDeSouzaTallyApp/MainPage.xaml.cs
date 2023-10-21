using System;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SizeChanged += MainPageSizeChanged;
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
            TalliedNumbers.CreateNum(button);
            TalliedNumbers.AddNum(button);
            if (button.Text == "+")
            {
                string item = TalliedNumbers.GetLastNum();
                TalliedNumbers.DspLastNum(talliedNums, item);
                TalliedNumbers.SumNums(item);
                TalliedNumbers.DspSum(totalAmount);
            }
            if (button.Text == "C")
            {
                TalliedNumbers.Reset(talliedNums, totalAmount);
            }
        }
    }
}
