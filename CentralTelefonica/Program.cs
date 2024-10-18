using CentralTelefonica.Models;

public class Program
{
    public static void Main(string[] args)
    {
        LlamadaLocal llamadaMixco = new LlamadaLocal("421214212","4324323",20);
        LlamadaLocal llamadaGuatemala = new LlamadaLocal("3433243","342445234",20);

        LlamadaInterior llamadaXela = new LlamadaInterior("3433243","342445234",20, 1);
        LlamadaInterior llamadaZacapa = new LlamadaInterior("2232432","71446143",20, 3);

        

    }
}