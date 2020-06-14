using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    class clsCostos
    {
        private char _id_costo;
        private string _descripcíon_costo;
        private float _valor_costo;
        private string unidad_costo;

        public char Id_costo { get => _id_costo; set => _id_costo = value; }
        public string Descripcíon_costo { get => _descripcíon_costo; set => _descripcíon_costo = value; }
        public float Valor_costo { get => _valor_costo; set => _valor_costo = value; }
        public string Unidad_costo { get => unidad_costo; set => unidad_costo = value; }

        public void agregarcosto()
        {
        }
        public void eliminarcosto()
        {
        }
        public void especificarcosto()
        {
        }


    }
}
