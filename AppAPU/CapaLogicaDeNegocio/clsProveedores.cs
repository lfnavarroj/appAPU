using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    public class clsProveedores
    {
        //Atributos
        private int _nit_proveedor;
        private string _nombre_proveedor;
        private int _telefono_proveedor;
        private char _email_proveedor;
        private char _direccion_proveedor;

        // Propiedades
        public int Nit_proveedor { get => _nit_proveedor; set => _nit_proveedor = value; }
        public string Nombre_proveedor { get => _nombre_proveedor; set => _nombre_proveedor = value; }
        public int Telefono_proveedor { get => _telefono_proveedor; set => _telefono_proveedor = value; }
        public char Email_proveedor { get => _email_proveedor; set => _email_proveedor = value; }
        public char Direccion_proveedor { get => _direccion_proveedor; set => _direccion_proveedor = value; }

        //Metodos
        public void agregarproveedor()
        { 
        }
        public void eliminarproveedor()
        {
        }


    }
}
