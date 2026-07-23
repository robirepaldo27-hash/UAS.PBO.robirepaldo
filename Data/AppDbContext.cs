using Microsoft.EntityFrameworkCore;
using KasirSembako.Models;

namespace KasirSembako.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produk> Produks { get; set; }
    public DbSet<Transaksi> Transaksis { get; set; }
    public DbSet<DetailTransaksi> DetailTransaksis { get; set; }
}