using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KasirSembako.Data;

namespace KasirSembako.Pages.Produk;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _db;

    public DeleteModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public Models.Produk Produk { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var produk = await _db.Produks.FindAsync(id);
        if (produk == null) return NotFound();
        Produk = produk;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var produk = await _db.Produks.FindAsync(Produk.Id);
        if (produk == null) return NotFound();
        _db.Produks.Remove(produk);
        await _db.SaveChangesAsync();
        return RedirectToPage("/Produk/Index");
    }
}