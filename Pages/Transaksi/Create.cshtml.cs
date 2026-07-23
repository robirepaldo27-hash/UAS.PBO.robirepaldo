using Microsoft.AspNetCore.Mvc.RazorPages;
using KasirSembako.Data;
using Microsoft.EntityFrameworkCore;

namespace KasirSembako.Pages.Transaksi;

public class CreateModel : PageModel
{
    private readonly AppDbContext _db;
    public List<KasirSembako.Models.Produk> Produks { get; set; } = new();

    public CreateModel(AppDbContext db)
    {
        _db = db;
    }

    public async Task OnGetAsync()
    {
        Produks = await _db.Produks.ToListAsync();
    }
}