using Npgsql;

namespace ConsoleApp1.Data
{
    public class PessoaRepository
    {
        public void Inserir(Pessoa pessoa)
        {
            using (var conn = Conexao.ObterConexao())
            {
                conn.Open();

                string sql = @"INSERT INTO usuario 
                               (nome, senha, email, idade) 
                               VALUES (@nome, @senha, @email, @idade)";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nome", pessoa.Nome);
                    cmd.Parameters.AddWithValue("senha", pessoa.Senha);
                    cmd.Parameters.AddWithValue("email", pessoa.Email);
                    cmd.Parameters.AddWithValue("idade", pessoa.Idade);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}