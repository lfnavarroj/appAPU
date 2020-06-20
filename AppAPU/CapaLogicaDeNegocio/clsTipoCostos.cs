using System;
namespace CapaLogicaDeNegocio
{
    public class clsTipoCostos
    {

        private int id_tipo;
        private string descripcion_tipo_costo;

        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
        public string Descripcion_tipo_costo { get => descripcion_tipo_costo; set => descripcion_tipo_costo = value; }
    }

}