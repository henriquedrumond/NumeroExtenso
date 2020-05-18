using System;
using ExecucaoNumero.Conversao;

namespace ExecucaoNumero.Helpers
{
    internal static class ExtensoesDeString
    {
        public static int ObterDigitoPorOrdemEClasse(this string caracteres, int indiceDaClasse, int indiceDaOrdem)
        {
            return Convert.ToInt32(caracteres.Substring(indiceDaClasse * ConversaoNumeros.NumeroDeClasses + indiceDaOrdem, 1));
        }
    }
}