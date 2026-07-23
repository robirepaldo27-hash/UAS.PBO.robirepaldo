using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KasirSembako.Data;
using Microsoft.EntityFrameworkCore;

namespace KasirSembako.Pages.Transaksi;

public class PrintModel : PageModel
{
    private readonly AppDbContext _db;
    public KasirSembako.Models.Transaksi Transaksi { get; set; } = new();

    public PrintModel(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var transaksi = await _db.Transaksis
            .Include(t => t.Details)
            .ThenInclude(d => d.Produk)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transaksi == null) return NotFound();
        Transaksi = transaksi;
        return Page();
    }
}