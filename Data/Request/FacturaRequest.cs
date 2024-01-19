namespace FactuSystem.Data.Request;

public class FacturaRequest
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public virtual ICollection<FacturaDetalleRequest> Detalles { get; set; }
        = new List<FacturaDetalleRequest>();
    public decimal SubTotal =>
        Detalles != null ?
        Detalles.Sum(d => d.SubTotal)
        :
        0;

    public decimal SaldoPendiente { get; set; }
}

public class FacturaDetalleRequest
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string? Descripcion { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal SubTotal => Cantidad * Precio;
}