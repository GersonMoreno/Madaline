using System;
using System.Collections.Generic;
using System.Text;

namespace ENTITY
{
    public class Salida
    {
        public List<double> Valores { get; set; }
        public Salida(string Values)
        {
            if (Values != "")
            {
                Valores = new List<double>();
                Values = Values.Trim();
                var Split = Values.Split(';');
                foreach (var item in Split)
                {
                    Valores.Add(Double.Parse(item));
                }
            }
        }
    }
}
