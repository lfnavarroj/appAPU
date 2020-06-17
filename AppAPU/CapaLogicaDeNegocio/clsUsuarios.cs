using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    public class clsUsuarios
    {
        private string _correo_usuario;
        private long _telefono_usuario;
        private string _id_usuario;
        private string _nombre_usuario;
        private string _apellidos_usuario;
        private string _contraseña;
        private string _perfil;

        public string Correo_usuario { get => _correo_usuario; set => _correo_usuario = value; }
        public long Telefono_usuario { get => _telefono_usuario; set => _telefono_usuario = value; }
        public string Id_usuario { get => _id_usuario; set => _id_usuario = value; }
        public string Nombre_usuario { get => _nombre_usuario; set => _nombre_usuario = value; }
        public string Apellidos_usuario { get => _apellidos_usuario; set => _apellidos_usuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Perfil { get => _perfil; set => _perfil = value; }
    }
}
