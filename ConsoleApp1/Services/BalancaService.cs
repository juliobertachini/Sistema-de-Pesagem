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
                    var task = client.ConnectAsync(variaveis.IpBalanca, variaveis.PortaBalanca);

                    if (!task.Wait(TimeSpan.FromSeconds(5)))
                    {
                        throw new TimeoutException("Tempo de conexão excedido.");
                    }

                    Console.WriteLine("Conectado à balança!");

                    NetworkStream stream = client.GetStream();
                    stream.ReadTimeout = 5000; // 5 segundos para leitura

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
            catch (TimeoutException ex)
            {
                Console.WriteLine("Timeout: " + ex.Message);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Erro de socket: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
            }
        }
    }
}