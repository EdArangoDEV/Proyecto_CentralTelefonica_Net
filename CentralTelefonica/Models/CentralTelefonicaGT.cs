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
            return 0;
        }

        public int GetTotalLLamadas()
        {
            return 0;
        }

        public void RegistrarLlamadas(Llamada registro)
        {
            Contador++; // Contador = Contador + 1;
            
            Acumulador = registro.Duracion * 0.25;

            Acumulador = registro.Duracion * 0.20; // Franja 1
            Acumulador = registro.Duracion * 0.35; // Franja 2
            Acumulador = registro.Duracion * 0.85; // Franja 3
        }
    }
}