using System.Collections.Generic;

namespace CalculatorWeb.ViewModels.Home
{
    public class CalcViewModel
    {
        public CalcViewModel()
        {
            this.Rows = new List<List<string>>();

            this.Rows.Add(new List<string>() { "7", "8", "9", "X" });
            this.Rows.Add(new List<string>() { "4", "5", "6", "-" });
            this.Rows.Add(new List<string>() { "1", "2", "3", "+" });
            this.Rows.Add(new List<string>() { "0", null, ",", "=" });
        }

        public List<List<string>> Rows { get; set; }

        public double Result { get; set; }
    }
}