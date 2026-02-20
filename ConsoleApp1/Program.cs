using ConsoleApp1;
using ConsoleApp1.Data;
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
            Console.WriteLine("2 - Realizar Pesagem");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    CadastrarUsuario();
                    break;

                case 2:
                    Console.WriteLine("TESTE...");
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
    }
}

