using System;

namespace servicioBancario.Dominio.Contracts
{
    public interface IServicioFinanciero
    {
        string Consignar(decimal valor, DateTime fecha, string ciudad);
        string Retirar(decimal valor, DateTime fecha, string ciudad);
    }
}
