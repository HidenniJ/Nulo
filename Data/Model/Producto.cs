using FactuSystem.Data.Request;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace FactuSystem.Data.Model;

public class Producto
{
    [Key]
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public int ProveedorID { get; set; }
    public string Nombre { get; set; } = null!;
    public int CategoriaID { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }

    [ForeignKey("ProveedorID")]
    public virtual Proveedor? Proveedor { get; set; }
    [ForeignKey("CategoriaID")]
    public virtual Categoria? Categoria { get; set; }

    public static Producto Crear(ProductoRequest item)
        => new()
        {
            Codigo = item.Codigo,
            ProveedorID = item.ProveedorID,
            Nombre = item.Nombre,
            CategoriaID = item.CategoriaID,
            Precio = item.Precio
        };

    public bool Mofidicar(ProductoRequest contacto)
    {
        var cambio = false;
        if (Codigo != contacto.Codigo)
        {
            Codigo = contacto.Codigo;
            cambio = true;
        }
        if (ProveedorID != contacto.ProveedorID)
        {
            ProveedorID = contacto.ProveedorID;
            cambio = true;
        }
        if (Nombre != contacto.Nombre)
        {
            Nombre = contacto.Nombre;
            cambio = true;
        }
        if (CategoriaID != contacto.CategoriaID)
        {
            CategoriaID = contacto.CategoriaID;
            cambio = true;
        }
        if (Precio != contacto.Precio)
        {
            Precio = contacto.Precio;
            cambio = true;
        }
        return cambio;
    }
}