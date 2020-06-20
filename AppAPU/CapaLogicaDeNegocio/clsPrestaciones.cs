using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    public class clsPrestaciones
    {

        private int _codigo_prestacion;
        private string _descripcion_prestacion;
        private string _unidad_prestacion;
        private float _valor_prestacion;

        public int Codigo_prestacion { get => _codigo_prestacion; set => _codigo_prestacion = value; }
        public string Descripcion_prestacion { get => _descripcion_prestacion; set => _descripcion_prestacion = value; }
        public string Unidad_prestacion { get => _unidad_prestacion; set => _unidad_prestacion = value; }
        public float Valor_prestacion { get => _valor_prestacion; set => _valor_prestacion = value; }


        public void EliminiarPrestacion()
        {

        }
    }
}
