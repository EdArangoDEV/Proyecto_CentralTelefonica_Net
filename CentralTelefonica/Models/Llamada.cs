
namespace CentralTelefonica.Models
{
    public abstract class Llamada
    {
        public string NumeroOrigen { get; set; }
        public string NumeroDestino { get; set; }
        public double Duracion { get; set; }

        public Llamada(){}

        public Llamada(string numeroOrigen, string numeroDestino, double duracion)
        {
            this.NumeroOrigen = numeroOrigen;
            this.NumeroDestino = numeroDestino;
            this.Duracion = duracion;
        }

        public abstract double CalcularPrecio();

        // parametro por referencia guardan el valor en memoria
        public abstract double CalcularPrecioRef(ref double resultado);
    }
}