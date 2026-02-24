using ConsoleApp1;
using Npgsql;

public class TaraRepository
{
    public void RegistrarTara(Pesagem pesagem)
    {
        using (var conn = Conexao.ObterConexao())
        {
            conn.Open();
            string sql = @"INSERT INTO pesagem 
                           (peso_tara, nome_motorista, placa_equipamento, cod_motorista) 
                           VALUES (@peso_tara, @nome_motorista, @placa_equipamento, @cod_motorista)";
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("peso_tara", pesagem.PesoTara);
                cmd.Parameters.AddWithValue("nome_motorista", pesagem.NomeMotorista);
                cmd.Parameters.AddWithValue("placa_equipamento", pesagem.PlacaEquipamento);
                cmd.Parameters.AddWithValue("cod_motorista", pesagem.CodMotorista);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
