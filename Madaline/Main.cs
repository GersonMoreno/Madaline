using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ENTITY;
using BLL;

namespace Madaline
{
    public partial class Main : Form
    {
        public Service Service { get; set; }
        public Red Red { get; set; }

        public Main()
        {
            InitializeComponent();
            Service = new Service();
            Red = new Red();
        }

        private void pnMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PnPresentacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            var Result = OFD.ShowDialog();
            if (Result == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(OFD.FileName))
                    {
                        var Rd = Service.LeerXml(OFD.FileName);
                        if (Rd != null)
                            Red  = Rd;
                        else
                            MessageBox.Show("El dataset está corrupto o está mal configurado");
                        ShowInfo(Red);
                    }
                    else
                        MessageBox.Show("Se ha eliminado o movido el archivo");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error al abrir el archivo => " + er.Message, "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (Result == DialogResult.Cancel)
            {
            }
        }
        private void ShowInfo(Red red)
        {
            NbIteracion.Value = red.Iteraciones;
            TbError.Text = ""+red.ErrorMaximo;
            TbRata.Text = ""+red.Rata;
            LbEntrada.Text = ""+red.Patrones[0].Entradas.Count;
            LbPatrones.Text = "" + red.Patrones.Count;
            LbSalidas.Text = "" + red.Salidas[0].Valores.Count;

        }

        private void LbEntrada_Click(object sender, EventArgs e)
        {

        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {

        }
        private bool ValidarCapasFuncion()
        {
          
            return true;
        }
    }
}
