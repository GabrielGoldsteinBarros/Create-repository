using System;
using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = null;
Reserva reserva = null;

bool continuar = true;

while (continuar)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Cadastrar Hóspede");
    Console.WriteLine("2. Cadastrar Suíte");
    Console.WriteLine("3. Fazer Reserva");
    Console.WriteLine("4. Exibir Quantidade de Hóspedes");
    Console.WriteLine("5. Calcular Valor da Diária");
    Console.WriteLine("6. Sair");
    Console.Write("Escolha uma opção: ");
    
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Digite o nome do hóspede: ");
            string nome = Console.ReadLine();
            hospedes.Add(new Pessoa(nome));
            Console.WriteLine("Hóspede cadastrado com sucesso!\n");
            break;

        case "2":
            Console.Write("Digite o tipo da suíte: ");
            string tipoSuite = Console.ReadLine();
            Console.Write("Digite a capacidade da suíte: ");
            int capacidade = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor da diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());
            suite = new Suite(tipoSuite, capacidade, valorDiaria);
            Console.WriteLine("Suíte cadastrada com sucesso!\n");
            break;

        case "3":
            if (suite == null)
            {
                Console.WriteLine("Você precisa cadastrar uma suíte primeiro!\n");
            }
            else
            {
                Console.Write("Digite o número de dias reservados: ");
                int diasReservados = int.Parse(Console.ReadLine());
                reserva = new Reserva(diasReservados);
                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);
                Console.WriteLine("Reserva feita com sucesso!\n");
            }
            break;

        case "4":
            if (reserva == null)
            {
                Console.WriteLine("Você precisa fazer uma reserva primeiro!\n");
            }
            else
            {
                Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}\n");
            }
            break;

        case "5":
            if (reserva == null)
            {
                Console.WriteLine("Você precisa fazer uma reserva primeiro!\n");
            }
            else
            {
                Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria()}\n");
            }
            break;

        case "6":
            continuar = false;
            Console.WriteLine("Saindo...");
            break;

        default:
            Console.WriteLine("Opção inválida! Tente novamente.\n");
            break;
    }
}