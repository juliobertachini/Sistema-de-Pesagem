using ConsoleApp1;
using Npgsql;
    public class Pessoa
{
    public string Nome  { get; set; }
    public int    Idade { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }

    public void CalcularIdade(int anoAtual, int anoNascimento)
    {
        Idade = anoAtual - anoNascimento;
    }
}
