using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using CapaLogicaDeNegocio;

namespace CapaDePresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsMateriales objeto = new clsMateriales();
            objeto.Cod_material = 1;
            objeto.Nombre_material = "Cable#2";
            objeto.Precio_material = 1250;

            label6.Text= ("El material creado es " + objeto.Nombre_material +" Cuesta " +objeto.Precio_material.ToString());
            //Console.ReadLine();
        }
    }
}
