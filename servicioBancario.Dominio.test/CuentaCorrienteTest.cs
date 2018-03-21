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
        public void TestConsignarInicialCorrecta()
        {
            //Dado: 
            //El cliente tiene una cuenta corriente
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0

            //Cuando:
            //Va a consignar el valor inicial de $100 mil pesos

            //Entonces:
            //El sistema registrará la consignación
            //AND presentará el mensaje. "Su Nuevo Saldo es de $100000 pesos m/c".

            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 0, 200000);

            decimal valorConsignar = 100000;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $100000 pesos m/c", mensajeRespuesta);
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
            //AND presentará el mensaje. "El valor mínimo de la primera consignación debe ser de $100000 pesos".
            //Su nuevo saldo es $0 pesos

            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 0, 200000);

            decimal valorConsignar = 99950;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor mínimo de la primera consignación debe ser de $100000 pesos. Su nuevo saldo es $0 pesos", mensajeRespuesta);
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
            //AND presentará el mensaje. "Su Nuevo Saldo es de $120000 pesos m/c".


            //Dado - Preparar (A)
            CuentaCorriente cuentaCorriente = new CuentaCorriente("10001", "Cuenta Ejemplo", 80000, 200000);

            decimal valorConsignar = 40000;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaCorriente.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $120000 pesos m/c", mensajeRespuesta);
        }

    }
}
