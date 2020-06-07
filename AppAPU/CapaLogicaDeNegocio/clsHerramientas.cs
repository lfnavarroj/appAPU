using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaDeNegocio
{
    class clsHerramientas
    {
        private float _valor_uso_herramienta;
        private int _unidad_herramienta;
        private string _descripcion_herramienta;
        private int _codigo_herramienta;

        public float Valor_uso_herramienta { get => _valor_uso_herramienta; set => _valor_uso_herramienta = value; }
        public int Unidad_herramienta { get => _unidad_herramienta; set => _unidad_herramienta = value; }
        public string Descripcion_herramienta { get => _descripcion_herramienta; set => _descripcion_herramienta = value; }
        public int Codigo_herramienta { get => _codigo_herramienta; set => _codigo_herramienta = value; }
    }
}
