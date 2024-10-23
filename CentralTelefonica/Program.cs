using System.Reflection;
using System.Text.RegularExpressions;
using CentralTelefonica.Helpers;
using CentralTelefonica.Models;

public delegate double CalcularPrecioLlamada();
public delegate double CalcularPrecioLlamadaRef(ref double total);

public class Program
{
    public static void Main(string[] args)
    {
        /*
        LlamadaLocal llamadaMixco = new LlamadaLocal("421214212", "4324323", 15);
        LlamadaLocal llamadaGuatemala = new LlamadaLocal("3433243", "342445234", 20);

        LlamadaInterior llamadaXela = new LlamadaInterior("3433243", "342445234", 10, 1);
        LlamadaInterior llamadaZacapa = new LlamadaInterior("2232432", "71446143", 25, 3);

        CentralTelefonicaGT central = new CentralTelefonicaGT();

        ProcesarPago();

        central.RegistrarLlamada(l;lamadaMixco);
        central.RegistrarLlamada(l;lamadaGuatemala);
        central.RegistrarLlamada(l;lamadaXela);
        central.RegistrarLlamada(l;lamadaZacapa);
        */

        /*
        central.GerTotalFacturas();
        central.GetTotalLLamadas();
 
        // relacionando metodo con delegado
        CalcularPrecioLlamada calculoLlamadas = llamadaMixco.CalcularPrecio;
        // llamado al metodo por medio del delegado
        double resultado = calculoLlamadas();
        calculoLlamadas = llamadaGuatemala.CalcularPrecio;
        resultado = resultado + calculoLlamadas();
        calculoLlamadas = llamadaXela.CalcularPrecio;
        resultado = resultado + calculoLlamadas();
        calculoLlamadas = llamadaZacapa.CalcularPrecio;
        resultado = resultado + calculoLlamadas();

        Console.WriteLine($"El total de lo facturado es: {resultado}");
        */

        /*
        // variable para parametro de referencia y que se sumen
        double resultado = 0;

        CalcularPrecioLlamadaRef calculoLlamadasRef = llamadaMixco.CalcularPrecioRef;
        calculoLlamadasRef += llamadaGuatemala.CalcularPrecioRef;
        calculoLlamadasRef += llamadaXela.CalcularPrecioRef;
        calculoLlamadasRef += llamadaZacapa.CalcularPrecioRef;

        calculoLlamadasRef(ref resultado);
    
        Console.WriteLine($"El total de lo facturado es: {resultado}");


        // MostrarDetalle(central);
        */

        MenuPrincipal();
    }

    public static void MenuPrincipal()
    {
        CentralTelefonicaGT central = new CentralTelefonicaGT();
        string respuesta = "4";
        do
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("1. Registrar llamada local\n2. Registrar llamada interior\n3. Mostrar detalle ventas\n4. salir");
            Console.WriteLine("****************************");
            Console.WriteLine("Ingrese su opción");
            respuesta = Console.ReadLine();
            if (respuesta.Equals("1"))
            {
                RegistrarLlamada(central, "1");
            }
            else if (respuesta.Equals("2"))
            {
                RegistrarLlamada(central, "2");
            }
            else if (respuesta.Equals("3"))
            {
                Console.Clear();
                MostrarDetalle(central);
            }
        } while (!respuesta.Equals("4"));
        Console.Clear();
        Console.WriteLine("Saliendo del programa...");
        Thread.Sleep(2000);
        Console.Clear();
    }

    public static void RegistrarLlamada(CentralTelefonicaGT central, string tipoLlamada)
    {
        Console.Clear();
        Console.WriteLine("Ingrese el número de Destino");
        string destino = Console.ReadLine();
        Console.WriteLine("Ingrese el número de Origen");
        string origen = Console.ReadLine();
        Console.WriteLine("Ingrese la duración");
        int duracion = int.Parse(Console.ReadLine());
        if (tipoLlamada.Equals("1"))
        {
            LlamadaLocal llamadaLocal = new LlamadaLocal(destino, origen, duracion);
            central.RegistrarLlamada(llamadaLocal);
        }
        else if (tipoLlamada.Equals("2"))
        {
            LlamadaInterior llamadaInterior = new LlamadaInterior();
            int respuesta = 0;
            int franja;

            do
            {
                Console.WriteLine("Ingrese la franja");
                franja = int.Parse(Console.ReadLine());
                ValidaFranjaHandler validaFranja = ValidarFranja;
                respuesta = validaFranja(franja);
            } while (respuesta != 1);

            llamadaInterior.Franja = franja;
            llamadaInterior.NumeroDestino = destino;
            llamadaInterior.NumeroOrigen = origen;
            llamadaInterior.Duracion = duracion;

            central.RegistrarLlamada(llamadaInterior);
        }
        ProcesarPago();
    }

    private static void MostrarDetalle(CentralTelefonicaGT central)
    {

        Console.WriteLine($"El total de llamadas es: {central.Contador}");
        Console.WriteLine($"El total facturado es Q.{central.Acumulador}");
        Console.ReadKey();
    }

    static void ProcesarPago()
    {
        Console.WriteLine("****************************");
        Console.WriteLine("\nIngrese su forma de pago");
        Console.WriteLine("\n1. - Tarjeta\n2. - Transferencia\n3. - Otros");
        Console.WriteLine("***************************");
        Console.WriteLine("Ingrese la opción de pago");
        string valor = Console.ReadLine();
        // se instancia clase
        FormaPago forma = new FormaPago();
        // asociamos evento con metodo
        forma.CambioFormaPago += ConfirmarTipoPago;
        forma.CambioFormaPago += ValidarPinPago;
        forma.Tipo = (TipoPago)Enum.Parse(typeof(TipoPago), valor);
        Console.WriteLine("Presione tecla para continuar...");
        Console.ReadKey();
    }

    public static int ValidarFranja(int franja)
    {
        if (franja == 1 || franja == 2 || franja == 3)
        {
            Console.WriteLine($"La franja ingresada es correcta!!!");
            return 1;
        }
        else
        {
            Console.WriteLine($"La franja ingresada es incorrecta!!!");
            return 0;
        }
    }

    public static void ConfirmarTipoPago(TipoPago tipo, TipoAlerta tipoAlerta)
    {
        if (tipoAlerta.Equals(TipoAlerta.Exito))
        {
            Console.WriteLine($"El tipo de pago seleccionado es correcto!!!");
        }
        else if (tipoAlerta.Equals(TipoAlerta.Error))
        {
            Console.WriteLine($"El tipo de pago seleccionado es incorecto!!!");
        }
    }

    public static void ValidarPinPago(TipoPago tipo, TipoAlerta tipoAlerta)
    {
        bool estatus = false;
        if (tipoAlerta.Equals(TipoAlerta.Exito))
        {
            Console.WriteLine($"Continuando con el proceso de pago por {tipo}");
            Console.WriteLine($"Ingrese el número de pin para procesar pago");
            string pin = Console.ReadLine();
            if (pin.Equals("1234x"))
            {
                estatus = true;
            }
            Console.WriteLine($"La confirmación fue recibida, el estatus de la operación fue {(estatus ? "CONFIRMADO" : "CANCELADO")}");
        }
    }


}