namespace CentralTelefonica.Models
{
    public class LlamadaInterior : Llamada
    {
        private double precioUno { get; set; }
        private double precioDos { get; set; }
        private double precioTres { get; set; }
        private int franja { get; set; }

        public double PrecioUno
        { 
            get
            {
                return precioUno;
            } 
            set
            {
                precioUno = value;
            }
        }

        public double PrecioDos
        { 
            get
            {
                return precioDos;
            } 
            set
            {
                precioDos = value;
            }
        }

        public double PrecioTres
        { 
            get
            {
                return precioTres;
            } 
            set
            {
                precioTres = value;
            }
        }

        public int Franja
        { 
            get
            {
                return franja;
            } 
            set
            {
                franja = value;
            }
        }

        public LlamadaInterior() : base(){

        }

        public LlamadaInterior(string numeroOrigen, string numeroDestino, double duracion, int franja) : base(numeroOrigen, numeroDestino, duracion)
        {
            this.Franja = franja;
        }

        public override double CalcularPrecio()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Log -> llamada Interior: Destino: {NumeroDestino} -> Origen: {NumeroOrigen} con Duracion = {Duracion}";
        }
    }
}