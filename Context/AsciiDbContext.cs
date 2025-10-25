using Microsoft.EntityFrameworkCore;
using Projeto_Ascii.Models;

namespace Projeto_Ascii.Context;

public class AsciiDbContext : DbContext
{
    public AsciiDbContext(DbContextOptions options) : base(options) {}
    
    public DbSet<Produto> Produtos { get; set; }
}