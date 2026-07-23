using Microsoft.AspNetCore.Mvc.RazorPages;
using KasirSembako.Data;
using Microsoft.EntityFrameworkCore;

namespace KasirSembako.Pages.Laporan;

public class PrintModel : PageModel
{
    private readonly AppDbContext _db;
    public List<KasirSembako.Models.Transaksi> Transaksis { get; set; } = new();
    public decimal TotalPendapatan { get; set; }
    public DateTime Dari { get; set; }
    public DateTime Sampai { get; set; }

    public PrintModel(AppDbContext db)
    {
        _db = db;
    }

    public async Task OnGetAsync(DateTime? dari, DateTime? sampai)
    {
        Dari = dari ?? DateTime.Today;
        Sampai = sampai ?? DateTime.Today;

        Transaksis = await _db.Transaksis
            .Where(t => t.Tanggal.Date >= Dari.Date && t.Tanggal.Date <= Sampai.Date)
            .OrderByDescending(t => t.Tanggal)
            .ToListAsync();

        TotalPendapatan = Transaksis.Sum(t => t.TotalHarga);
    }
}