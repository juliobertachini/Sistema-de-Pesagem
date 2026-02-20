using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pesagem
{
    public int Id { get; set; }
    public double Peso { get; set; }
    public DateTime DataHora { get; set; }
    public string Usuario { get; set; }    
}

