using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    class clsUnitarios
    {
        private int _id_unitario;
        private string _descripción_unitario;
        private string _unidad_medida_unitario;

        public int Id_unitario { get => _id_unitario; set => _id_unitario = value; }
        public string Descripción_unitario { get => _descripción_unitario; set => _descripción_unitario = value; }
        public string Unidad_medida_unitario { get => _unidad_medida_unitario; set => _unidad_medida_unitario = value; }
    }
}
