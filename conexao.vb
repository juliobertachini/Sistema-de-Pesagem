Imports Npgsql

Public Class Conexao

    Private Shared connectionString As String =
        "Host=localhost;Port=5432;Username=postgres;Password=ADMIN;Database=postgres"

    Public Shared Function ObterConexao() As NpgsqlConnection
        Return New NpgsqlConnection(connectionString)
    End Function

End Class
