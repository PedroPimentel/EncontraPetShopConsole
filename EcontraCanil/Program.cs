using EcontraCanil.Entidades;
using EcontraCanil.Serviços;
using System;

namespace EcontraCanil
{
    public class Program
    {
        static void Main()
        {
            var entrada = new Entrada();
            var dados = "";
            var encontraMelhorOpcaoServico = new EncontraMelhorOpcaoServico();

            Console.WriteLine("Insira a data do banho:");
            dados = Console.ReadLine();

            while (!encontraMelhorOpcaoServico.VerificarData(dados))
            {
                Console.Clear();
                Console.WriteLine("Data inválida.\nFavor inserir uma data no formato dd/MM/yyyy a partir do ano 1900:");
                dados = Console.ReadLine();
            }

            entrada.DataBanho = encontraMelhorOpcaoServico.GerarDataBanho(dados);

            Console.WriteLine("Insira a quantidade de cães grandes:");
            dados = Console.ReadLine();

            while (!encontraMelhorOpcaoServico.VerificarNumeroInteiro(dados))
            {
                Console.Clear();
                Console.WriteLine("Valor inválido.\nFavor inserir um número inteiro.");
                dados = Console.ReadLine();
            }
            entrada.QtdCaesGrandes = Convert.ToInt32(dados);

            Console.WriteLine("Insira a quantidade de cães pequenos:");
            dados = Console.ReadLine();

            while (!encontraMelhorOpcaoServico.VerificarNumeroInteiro(dados))
            {
                Console.Clear();
                Console.WriteLine("Valor inválido\nFavor inserir um número inteiro.");
                dados = Console.ReadLine();
            }

            entrada.QtdCaesPequenos = Convert.ToInt32(dados);

            var saida = encontraMelhorOpcaoServico.EncontrarMelhorOpcao(entrada);

            Console.Clear();
            Console.WriteLine("A melhor opção é a Pet Shop " + saida.Canil + " com o valor de R$ " + saida.Preco.ToString());

            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("Deseja calcular novamente?\n1 - Sim");
            dados = Console.ReadLine();

            if (dados == "1")
            {
                Console.Clear();
                Main();
            }

        }
    }
}
