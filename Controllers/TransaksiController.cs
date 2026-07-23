using Microsoft.AspNetCore.Mvc;
using KasirSembako.Data;
using KasirSembako.Models;
using Microsoft.EntityFrameworkCore;

namespace KasirSembako.Controllers;

[ApiController]
[Route("api/transaksi")]
public class TransaksiController : ControllerBase
{
    private readonly AppDbContext _db;

    public TransaksiController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TransaksiRequest req)
    {
        var transaksi = new Transaksi
        {
            NamaPelanggan = req.NamaPelanggan,
            TotalHarga = req.TotalHarga,
            Bayar = req.Bayar,
            Kembalian = req.Kembalian,
            Tanggal = DateTime.Now
        };

        foreach (var item in req.Details)
        {
            transaksi.Details.Add(new DetailTransaksi
            {
                ProdukId = item.ProdukId,
                Jumlah = item.Jumlah,
                HargaSatuan = item.HargaSatuan,
                Subtotal = item.Subtotal
            });

            // Kurangi stok
            var produk = await _db.Produks.FindAsync(item.ProdukId);
            if (produk != null) produk.Stok -= item.Jumlah;
        }

        _db.Transaksis.Add(transaksi);
        await _db.SaveChangesAsync();

        return Ok(new { id = transaksi.Id });
    }
}

public class TransaksiRequest
{
    public string NamaPelanggan { get; set; } = string.Empty;
    public decimal TotalHarga { get; set; }
    public decimal Bayar { get; set; }
    public decimal Kembalian { get; set; }
    public List<DetailRequest> Details { get; set; } = new();
}

public class DetailRequest
{
    public int ProdukId { get; set; }
    public int Jumlah { get; set; }
    public decimal HargaSatuan { get; set; }
    public decimal Subtotal { get; set; }
}   