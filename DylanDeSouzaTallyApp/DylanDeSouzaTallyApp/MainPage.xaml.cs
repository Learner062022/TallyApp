using System;
using System.Security.Cryptography;
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
                firstColumn.Width = new GridLength(1, GridUnitType.Star);
                secondColumn.Width = new GridLength(0);
            }
            else
            {
                firstColumn.Width = new GridLength(1, GridUnitType.Star);
                secondColumn.Width = new GridLength(1, GridUnitType.Star);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
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
                TalliedNumbers.Reset(talliedNums);
            }
        }
    }
}
