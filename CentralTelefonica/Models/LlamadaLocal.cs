namespace CentralTelefonica.Models
{
    public class LlamadaLocal : Llamada
    {
        private double precio;

        public double Precio
        {
            get
            {
                return precio == 0 ? 0.25 : precio;
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
            return this.Duracion * this.Precio;
        }

        public override string ToString()
        {
            return $"Log -> llamada Local: Destino: {NumeroDestino} -> Origen: {NumeroOrigen} con Duracion = {Duracion}";
        }

        public override double CalcularPrecioRef(ref double resultado)
        {
            resultado += this.Duracion * this.Precio; 
            return resultado;
        }
    }
}