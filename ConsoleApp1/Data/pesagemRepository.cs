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
                           (peso, nome_motorista) 
                           VALUES (@peso_tara, @nome_motorista)";
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("peso_tara", pesagem.PesoTara);
                cmd.Parameters.AddWithValue("nome_morotista", pesagem.NomeMotorista);
                cmd.ExecuteNonQuery();
            }
        }
    }
}