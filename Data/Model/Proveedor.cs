using FactuSystem.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace FactuSystem.Data.Model;

public class Proveedor
{
    [Key]
    public int Id { get; set; }
    public string NombreEmp { get; set; } = null!;
    public string? Email { get; set; }
    public string Telefono { get; set; } = null!;
    public string? Direccion { get; set; }

    public ProveedorResponse? ToResponse() => new()
    {
        Id = Id,
        NombreEmp = NombreEmp
    };
}