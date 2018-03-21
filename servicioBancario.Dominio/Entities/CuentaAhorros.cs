using System;
namespace servicioBancario.Dominio.Entities
{
    public class CuentaAhorros: CuentaBancaria
    {
        public string numero { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        public int retiroMes { get; set; }
        protected decimal saldo { get; set; }

        public CuentaAhorros(string numero, string nombre, decimal saldo)
        {
            this.numero = numero;
            this.nombre = nombre;
            this.ciudad = "Valledupar";
            this.saldo = saldo;
        }

        public CuentaAhorros(string numero, string nombre, string ciudad,decimal saldo){
            this.numero = numero;
            this.nombre = nombre;
            this.ciudad = ciudad;
            this.saldo = saldo;
        }


        public override string Consignar(decimal valor, DateTime fecha, string ciudad){
            if (valor <= 0)
            {
                return "El valor a consignar es incorrecto";  
            }

            if (saldo == 0 && valor >= 50000)
            {
                this.saldo += valor;
                return $"Su Nuevo Saldo es de ${saldo} pesos m/c";
            }

            if (saldo == 0 && valor < 50000)
            {
                this.saldo = 0;
                return "El valor minimo de la primera consignacion debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos";
            }

            if (saldo > 0 && ciudad == this.ciudad){
                this.saldo += valor;
                return $"Su Nuevo Saldo es de ${saldo} pesos m/c";
            }

            if (saldo > 0 && ciudad != this.ciudad)
            {
                this.saldo += valor-10000;
                return $"Su Nuevo Saldo es de ${saldo} pesos m/c";
            }
            throw new NotImplementedException();
            
        }
        public override string Retirar(decimal valor, DateTime fecha, string ciudad){
            if (valor <= 0)
            {
                return "El valor a retirar es incorrecto";
            }

            if((this.saldo-valor) < 20000){
                return "El valor a retirar es incorrecto, el saldo minimo en cuenta es de $20000 pesos m/c";
            }

            if ((this.saldo - valor) >= 20000 && this.retiroMes < 3)
            {
                this.saldo -= valor;
                this.retiroMes += 1;
                return $"Su Nuevo Saldo es de ${saldo} pesos m/c";
            }

            if ((this.saldo - valor) >= 20000 && this.retiroMes >= 3)
            {
                this.saldo -= valor+5000;
                this.retiroMes += 1;
                return $"Su Nuevo Saldo es de ${saldo} pesos m/c";
            }

            throw new NotImplementedException();
        }
    }
}