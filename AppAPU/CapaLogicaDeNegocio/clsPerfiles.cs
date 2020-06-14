using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    class clsPerfiles
    {
        private string _id_perfil;
        private string _nombre_perfil;

        public string Id_perfil { get => _id_perfil; set => _id_perfil = value; }
        public string Nombre_perfil { get => _nombre_perfil; set => _nombre_perfil = value; }
    }
}
