using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APIExtenso.Domain;
using ExecucaoNumero.Conversao;
using Newtonsoft.Json;
using System.Web.Http;

namespace APIExtenso.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("/api/[controller]/{numero:int}")]
    public class NumeroExtensoController : Controller
    {
        List<NumeroExtenso> _listnumero = new List<NumeroExtenso>();

        /// <summary>
        /// Não uso interface pois não estou usando acesso a bd e nem dependency injection.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public string Get(int numero)
        {
            var numeroPorExtenso = ConversaoNumeros.Converter(numero).ToString();

            string _nunmeronegativo = numero.ToString();

            NumeroExtenso _numero = new NumeroExtenso()
            {
                extenso = _nunmeronegativo.Contains('-') ? "menos " + numeroPorExtenso : numeroPorExtenso
            };

            _listnumero.Add(_numero);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>(),
                Formatting = Formatting.Indented
            };

            var teste = JsonConvert.SerializeObject(_listnumero, settings);

            var unserializedContent = JsonConvert.DeserializeObject(teste);

            return unserializedContent.ToString();
        }
    }
}
