using Microsoft.VisualStudio.TestTools.UnitTesting;
using servicioBancario.Dominio.Entities;
using System;

namespace servicioBancario.Dominio.test
{
    [TestClass]
    public class CuentaCorrienteTest
    {
        [TestMethod]
        public void TestConsignarValorMenorACero()
        {
            //Dado: 
            //El cliente tiene una cuenta corriente
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0

            //Cuando:
            //Va a consignar un valor -100

            //Entonces:
            //El sistema presentará el mensaje. “El valor a consignar es incorrecto”


            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 0, 200000);

            decimal valorConsignar = -100;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor a consignar es incorrecto", mensajeRespuesta);
        }

        [TestMethod]
        public void TestConsignarInicialIncorrecta()
        {
            //Dado: 
            //El cliente tiene una cuenta corriente
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0

            //Cuando:
            //Va a consignar el valor inicial de $99950 pesos

            //Entonces:
            //El sistema no registrará la consignación
            //AND presentará el mensaje. "El valor mínimo de la primera consignación debe ser de $100,000.00 pesos".

            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 0, 20000);

            decimal valorConsignar = 99950;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor mínimo de la primera consignación debe ser de $100,000.00 pesos.", mensajeRespuesta);
        }

        [TestMethod]
        public void TestConsignarInicialCorrecta()
        {
            //Dado: 
            //El cliente tiene una cuenta corriente
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0

            //Cuando:
            //Va a consignar el valor inicial de $100 mil pesos

            //Entonces:
            //El sistema registrará la consignación
            //AND presentará el mensaje. "Su Nuevo Saldo es de $100,000.00 pesos m/c".

            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 0, 20000);

            decimal valorConsignar = 100000;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $100,000.00 pesos m/c", mensajeRespuesta);
        }

        [TestMethod]
        public void TestConsignarPosteriorCorrecta()
        {
            //Dado: 
            //El cliente tiene una cuenta corriente
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de $80 mil pesos

            //Cuando:
            //Va a consignar el valor de $40 mil pesos

            //Entonces:
            //El sistema registrará la consignación
            //AND presentará el mensaje. "Su Nuevo Saldo es de $120,000.00 pesos m/c".


            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 80000, 20000);

            decimal valorConsignar = 40000;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $120,000.00 pesos m/c", mensajeRespuesta);
        }

        [TestMethod]
        public void TestValorRetiroMenorACero()
        {
            //Dado: 
            //El cliente tiene una cuenta corriente
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de $80 mil pesos

            //Cuando:
            //Va a consignar el valor de -100

            //Entonces:
            //El sistema presentará el mensaje. "El valor a retirar es incorrecto"


            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 80000, 20000);

            decimal valorRetirar = -100;
            var fechaRetiro = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Retirar(valorRetirar, fechaRetiro, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor a retirar es incorrecto", mensajeRespuesta);
        }

        [TestMethod]
        public void TestValorRetiroMayorDelMinimo()
        {
            //Dado: 
            //El cliente tiene una cuenta corriente
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 100 mil pesos,Cupo de $30 mil pesos

            //Cuando:
            //Va a retirar el valor de $130000 mil pesos

            //Entonces:
            //El sistema no registrará el retiro.
            //AND presentará el mensaje. "El valor a retirar es incorrecto, el saldo minimo en cuenta es de $-30,000.00 pesos m/c".



            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 100000, 30000);

            decimal valorRetirar = 130000;
            var fechaRetiro = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Retirar(valorRetirar, fechaRetiro, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor a retirar es incorrecto, el saldo minimo en cuenta es de $-30,000.00 pesos m/c", mensajeRespuesta);
        }


        [TestMethod]
        public void TestValorRetiroCorrecto()
        {
            //Dado: 
            //El cliente tiene una cuenta corriente
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 100 mil pesos,Cupo de $30 mil pesos

            //Cuando:
            //Va a consignar el valor de $120000 mil pesos

            //Entonces:
            //El sistema registrará el retiro restando $120480 pesos al saldo.
            //AND presentará el mensaje. "Su Nuevo Saldo es de $-20,480.00 pesos m/c".



            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 100000, 30000);

            decimal valorRetirar = 120000;
            var fechaRetiro = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Retirar(valorRetirar, fechaRetiro, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $-20,480.00 pesos m/c", mensajeRespuesta);
        }
    }
}
