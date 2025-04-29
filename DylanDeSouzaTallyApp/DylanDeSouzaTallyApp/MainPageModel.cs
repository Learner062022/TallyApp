using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DylanDeSouzaTallyApp
{
    public class MainPageModel
    {
        public List<int> Numbers { get; set; }
        public MainPageModel() => Numbers = new List<int>();
        public void AddNumber(int number) => Numbers.Add(number);
        public void ClearNumbers() => Numbers.Clear();
        public int GetTotal() => Numbers.Sum();
    }
}