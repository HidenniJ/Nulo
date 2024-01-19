using System.ComponentModel.DataAnnotations.Schema;

namespace FactuSystem.Data.Response;

public class FacturaResponse
{
    public int Id { get; set; }
    public int ContactoId { get; set; }
    public DateTime Fecha { get; set; }
    public ClienteResponse Cliente { get; set; }
    public virtual ICollection<FacturaDetalleResponse> Detalles { get; set; }

    [NotMapped]
    public decimal SubTotal =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.SubTotal) //Verdadero
        :
        0;//Falso

    public decimal SaldoPendiente { get; set; }
}