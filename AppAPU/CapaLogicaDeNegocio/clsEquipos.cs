using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    public class clsEquipos
    {
        private long _numero_de_serie;
        private string _descripcion_equipo;
        private string _unidad_equipo;
        private float _valor_uso_equipo;

        public long Numero_de_serie { get => _numero_de_serie; set => _numero_de_serie = value; }
        public string Descripcion_equipo { get => _descripcion_equipo; set => _descripcion_equipo = value; }
        public string Unidad_equipo { get => _unidad_equipo; set => _unidad_equipo = value; }
        public float Valor_uso_equipo { get => _valor_uso_equipo; set => _valor_uso_equipo = value; }

        private void agregarequipo()
        {
        }
        private void eliminarequipo()
        {
        }
        private void validarequipo()
        {
        }


    }
}
