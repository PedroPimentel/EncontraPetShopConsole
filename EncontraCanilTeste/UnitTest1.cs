using EcontraCanil.Entidades;
using EcontraCanil.Repositorios;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeveRetornarDuasPetShops()
        {
            Repositorio _repositorio = new Repositorio();
            var petShops = _repositorio.ObterPetShops().ToList();

            foreach (var petShop in petShops)
                petShop.PrecoBanho = (petShop.PrecoCaoGrandeDiaUtil * 4) + (petShop.PrecoCaoPequenoDiaUtil * 8);

            Assert.That(2, Is.EqualTo(petShops.Where(ps => ps.PrecoBanho == 320).Count()));
        }

        [Test]
        public void DeveRetornarVaiRexTodosDias()
        {
            Repositorio _repositorio = new Repositorio();
            var petShops = _repositorio.ObterPetShops().ToList();
            var petShopMenorPreco = new List<PetShop>();

            foreach (var item in petShops)
                item.PrecoBanho = (item.PrecoCaoGrandeDiaUtil * 3) + (item.PrecoCaoPequenoDiaUtil * 10);

            var menorPreco = petShops.FirstOrDefault().PrecoBanho;

            foreach (var item in petShops)
            {
                if (item.PrecoBanho < menorPreco)
                    menorPreco = item.PrecoBanho;
            }

            petShopMenorPreco.Add(petShops.FirstOrDefault(ps => ps.PrecoBanho == menorPreco));

            foreach (var item in petShops)
                item.PrecoBanho = (item.PrecoCaoGrandeFinalSemana * 3) + (item.PrecoCaoPequenoFinalSemana * 10);

            menorPreco = petShops.FirstOrDefault().PrecoBanho;

            foreach (var item in petShops)
            {
                if (item.PrecoBanho < menorPreco)
                    menorPreco = item.PrecoBanho;
            }

            petShopMenorPreco.Add(petShops.FirstOrDefault(ps => ps.PrecoBanho == menorPreco));

            Assert.That(true, Is.EqualTo(petShopMenorPreco.All(ps => ps.Nome == "Vai Rex")));
        }

        [Test]
        public void DeveRetonarMenorDistanciaSeTodosPrecosIguais()
        {
            Repositorio _repositorio = new Repositorio();
            var petShops = _repositorio.ObterPetShops().ToList();
            var distancias = new List<double>();

            foreach (var petShop in petShops)
            {
                petShop.PrecoBanho = 100.00;
                distancias.Add(petShop.Distancia);
            }

            petShops = petShops.OrderBy(ps => ps.PrecoBanho).OrderBy(ps => ps.Distancia).ToList();
            var menorDistancia = distancias.Min();

            Assert.That(menorDistancia, Is.EqualTo(petShops.FirstOrDefault().Distancia));
        }
    }
}