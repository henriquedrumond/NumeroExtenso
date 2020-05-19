using System;
using ExecucaoNumero.Conversao;

namespace APIExtenso.Helpers
{
    public static class ExtensoesDeNumerosInteirosCoreTest
    {
        public static string PorExtenso(this int valor)
        {
            var numeroPorExtenso = ConversaoNumeros.Converter(valor).ToString();

            string _nunmeronegativo = valor.ToString();

            numeroPorExtenso = _nunmeronegativo.Contains('-') ? "menos " + numeroPorExtenso : numeroPorExtenso;

            return numeroPorExtenso;
        }
    }
}
