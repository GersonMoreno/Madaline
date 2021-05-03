using System;
using System.Xml;
using System.Collections.Generic;
using ENTITY;

namespace DALL
{
    public class Repository
    {
        public void EscribirXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

        }
        public Red LeerXml(string Path)
        {
            var Red = new Red();
            var Default = @"data.xml";
            try
            {
                using (XmlReader Reader = XmlReader.Create(Path ?? Default))
                {
                    while (Reader.Read())
                    {
                        if (Reader.IsStartElement())
                        {
                            switch (Reader.Name.ToString())
                            {
                                case "Config":
                                    var Config = Reader.ReadString().Trim();
                                    Console.WriteLine(Config);
                                    var Unidades = Config.Split(';');
                                    foreach (var Unidad in Unidades)
                                    {
                                        if (!Double.TryParse(Unidad, out _))
                                        {
                                            return null;
                                        }
                                    }
                                    if (ValidarRata(Double.Parse(Unidades[2])))
                                    {
                                        return null;
                                    }
                                    Red.SetConfig(Config);
                                    break;
                                case "Patrones":
                                    var Patrones = Reader.ReadString().Trim();
                                    Console.WriteLine(Patrones);
                                    var Split = Patrones.Split(' ');
                                    foreach (var item in Split)
                                    {
                                        var Entradas = item.Split(';');
                                        foreach (var Entrada in Entradas)
                                        {
                                            if (!Double.TryParse(Entrada, out _))
                                            {
                                                return null;
                                            }
                                        }
                                       Red.Patrones.Add(new Patron(item.Trim()));
                                    }
                                    break;
                                case "Salidas":
                                var Salidas = Reader.ReadString().Trim();
                                Console.WriteLine(Salidas);
                                Split = Salidas.Split(' ');
                                foreach (var item in Split)
                                {
                                    var salidas = item.Split(';');
                                        foreach (var Salida in salidas)
                                        {
                                            if (!Double.TryParse(Salida, out _))
                                            {
                                                return null;
                                            }
                                        }
                                    Red.Salidas.Add(new Salida(item.Trim()));
                                }
                                break;
                                case "Capas":
                                    //var Capas = Reader.ReadString().Trim();
                                    //Console.WriteLine(Capas);
                                    //Split = Capas.Split(' ');
                                    break;
                                case "Umbrales":
                                    var umbral = Reader.ReadString().Trim();

                                    break;
                                case "Pesos":
                                    //var Pesos = Reader.ReadString().Trim();
                                    //Console.WriteLine(Pesos);
                                    //Split = Pesos.Split(';');
                                    //foreach (var item in Split)
                                    //{
                                    //    if (!Double.TryParse(item, out _))
                                    //    {
                                    //        return null;
                                    //    }
                                    //    else if (ValidarPeso(Double.Parse(item)))
                                    //    {
                                    //        return null;
                                    //    }
                                    //    Red.Pesos.Valores.Add(new Peso(Double.Parse(item.Trim())));
                                    //}
                                    //if (EntradasVsPesos(Red.Patrones, Red.Pesos) || PatronesVsSalidas(Red.Salidas, Red.Patrones))
                                    //{
                                    //    return null;
                                    //}
                                    break;
                                case "Red":
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return Red;
        }
        private bool ValidarRata(double Rata)
        {
            if (Rata > 0 && Rata <= 1)
                return false;
            return true;
        }
    }
}
