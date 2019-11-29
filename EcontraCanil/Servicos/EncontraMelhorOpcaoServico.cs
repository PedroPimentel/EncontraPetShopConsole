using EcontraCanil.Entidades;
using EcontraCanil.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EcontraCanil.Serviços
{
    public class EncontraMelhorOpcaoServico : IEncontraMelhorOpcaoServico
    {
        private readonly List<PetShop> petShops = new List<PetShop>();
        private readonly Repositorio _repositorio = new Repositorio();
        public DateTime GerarDataBanho(string dados)
        {
            return DateTime.Parse(dados, new CultureInfo("pt-PB"));
        }

        public bool VerificarData(string dados)
        {
            var dataRegex = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");
            DateTime value;
            return dataRegex.Match(dados).Success && DateTime.TryParse(dados, out value); 
        }

        public bool VerificarNumeroInteiro(string dados)
        {
            int numero;
            return int.TryParse(dados, out numero);
        }

        public Saida EncontrarMelhorOpcao(Entrada entrada)
        {
            var dia = ObterDiaSemana(entrada.DataBanho);
            var diaUtil = _repositorio.ObterDiasUteis().Contains(dia);

            var valores = CalcularPreco(entrada, diaUtil);
            var valoresOrdenados = valores.OrderBy(pb => pb.PrecoBanho).ToList();

            if (valoresOrdenados[0].PrecoBanho != valoresOrdenados[1].PrecoBanho)
            {
                return new Saida()
                {
                    Canil = valoresOrdenados[0].Nome,
                    Preco = valoresOrdenados[0].PrecoBanho
                };
            }
            else
            {
                var doisMenoresValores = new List<double> { valoresOrdenados[0].Distancia, valoresOrdenados[1].Distancia };
                var menorDistancia = doisMenoresValores.Min();

                var petShop = valores.FirstOrDefault(ps => ps.Distancia == menorDistancia);

                return new Saida()
                {
                    Canil = petShop.Nome,
                    Preco = petShop.PrecoBanho
                };
            }
        }

        public string ObterDiaSemana(DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day).DayOfWeek.ToString();
        }

        public List<PetShop> CalcularPreco(Entrada entrada, bool diaUtil)
        {
            var petShops = _repositorio.ObterPetShops();

            if (diaUtil)
            {
                foreach (var petShop in petShops)
                    petShop.PrecoBanho = (entrada.QtdCaesGrandes * petShop.PrecoCaoGrandeDiaUtil) + (entrada.QtdCaesPequenos * petShop.PrecoCaoPequenoDiaUtil);
            }
            else
            {
                foreach (var petShop in petShops)
                    petShop.PrecoBanho = (entrada.QtdCaesGrandes * petShop.PrecoCaoGrandeFinalSemana) + (entrada.QtdCaesPequenos * petShop.PrecoCaoPequenoFinalSemana);
            }

            return petShops.ToList();
        }
    }
}
