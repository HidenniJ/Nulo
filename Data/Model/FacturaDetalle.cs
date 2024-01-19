using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FactuSystem.Data.Request;
using FactuSystem.Data.Response;

namespace FactuSystem.Data.Model;

public class FacturaDetalle
{
    [Key]
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }

    #region Relaciones
    [ForeignKey(nameof(FacturaId))]
    public virtual Factura Factura { get; set; }
    [ForeignKey(nameof(ProductoId))]
    public virtual Producto Producto { get; set; }
    #endregion

    [NotMapped]
    public decimal SubTotal => Cantidad * Precio;

    public static FacturaDetalle Crear(FacturaDetalleRequest request)
    => new()
    {
        ProductoId = request.ProductoId,
        Cantidad = request.Cantidad,
        Precio = request.Precio,
    };
    
    public FacturaDetalleResponse ToResponse()
        => new()
        {
            Id = Id,
            Producto = Producto.ToResponse(),
            Cantidad = Cantidad,
            Precio = Precio,
            FacturaId = FacturaId
        };
}
