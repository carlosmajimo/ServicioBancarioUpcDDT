using System;
using servicioBancario.Dominio.Contracts;

namespace servicioBancario.Dominio.Entities
{
    public abstract class CuentaBancaria: IServicioFinanciero
    {
        public abstract string Consignar(decimal valor, DateTime fecha, string ciudad);
        public abstract string Retirar(decimal valor, DateTime fecha, string ciudad);
    }
}
