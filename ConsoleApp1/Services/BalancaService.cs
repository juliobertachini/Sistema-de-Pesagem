using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1.Services
{
    public class BalancaService
    {
        public void Conectar(VariaveisBalanca variaveis)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(variaveis.IpBalanca, variaveis.PortaBalanca);

                    Console.WriteLine("Conectado à balança!");

                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];

                    while (true)
                    {
                        int bytesLidos = stream.Read(buffer, 0, buffer.Length);

                        if (bytesLidos > 0)
                        {
                            string resposta = Encoding.ASCII.GetString(buffer, 0, bytesLidos);
                            Console.WriteLine("Peso recebido: " + resposta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
            }
        }
    }
}