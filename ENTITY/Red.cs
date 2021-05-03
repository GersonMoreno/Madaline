using System;
using System.Collections.Generic;
using System.Text;

namespace ENTITY
{
    public class Red
    {
        public List<Patron> Patrones { get; set; }
        public List<Peso> Pesos { get; set; }
        public List<Umbral> Umbrales { get; set; }
        public List<Capa> Capas { get; set; }
        public List<Salida> Salidas { get; set; }
        public double Rata { get; set; }
        public int Iteraciones { get; set; }
        public double ErrorMaximo { get; set; }
        public Red()
        {
            Patrones = new List<Patron>();
            Pesos = new List<Peso>();
            Umbrales = new List<Umbral>();
            Capas = new List<Capa>();
            Salidas = new List<Salida>();
        }
        public void SetConfig(string Value)
        {
            if (Value != "")
            {
                Value = Value.Trim();
                var Split = Value.Split(';');
                Iteraciones = Int32.Parse(Split[0]);
                Rata = Double.Parse(Split[1]);
                ErrorMaximo = Double.Parse(Split[2]);
            }
        }
    }
}
