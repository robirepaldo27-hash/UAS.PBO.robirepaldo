using Microsoft.AspNetCore.Mvc.RazorPages;
using KasirSembako.Data;
using KasirSembako.Models;
using Microsoft.EntityFrameworkCore;

namespace KasirSembako.Pages.Produk;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public List<Models.Produk> Produks { get; set; } = new();

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    public async Task OnGetAsync()
    {
        Produks = await _db.Produks.ToListAsync();
    }
}