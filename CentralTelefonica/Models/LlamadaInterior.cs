namespace CentralTelefonica.Models
{
    public delegate int ValidaFranjaHandler(int franja); 

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
                return precioUno == 0 ? 0.20 : precioUno;
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
                return precioDos == 0 ? 0.35 : precioDos;
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
                return precioTres == 0 ? 0.85 : precioTres;
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
                //ValidaFranja(franja);
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
            double costo = 0;

            if (this.Franja == 1)
            {
                costo = this.Duracion * this.PrecioUno;    
            } 
            else if (this.Franja == 2)
            {
                costo = this.Duracion * this.PrecioDos;
            } 
            else if (this.Franja == 3)
            {
                costo = this.Duracion * this.PrecioTres;
            }
            return costo;
        }

        public event ValidaFranjaHandler ValidaFranja;

        public override string ToString()
        {
            return $"Log -> llamada Interior: Destino: {NumeroDestino} -> Origen: {NumeroOrigen} con Duracion = {Duracion}";
        }

        public override double CalcularPrecioRef(ref double resultado)
        {
            if (this.Franja == 1)
            {
                resultado += this.Duracion * this.PrecioUno;    
            } 
            else if (this.Franja == 2)
            {
                resultado += this.Duracion * this.PrecioDos;
            } 
            else if (this.Franja == 3)
            {
                resultado += this.Duracion * this.PrecioTres;
            }
            return resultado;
        }

    }
}