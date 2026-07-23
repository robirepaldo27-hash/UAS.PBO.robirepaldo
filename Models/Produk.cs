using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KasirSembako.Models;

public class Produk
{
    public int Id { get; set; }
    public string Nama { get; set; } = string.Empty;
    public string Satuan { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal HargaBeli { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal HargaJual { get; set; }

    public int Stok { get; set; }
}