using System;
using System.Collections.Generic;
using System.Text;

namespace ENTITY
{
    class Peso
    {
        public List<Pesos> Valores { get; set; }
    }
    public class Pesos
    {
        public string Id { get; set; }
        public double Valor { get; set; }
    }
}
