using CentralTelefonica.Models;

namespace CentralTelefonica.Utilities
{
    public interface ICentralTelefonica
    {
        public int Contador { get; set; }
        public double Acumulador { get; set; }
        
        public void RegistrarLlamada(Llamada registro);
        public int GetTotalLLamadas();
        public double GerTotalFacturas();
    }
}