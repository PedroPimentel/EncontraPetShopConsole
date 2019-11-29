using EcontraCanil.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcontraCanil.Repositorios
{
    public class Repositorio : IRespositorio
    {
        public IEnumerable<PetShop> ObterPetShops()
        {
            return new List<PetShop>
            {
                new PetShop { Nome = "Meu Canino Feliz", Distancia = 2.0, PrecoCaoGrandeDiaUtil = 40, PrecoCaoPequenoDiaUtil = 20, PrecoCaoPequenoFinalSemana = 24, PrecoCaoGrandeFinalSemana = 48 },
                new PetShop { Nome = "Vai Rex", Distancia = 1.7, PrecoCaoGrandeDiaUtil = 50, PrecoCaoPequenoDiaUtil = 15, PrecoCaoGrandeFinalSemana = 55, PrecoCaoPequenoFinalSemana = 20 },
                new PetShop { Nome = "ChowChawgas", Distancia = 0.8, PrecoCaoGrandeDiaUtil = 45, PrecoCaoPequenoDiaUtil = 30, PrecoCaoGrandeFinalSemana = 45, PrecoCaoPequenoFinalSemana = 30 },
            };
        }

        public List<string> ObterDiasUteis()
        {
            return new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        }
    }
}
