using EcontraCanil.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcontraCanil.Serviços
{
    public interface IEncontraMelhorOpcaoServico
    {
        DateTime GerarDataBanho(string dados);
    }
}
