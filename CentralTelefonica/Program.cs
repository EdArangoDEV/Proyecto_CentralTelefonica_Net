using CentralTelefonica.Models;

public class Program
{
    public static void Main(string[] args)
    {
        LlamadaLocal llamadaMixco = new LlamadaLocal("421214212","4324323",15);
        LlamadaLocal llamadaGuatemala = new LlamadaLocal("3433243","342445234",20);

        LlamadaInterior llamadaXela = new LlamadaInterior("3433243","342445234",10, 1);
        LlamadaInterior llamadaZacapa = new LlamadaInterior("2232432","71446143",25, 3);

        CentralTelefonicaGT central = new CentralTelefonicaGT();
        central.RegistrarLlamadas(llamadaMixco);
        central.RegistrarLlamadas(llamadaGuatemala);
        central.RegistrarLlamadas(llamadaXela);
        central.RegistrarLlamadas(llamadaZacapa);

        central.GerTotalFacturas();
        central.GetTotalLLamadas();

        MostrarDetalle(central);

    }

    private static void MostrarDetalle(CentralTelefonicaGT central){

        Console.WriteLine($"El total de llamadas es: {central.Contador}");
        Console.WriteLine($"El total facturado es Q.{central.Acumulador}");
    }
}