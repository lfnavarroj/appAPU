using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    public class clsEmpresas
    {
        private int _telefono_empresa;
        private string _nombre_empresa;
        private int _nit_empresa;

        public int Telefono_empresa { get => _telefono_empresa; set => _telefono_empresa = value; }
        public string Nombre_empresa { get => _nombre_empresa; set => _nombre_empresa = value; }
        public int Nit_empresa { get => _nit_empresa; set => _nit_empresa = value; }
    }
}
