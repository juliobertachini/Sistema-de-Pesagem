using ConsoleApp1;
using ConsoleApp1.Data;
using ConsoleApp1.Services;
using Npgsql;
using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main()
    {   //INCIO DO MENU PRINCIPAL
        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine("\n==== MENU PRINCIPAL ====");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Realizar Pesagem Tara");
            Console.WriteLine("3 - Realizar Pesagem Bruto");
            Console.WriteLine("4 - Testar Comunicação com Balança");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    CadastrarUsuario();
                    break;

                case 2:
                    RegistrarPesagemTara();
                    break;

                case 3:
                    RegistrarPesagemBruto();
                    break;

                case 4:
                    ConectarBalanca();
                    break;

                case 0:
                    Console.WriteLine("Encerrando sistema...");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
        //FIM DO MENU PRINCIPAL

        //INICIO CADASTRO DE USUARIO
        static void CadastrarUsuario()
        {
            Console.WriteLine("\n=== Cadastro de Usuário ===");

            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Ano atual: ");
            int anoAtual = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ano nascimento: ");
            int anoNascimento = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Senha: ");
            string senha = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Pessoa pessoa = new Pessoa
            {
                Nome = nome,
                Senha = senha,
                Email = email
            };

            pessoa.CalcularIdade(anoAtual, anoNascimento);

            PessoaRepository repo = new PessoaRepository();
            repo.Inserir(pessoa);

            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
        //FIM CADASTRO DE USUARIO

        //INICIO REGISTRAR PESAGEM TARA
        static void RegistrarPesagemTara()
        {
            Console.WriteLine("\n=== Registrar Pesagem ===");
            // Lógica para registrar pesagem (a ser implementada)
            Console.WriteLine("Informe o Código do Equipamento:");
            int codigoEquipamento = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Informe a Placa do Equipamento:");
            string placaEquipamento = Console.ReadLine() ?? "";

            Console.WriteLine("Informe o Código do Motorista:");
            int codigoMotorista = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Informe o Nome do Motorista:");
            string nomeMotorista = Console.ReadLine() ?? "";

            Console.WriteLine("Informe o Peso Tara:");
            double pesoTara = double.Parse(Console.ReadLine() ?? "0");
        }
        //FIM REGISTRAR PESAGEM TARA

        //INICIO REGISTRAR PESAGEM BRUTO
        static void RegistrarPesagemBruto()
        {
            Console.WriteLine("\n=== Registrar Pesagem ===");
            // Lógica para registrar pesagem (a ser implementada)
            Console.WriteLine("Informe o Código da Pesagem:");
            int codigoPesagem = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Informe o Peso Bruto:");
            double pesoBruto = double.Parse(Console.ReadLine() ?? "0");
        }
        //FIM REGISTRAR PESAGEM BRUTO

        //INICIO TESTAR COMUNICAÇÃO COM BALANÇA
        static void ConectarBalanca()
        {
            Console.WriteLine("\n=== Testar Comunicação com Balança ===");
            // Lógica para testar comunicação com balança (a ser implementada)
            Console.WriteLine("Informe o IP da Balança:");
            string ipBalanca = Console.ReadLine() ?? "";

            Console.WriteLine("Informe a Porta da Balança:");
            int portaBalanca = int.Parse(Console.ReadLine() ?? "0");

            VariaveisBalanca variaveisBalanca = new VariaveisBalanca
            {
                IpBalanca = ipBalanca,
                PortaBalanca = portaBalanca
            };

            var balancaService = new BalancaService();
            balancaService.Conectar(variaveisBalanca);

        }
    }
}
