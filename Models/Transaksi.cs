using System.ComponentModel.DataAnnotations.Schema;

namespace KasirSembako.Models;

public class Transaksi
{
    public int Id { get; set; }
    public DateTime Tanggal { get; set; } = DateTime.Now;
    public string NamaPelanggan { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalHarga { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Bayar { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Kembalian { get; set; }

    public List<DetailTransaksi> Details { get; set; } = new();
}