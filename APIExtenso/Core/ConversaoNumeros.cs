using System;
using System.Linq;
using ExecucaoNumero.Core;
using ExecucaoNumero.Helpers;

namespace ExecucaoNumero.Conversao
{
    internal class ConversaoNumeros
    {
        public static int NumeroDeClasses { get { return _classes.Length; } }
        private static readonly Type[] _ordens = { typeof(Unidade), typeof(Dezena), typeof(Centena) };
        private static readonly Type[] _classes = { typeof(PrimeiraClasse), typeof(Milhar), typeof(Milhao) };

        /// <summary>
        /// Método inicial para trabalhar a conversão dos números
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static Classe Converter(long numero)
        {
            var digitos = InverterNumero(numero);
            var numeroDeClasses = ObterNumeroDeClasses(digitos);
            var classes = ConstruirClasses(digitos, numeroDeClasses);

            return classes;
        }

        private static Classe ConstruirClasses(string digitos, int numeroDeClasses)
        {
            Classe classeAtual = null;

            for (var indiceDaClasse = 0; indiceDaClasse < numeroDeClasses; indiceDaClasse++)
            {
                var tipoClasseAtual = _classes[indiceDaClasse];
                var ordens = ConstruirOrdens(digitos, indiceDaClasse);
                classeAtual = tipoClasseAtual.Construir<Classe>(ordens, classeAtual);
            }
            return classeAtual;
        }

        private static Ordem ConstruirOrdens(string digitos, int indiceDaClasse)
        {
            Ordem ordemAtual = null;
            for (var indiceDaOrdem = 0; indiceDaOrdem < ObterNumeroDeOrdens(digitos, indiceDaClasse); indiceDaOrdem++)
            {
                var tipoOrdemAtual = _ordens[indiceDaOrdem];

                if (digitos.Contains('-'))
                {
                    digitos = digitos.Replace("-", "");
                }

                var digitoParaEncapsular = digitos.ObterDigitoPorOrdemEClasse(indiceDaClasse, indiceDaOrdem);
                ordemAtual = tipoOrdemAtual.Construir<Ordem>(digitoParaEncapsular, ordemAtual);
            }
            return ordemAtual;
        }

        private static int ObterNumeroDeOrdens(string digitos, int indiceDaClasse)
        {
            return Math.Min(3, digitos.Length - indiceDaClasse * NumeroDeClasses);
        }

        private static int ObterNumeroDeClasses(string digitos)
        {
            return (int)Math.Ceiling((decimal)digitos.Length / NumeroDeClasses);
        }

        private static string InverterNumero(long numero)
        {
            return new string(numero.ToString().Reverse().ToArray());
        }
    }
}
