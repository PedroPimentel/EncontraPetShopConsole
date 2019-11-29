using EcontraCanil.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcontraCanil.Repositorios
{
    public interface IRespositorio
    {
        IEnumerable<PetShop> ObterPetShops();
    }
}
