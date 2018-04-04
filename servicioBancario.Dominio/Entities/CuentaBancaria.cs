using System;
using servicioBancario.Dominio.Contracts;

namespace servicioBancario.Dominio.Entities
{
    public abstract class CuentaBancaria: IServicioFinanciero
    {
        //Attributes
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        protected decimal Saldo { get; set; }

        //Methods
        public abstract string Consignar(decimal valor, DateTime fecha, string ciudad);
        public abstract string Retirar(decimal valor, DateTime fecha, string ciudad);
        public abstract decimal GetSaldo();
    }
}
