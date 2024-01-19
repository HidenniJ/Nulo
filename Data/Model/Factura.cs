using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace FactuSystem.Data.Model;

public class Factura
{
    [Key]
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public virtual ICollection<FacturaDetalle> Detalles { get; set; }
    #region Relaciones
    [ForeignKey(nameof(ClienteId))]
    public virtual Cliente Cliente { get; set; }
    #endregion

    [NotMapped]
    public decimal SubTotal =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.SubTotal) //Verdadero
        :
        0;//Falso

    public decimal SaldoPendiente { get; set; }
}
