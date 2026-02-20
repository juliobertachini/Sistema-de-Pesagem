using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pesagem
{
    public int Id { get; set; }
    public double PesoTara { get; set; }
    public double PesoBruto { get; set; }
    public DateTime DataHora { get; set; }
    public string NomeMotorista { get; set; }    
}

