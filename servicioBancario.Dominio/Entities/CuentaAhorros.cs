using System;
namespace servicioBancario.Dominio.Entities
{
    public class CuentaAhorros: CuentaBancaria
    {
        public int RetiroMes { get; set; }

        public CuentaAhorros(string numero, string nombre, decimal saldo)
        {
            this.Numero = numero;
            this.Nombre = nombre;
            this.Ciudad = "Valledupar";
            this.Saldo = saldo;
        }

        public CuentaAhorros(string numero, string nombre, string ciudad,decimal saldo){
            this.Numero = numero;
            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.Saldo = saldo;
        }

		public override decimal GetSaldo()
		{
            return this.Saldo;
		}

		public override string Consignar(decimal valor, DateTime fecha, string ciudad){

            if (valor <= 0)
            {
                return "El valor a consignar es incorrecto";
            }

            if (this.Saldo == 0 && valor < 50000)
            {
                return "El valor minimo de la primera consignacion debe ser de $50,000.00 mil pesos.";
            }

            if (this.Saldo >= 0)
            {
                this.Saldo = CalcularConsignacion(ciudad, valor);
                return $"Su Nuevo Saldo es de ${ this.Saldo.ToString("N") } pesos m/c";
            }

            throw new NotImplementedException();
            
        }
        public override string Retirar(decimal valor, DateTime fecha, string ciudad){

            if (valor <= 0)
            {
                return "El valor a retirar es incorrecto";
            }

            if (CalcularRetiro(valor) < 20000)
            {
                return "El valor a retirar es incorrecto, el saldo minimo en cuenta es de $20,000.00 pesos m/c";
            }

            if (CalcularRetiro(valor) >= 20000)
            {
                this.Saldo = CalcularRetiro(valor);
                this.RetiroMes += 1;
                return $"Su Nuevo Saldo es de ${ this.Saldo.ToString("N") } pesos m/c";
            }

            throw new NotImplementedException();

        }

        private decimal CalcularConsignacion(string ciudad, decimal valor)
        {
            decimal newSaldo = (ciudad == this.Ciudad) ? this.Saldo + valor : this.Saldo + valor - 10000;
            return newSaldo;
        }

        private decimal CalcularRetiro(decimal valor)
        {
            decimal newSaldo = (this.RetiroMes < 3) ? this.Saldo - valor : this.Saldo - (valor + 5000);
            return newSaldo;
        }
    }
}