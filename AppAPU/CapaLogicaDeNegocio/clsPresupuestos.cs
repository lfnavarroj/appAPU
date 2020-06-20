using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    public class clsPresupuestos
    {
        private int _fecha_realizacion;
        private string _descripcion_presupuesto;
        private string _estado_del_presupuesto;
        private int _id_presupuesto;

        public int Fecha_realizacion { get => _fecha_realizacion; set => _fecha_realizacion = value; }
        public string Descripcion_presupuesto { get => _descripcion_presupuesto; set => _descripcion_presupuesto = value; }
        public string Estado_del_presupuesto { get => _estado_del_presupuesto; set => _estado_del_presupuesto = value; }
        public int Id_presupuesto { get => _id_presupuesto; set => _id_presupuesto = value; }
    }
}
