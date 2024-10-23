using CentralTelefonica.Helpers;

namespace CentralTelefonica.Models
{
    public delegate void CambioFormaPagoHandler(TipoPago tipoPago, TipoAlerta tipoAlerta);
    public class FormaPago // Clase BroadCaster -> clase emisora
    {
        private TipoPago tipo;

        public TipoPago Tipo
        {
            get
            {
                return this.tipo;
            } 
            set
            {
                TipoAlerta tipoAlerta = TipoAlerta.Error;
                if (value.Equals(TipoPago.Tarjeta) || value.Equals(TipoPago.Transferencia) || value.Equals(TipoPago.Otros))
                {
                    tipo = value;
                    tipoAlerta = TipoAlerta.Exito;
                }
                // se llama al evento emisor
                CambioFormaPago(tipo, tipoAlerta);
            }
        }

        // crea evento de tipo delegado
        public event CambioFormaPagoHandler CambioFormaPago;

    }
}