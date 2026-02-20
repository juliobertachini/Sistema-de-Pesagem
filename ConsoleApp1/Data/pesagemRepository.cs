using ConsoleApp1;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PesagemRepository
{
    public void RegistrarPesagem(Pesagem pesagem )
    {
        using (var conn = Conexao.ObterConexao())
        {
            conn.Open();
            string sql = @"INSERT INTO pesagem 
                           (peso, data_hora, usuario) 
                           VALUES (@peso, @data_hora, @usuario)";
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("peso", pesagem.Peso);
                cmd.Parameters.AddWithValue("data_hora", pesagem.DataHora);
                cmd.Parameters.AddWithValue("usuario", pesagem.Usuario);
                cmd.ExecuteNonQuery();
            }
        }
    }
}