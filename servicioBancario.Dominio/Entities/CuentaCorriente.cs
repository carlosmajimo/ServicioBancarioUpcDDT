using System;
namespace servicioBancario.Dominio.Entities
{
    public class CuentaCorriente: CuentaBancaria
    {
        
        protected decimal Cupo { get; set; }

        public CuentaCorriente(string numero, string nombre, decimal saldo, decimal cupo)
        {
            this.Numero = numero;
            this.Nombre = nombre;
            this.Ciudad = "Valledupar";
            this.Saldo = saldo;
            this.Cupo = cupo;
        }

        public CuentaCorriente(string numero, string nombre, string ciudad, decimal saldo, decimal cupo)
        {
            this.Numero = numero;
            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.Saldo = saldo;
            this.Cupo = cupo;
        }

		public override decimal GetSaldo()
		{
            return this.Saldo;
		}

		public override string Consignar(decimal valor, DateTime fecha, string ciudad)
        {
            /*if (valor <= 0)
            {
                return "El valor a consignar es incorrecto";
            }

            if (this.Saldo == 0 && valor >= 100000)
            {
                this.Saldo += valor;
                return $"Su Nuevo Saldo es de ${ this.Saldo.ToString("N") } pesos m/c";
            }

            if (this.Saldo == 0 && valor < 100000)
            {
                this.Saldo = 0;
                return "El valor mínimo de la primera consignación debe ser de $100,000.00 pesos.";
            }

            if (this.Saldo > 0)
            {
                this.Saldo += valor;
                return $"Su Nuevo Saldo es de ${ this.Saldo.ToString("N") } pesos m/c";
            }

            throw new NotImplementedException();*/

            if (valor <= 0)
            {
                return "El valor a consignar es incorrecto";
            }

            if (this.Saldo == 0 && valor < 100000)
            {
                this.Saldo = 0;
                return "El valor mínimo de la primera consignación debe ser de $100,000.00 pesos.";
            }

            if (this.Saldo >= 0)
            {
                this.Saldo += valor;
                return $"Su Nuevo Saldo es de ${ this.Saldo.ToString("N") } pesos m/c";
            }

            throw new NotImplementedException();

        }
        public override string Retirar(decimal valor, DateTime fecha, string ciudad)
        {
            if (valor <= 0)
            {
                return "El valor a retirar es incorrecto";
            }

            if ( CalcularRetiro(valor) < this.Cupo*-1)
            {
                return $"El valor a retirar es incorrecto, el saldo minimo en cuenta es de $-{ this.Cupo.ToString("N") } pesos m/c";
            }

            if (CalcularRetiro(valor) >= this.Cupo * -1)
            {
                this.Saldo = CalcularRetiro(valor);
                return $"Su Nuevo Saldo es de ${ this.Saldo.ToString("N") } pesos m/c";
            }
            throw new NotImplementedException();
        }


        private decimal CalcularRetiro(decimal valor){
            decimal newSaldo;

            valor +=  valor * 0.004m;
            newSaldo = this.Saldo - valor;
            return newSaldo;
        }

    }
}
