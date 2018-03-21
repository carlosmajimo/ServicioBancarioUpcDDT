using System;
namespace servicioBancario.Dominio.Entities
{
    public class CuentaCorriente: CuentaBancaria
    {

        public string numero { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        protected decimal saldo { get; set; }
        protected decimal cupo { get; set; }

        public CuentaCorriente(string numero, string nombre, decimal saldo, decimal cupo)
        {
            this.numero = numero;
            this.nombre = nombre;
            this.ciudad = "Valledupar";
            this.saldo = saldo;
            this.cupo = cupo;
        }

        public CuentaCorriente(string numero, string nombre, string ciudad, decimal saldo, decimal cupo)
        {
            this.numero = numero;
            this.nombre = nombre;
            this.ciudad = ciudad;
            this.saldo = saldo;
            this.cupo = cupo;
        }

        public override string Consignar(decimal valor, DateTime fecha, string ciudad)
        {
            if (valor <= 0)
            {
                return "El valor a consignar es incorrecto";
            }

            if (saldo == 0 && valor >= 100000)
            {
                this.saldo += valor;
                return $"Su Nuevo Saldo es de ${saldo} pesos m/c";
            }

            if (saldo == 0 && valor < 100000)
            {
                this.saldo = 0;
                return "El valor mínimo de la primera consignación debe ser de $100000 pesos. Su nuevo saldo es $0 pesos";
            }

            if (saldo > 0)
            {
                this.saldo += valor;
                return $"Su Nuevo Saldo es de ${saldo} pesos m/c";
            }

            throw new NotImplementedException();
        }
        public override string Retirar(decimal valor, DateTime fecha, string ciudad)
        {
            throw new NotImplementedException();
        }
    }
}
