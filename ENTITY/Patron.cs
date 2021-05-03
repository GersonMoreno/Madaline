using System;
using System.Collections.Generic;
using System.Text;

namespace ENTITY
{
    public class Patron
    {
        public List<double> Entradas { get; set; }
        public Patron(string Values)
        {
            if (Values != "")
            {
                Entradas = new List<double>();
                Values = Values.Trim();
                var Split = Values.Split(';');
                foreach (var item in Split)
                {
                    Entradas.Add(Double.Parse(item));
                }
            }
        }
    }
  
}
