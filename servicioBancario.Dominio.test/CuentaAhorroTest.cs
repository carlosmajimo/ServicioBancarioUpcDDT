using Microsoft.VisualStudio.TestTools.UnitTesting;
using servicioBancario.Dominio.Entities;
using System;

namespace servicioBancario.Dominio.test
{
    [TestClass]
    public class CuentaAhorroTest
    {
        [TestMethod]
        public void TestConsignarValorMenorACero()
        {
            //Dado: 
            //El cliente tiene una cuenta de ahorro
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0

            //Cuando:
            //Va a consignar un valor -100

            //Entonces:
            //El sistema presentará el mensaje. “El valor a consignar es incorrecto”


            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001","Cuenta Ejemplo", 0);

            decimal valorConsignar = -100;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor a consignar es incorrecto", mensajeRespuesta);
        }

        [TestMethod]
        public void TestConsignarInicialCorrecto()
        {
            //Dado: 
            //El cliente tiene una cuenta de ahorro
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0

            //Cuando:
            //Va a consignar el valor inicial de 50 mil pesos

            //Entonces:
            //El sistema registrará la consignación
            //AND presentará el mensaje.“Su Nuevo Saldo es de $50.000,00 pesos m/c”.


            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001", "Cuenta Ejemplo", 0);

            decimal valorConsignar = 50000;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $50000 pesos m/c", mensajeRespuesta);
        }

        [TestMethod]
        public void TestConsignarInicialIncorrecta()
        {
            //Dado:
            //El cliente tiene una cuenta de ahorro con
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 0

            //Cuando:
            //Va a consignar el valor inicial de $49.950 pesos

            //Entonces:
            //El sistema no registrará la consignación
            //AND presentará el mensaje.
            //“El valor mínimo de la primera consignación debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos”.


            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001", "Cuenta Ejemplo", 0);

            decimal valorConsignar = 49950;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor minimo de la primera consignacion debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos", mensajeRespuesta);
        }

        [TestMethod]
        public void TestConsignarPosteriorCorrecta()
        {
            //Dado:
            //El cliente tiene una cuenta de ahorro con
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 30000

            //Cuando:
            //Va a consignar el valor de $49.950 pesos

            //Entonces:
            //El sistema registrará la consignación
            //AND presentará el mensaje.
            //"Su Nuevo Saldo es de 79950 pesos m/c"


            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001", "Cuenta Ejemplo", 30000);

            decimal valorConsignar = 49950;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $79950 pesos m/c", mensajeRespuesta);
        }

        [TestMethod]
        public void TestConsignarPosteriorCorrectaCiudad()
        {
            //Dado:
            //El cliente tiene una cuenta de ahorro con
            //Número 10001, Nombre “Cuenta ejemplo”, Saldo de 30000, Ciudad "Bogota"

            //Cuando:
            //Va a consignar el valor de $49.950 pesos y desde la ciudad de Valledupar.

            //Entonces:
            //El sistema registrará la consignación
            //AND presentará el mensaje.
            //"Su Nuevo Saldo es de 69950 pesos m/c"”.


            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001", "Cuenta Ejemplo", "Bogota", 30000);

            decimal valorConsignar = 49950;
            var fechaConsignacion = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Consignar(valorConsignar, fechaConsignacion, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $69950 pesos m/c", mensajeRespuesta);
        }

        [TestMethod]
        public void TestValorRetiroMenorACero()
        {
            //Dado:
            //El cliente tiene una cuenta de ahorro
            //Número 10001, Nombre "Cuenta ejemplo", Saldo de $40 mil pesos.


            //Cuando:
            //Va a retirar 0 pesos

            //Entonces:
            //El sistema presentará el mensaje. "El valor a retirar es incorrecto"


            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001", "Cuenta Ejemplo", 40000);

            decimal valorRetirar = 0;
            var fechaRetiro = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Retirar(valorRetirar, fechaRetiro, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor a retirar es incorrecto", mensajeRespuesta);
        }

        [TestMethod]
        public void TestValorRetiroMayorDelMinimo()
        {
            //Dado:
            //El cliente tiene una cuenta de ahorro
            //Número 10001, Nombre "Cuenta ejemplo", Saldo de $40 mil pesos.


            //Cuando:
            //Va a retirar $30 mil pesos

            //Entonces:
            //El sistema no registrará el retiro.
            //AND presentará el mensaje. "El valor a retirar es incorrecto, el saldo minimo en 
            //cuenta es de $20000 pesos m/c".

            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001", "Cuenta Ejemplo", 40000);

            decimal valorRetirar = 30000;
            var fechaRetiro = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Retirar(valorRetirar, fechaRetiro, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("El valor a retirar es incorrecto, el saldo minimo en cuenta es de $20000 pesos m/c", mensajeRespuesta);
        }

        [TestMethod]
        public void TestValorRetiroCorrectoGratuito()
        {
            //Dado:
            //El cliente tiene una cuenta de ahorro
            //Número 10001, Nombre "Cuenta ejemplo", Saldo de 60 mil pesos y dos retiros en el mes.


            //Cuando:
            //Va a retirar $30 mil pesos

            //Entonces:
            //El sistema registrará el retiro restando $30 mil pesos al saldo.
            //AND presentará el mensaje. "Su Nuevo Saldo es de $30000 pesos m/c".

            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001", "Cuenta Ejemplo", 60000);
            cuentaAhorro.retiroMes = 2;

            decimal valorRetirar = 30000;
            var fechaRetiro = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Retirar(valorRetirar, fechaRetiro, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $30000 pesos m/c", mensajeRespuesta);
        }

        [TestMethod]
        public void TestValorRetiroCorrectoConCosto()
        {
            //Dado:
            //El cliente tiene una cuenta de ahorro
            //Número 10001, Nombre "Cuenta ejemplo", Saldo de 60 mil pesos y dos retiros en el mes.


            //Cuando:
            //Va a retirar $30 mil pesos

            //Entonces:
            //El sistema registrará el retiro restando $35 mil pesos al saldo.
            //AND presentará el mensaje. "Su Nuevo Saldo es de $25000 pesos m/c"..

            //Dado - Preparar (A)
            CuentaAhorros cuentaAhorro = new CuentaAhorros("10001", "Cuenta Ejemplo", 60000);
            cuentaAhorro.retiroMes = 3;

            decimal valorRetirar = 30000;
            var fechaRetiro = new DateTime(2018, 02, 1);
            var ciudad = "Valledupar";

            //Cuando - Actuar (A)
            string mensajeRespuesta = cuentaAhorro.Retirar(valorRetirar, fechaRetiro, ciudad);

            //Entonces - Afirmar (A)
            Assert.AreEqual("Su Nuevo Saldo es de $25000 pesos m/c", mensajeRespuesta);
        }

    }
}
