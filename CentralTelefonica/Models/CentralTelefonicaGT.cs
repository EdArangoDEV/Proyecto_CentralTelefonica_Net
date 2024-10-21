using System.Diagnostics.Contracts;
using CentralTelefonica.Utilities;

namespace CentralTelefonica.Models
{
    public class CentralTelefonicaGT : ICentralTelefonica
    {
        private int contador;
        private double acumulador;

        public int Contador
        {
            get
            {
                return contador;
            }
            set
            {
                contador = value;
            }
        }
        public double Acumulador
        {
            get
            {
                return acumulador;
            }
            set
            {
                acumulador = value;
            }
        }


        public double GerTotalFacturas()
        {
            return Acumulador;
        }

        public int GetTotalLLamadas()
        {
            return Contador;
        }

        public void RegistrarLlamadas(Llamada registro)
        {
            Contador++; // Contador = Contador + 1;
            double duracion = registro.Duracion;
            Console.WriteLine(registro);

            if (registro.GetType() == typeof(LlamadaLocal))
            {
                Acumulador = Acumulador + duracion * 0.25;
            }
            else if (registro.GetType() == typeof(LlamadaInterior))
            {
                switch (((LlamadaInterior)registro).Franja)
                {
                    case 1:
                        Acumulador = Acumulador + (duracion * 0.20); // Franja 1
                        break;
                    case 2:
                        Acumulador = Acumulador + (duracion * 0.35); // Franja 2
                        break;
                    case 3:
                        Acumulador = Acumulador + (duracion * 0.85); // Franja 3
                        break;
                }
            }

        }




    }
}