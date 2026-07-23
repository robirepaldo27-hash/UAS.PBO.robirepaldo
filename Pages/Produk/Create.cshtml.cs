using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KasirSembako.Data;

namespace KasirSembako.Pages.Produk;

public class CreateModel : PageModel
{
    private readonly AppDbContext _db;

    public CreateModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public Models.Produk Produk { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _db.Produks.Add(Produk);
        await _db.SaveChangesAsync();
        return RedirectToPage("/Produk/Index");
    }
}