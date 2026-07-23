using Microsoft.AspNetCore.Mvc.RazorPages;
using KasirSembako.Data;
using KasirSembako.Models;
using Microsoft.EntityFrameworkCore;

namespace KasirSembako.Pages.Transaksi;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public List<Models.Transaksi> Transaksis { get; set; } = new();

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    public async Task OnGetAsync()
    {
        Transaksis = await _db.Transaksis.OrderByDescending(t => t.Tanggal).ToListAsync();
    }
}