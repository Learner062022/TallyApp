using System;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
                TalliedNumbers.DspSum(total);
            }
            if (button.Text == "C")
            {
                TalliedNumbers.Reset(talliedNums);
            }
        }
    }
}
