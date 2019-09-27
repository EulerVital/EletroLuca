using ENT;
using ENT.Associativa;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>().ToTable("Perfil");
            modelBuilder.Entity<Perfil>().Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Senha)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Produto>().Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Imagem>().ToTable("Imagem");
            modelBuilder.Entity<Imagem>().Property(p => p.CaminhoVirtual)
                .IsRequired();

            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Pedido>().Property(p => p.Data)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Pedido>().Ignore(p => p.Produtos);

            modelBuilder.Entity<DadosUsuario>().ToTable("Dados_Usuario");
            modelBuilder.Entity<DadosUsuario>().Property(p => p.Logradouro)
                .HasMaxLength(500)
                .IsRequired();
            modelBuilder.Entity<DadosUsuario>().Property(p => p.Cep)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<DadosUsuario>().Property(p => p.Celular)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<DadosUsuario>().Property(p => p.Telefone)
                .HasMaxLength(20);

            modelBuilder.Entity<PedidoProduto>().ToTable("Pedido_Produto");
        }

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DadosUsuario> DadosUsuarios { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }
    }
}
