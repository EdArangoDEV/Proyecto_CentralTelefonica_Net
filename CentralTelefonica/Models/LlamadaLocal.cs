namespace CentralTelefonica.Models
{
    public class LlamadaLocal : Llamada
    {
        private double precio;

        public double Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
            }
        }


        public LlamadaLocal() : base()
        {

        }

        public LlamadaLocal(string numeroOrigen, string numeroDestino, double duracion) : base(numeroOrigen, numeroDestino, duracion)
        {
        }

        public override double CalcularPrecio()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Log -> llamada Local: Destino: {NumeroDestino} -> Origen: {NumeroOrigen} con Duracion = {Duracion}";
        }

    }
}