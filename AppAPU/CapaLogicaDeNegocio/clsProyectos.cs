using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    class clsProyectos
    {
        private int _id_proyecto;
        private string _nombre_proyecto;
        private string _descripcion_proyecto;

        public int Id_proyecto { get => _id_proyecto; set => _id_proyecto = value; }
        public string Nombre_proyecto { get => _nombre_proyecto; set => _nombre_proyecto = value; }
        public string Descripcion_proyecto { get => _descripcion_proyecto; set => _descripcion_proyecto = value; }
    }
}
