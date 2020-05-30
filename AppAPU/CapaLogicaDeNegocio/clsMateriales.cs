using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias a las otras capas
using CapaDeDatos;

namespace CapaLogicaDeNegocio
{
    public class clsMateriales
    {
        //Atributos
        private int _cod_material;
        private string _nombre_material;
        private float _precio_material;

        //Propiedades
        public int Cod_material { get => _cod_material; set => _cod_material = value; }
        public string Nombre_material { get => _nombre_material; set => _nombre_material = value; }
        public float Precio_material { get => _precio_material; set => _precio_material = value; }
    }
}
