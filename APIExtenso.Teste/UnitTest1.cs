using NUnit.Framework;
using System;
using ExecucaoNumero.Conversao;
using APIExtenso.Helpers;

namespace APIExtenso.Teste
{
    [TestFixture]
    public class TesteDeInteiroInterno
    {
        [TestCase("um", 1)]
        [TestCase("menos mil e quarenta e dois", -1042)]
        [TestCase("noventa e quatro mil, quinhentos e oitenta e sete", 94587)]

        public void NumeroExtenso(string numeroPorExtensoEsperado, int numero)
        {
            Assert.AreEqual(numeroPorExtensoEsperado, numero.PorExtenso());
        }
    }
}