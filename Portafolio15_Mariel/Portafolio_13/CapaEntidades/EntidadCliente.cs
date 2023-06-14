using System;

namespace CapaEntidades
{
    public class EntidadCliente
    {
        #region  Atributos
        private int id_cliente;
        private string nombre;
        private string telefono;
        private string direccion;
        private bool existe;
        #endregion

        //propiedades
        #region Propiedades
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion

        #region Constructores
        public EntidadCliente()
        {
            this.id_cliente = 0;
            this.nombre = string.Empty;
            this.telefono = string.Empty;
            this.direccion = string.Empty;
            this.existe = false;
        }

        public EntidadCliente(int id_cliente,string nombre,string telefono,string direccion,bool existe)
        {
            this.id_cliente = id_cliente;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.existe = existe;
        }
        #endregion

        #region Metodos
        #endregion

    }
}
