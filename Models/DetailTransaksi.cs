using System.ComponentModel.DataAnnotations.Schema;

namespace KasirSembako.Models;

public class DetailTransaksi
{
    public int Id { get; set; }
    public int TransaksiId { get; set; }
    public Transaksi? Transaksi { get; set; }
    public int ProdukId { get; set; }
    public Produk? Produk { get; set; }
    public int Jumlah { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal HargaSatuan { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; }
}