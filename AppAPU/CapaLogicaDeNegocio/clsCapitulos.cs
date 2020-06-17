using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    public class clsCapitulos
    {
        private string _id_capitulo;
        private string _descripcion_capitulo;

        public string Id_capitulo { get => _id_capitulo; set => _id_capitulo = value; }
        public string Descripcion_capitulo { get => _descripcion_capitulo; set => _descripcion_capitulo = value; }
    }
}
