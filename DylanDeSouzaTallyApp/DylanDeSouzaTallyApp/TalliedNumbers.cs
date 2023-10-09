using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DylanDeSouzaTallyApp
{
    public static class TalliedNumbers
    {
        private static List<string> lstTalliedNums = new List<string>();
        private static int sum = 0;
        private static string num;
        private static int tallies = 0;

        public static void CreateNum(Button button)
        {
            if (button.Text != "C" && button.Text != "+")
            {
                if (num == null)
                {
                    num = button.Text;
                }
                else
                {
                    num += button.Text;
                }
            }
        }

        public static void AddNum(Button button)
        {
            if (num != null)
            {
                if (button.Text == "+")
                {
                    lstTalliedNums.Add(num);
                    num = null;
                }
            }
        }

        public static string GetLastNum()
        {
            int countNums = lstTalliedNums.Count();
            string num = null;
            if (countNums >= 1)
            {
                int index = countNums - 1;
                num = lstTalliedNums[index];
            }
            return num;
        }

        public static void DspLastNum(Editor editor, string num)
        {
            if (tallies == 0)
            {
                editor.Text += num + "\n";
                tallies += 1;
            }
            else
            {
                editor.Text += "+ " + num + "\n";
                tallies += 1;
            }
        }

        public static void SumNums(string num)
        {
            sum += int.Parse(num);
        }

        public static void DspSum(Label label)
        {
            label.Text = sum.ToString();
        }

        public static void Reset(Editor editor)
        {
            lstTalliedNums.Clear();
            sum = 0;
            num = null;
            tallies = 0;
            editor.Text = string.Empty;
        }
    }
}
