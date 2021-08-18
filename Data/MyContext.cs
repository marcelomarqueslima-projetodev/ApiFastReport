using System;
using ApiFastReport.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiFastReport.Data
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaItem> VendaItems { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>().HasData(
                new Empresa
                {
                    Id = 1,
                    Nome = "Posto de Gasolina Cidade",
                    Email = "postocidade@mail.com",
                    Foto = "",
                    CreateAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    Id = 1,
                    Descricao = "Combustivel",
                    CreateAt = DateTime.UtcNow
                },
                new Categoria
                {
                    Id = 2,
                    Descricao = "Lubrificantes",
                    CreateAt = DateTime.UtcNow
                },
                new Categoria
                {
                    Id = 3,
                    Descricao = "Diversos",
                    CreateAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = 1,
                    Descricao = "Gasolina Aditivada",
                    Ean = "9789563530701",
                    Preco = 5.50m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 2,
                    Descricao = "Gasolina Comum",
                    Ean = "9789563530702",
                    Preco = 5.10m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 3,
                    Descricao = "Alcool Comum",
                    Ean = "9789563530703",
                    Preco = 4.00m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 4,
                    Descricao = "Alcool Aditivado",
                    Ean = "9789563530704",
                    Preco = 4.15m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 5,
                    Descricao = "Diesel",
                    Ean = "9789563530705",
                    Preco = 3.98m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new Produto
                {
                    Id = 6,
                    Descricao = "Óleo Lubrificante Motor 20w",
                    Ean = "9789563530710",
                    Preco = 20.00m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 2
                },
                new Produto
                {
                    Id = 7,
                    Descricao = "Óleo Lubrificante Motor 40w",
                    Ean = "9789563530711",
                    Preco = 21.00m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 2
                },
                new Produto
                {
                    Id = 8,
                    Descricao = "Água sem Gás",
                    Ean = "9789563530720",
                    Preco = 2.00m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 3
                },
                new Produto
                {
                    Id = 9,
                    Descricao = "Água com Gás",
                    Ean = "9789563530721",
                    Preco = 2.10m,
                    CreateAt = DateTime.UtcNow,
                    CategoriaId = 3
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Nome = "Fernando Silva",
                    Email = "fernandosilva@mail.com",
                    CreateAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    Nome = "Marcos",
                    Email = "marcos@mail.com",
                    CreateAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 3,
                    Nome = "Ellena",
                    Email = "ellena@mail.com",
                    CreateAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 4,
                    Nome = "Rafaela",
                    Email = "Rafaela@mail.com",
                    CreateAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 5,
                    Nome = "Heloisa",
                    Email = "heloisa@mail.com",
                    CreateAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 6,
                    Nome = "Manuella",
                    Email = "manuella@mail.com",
                    CreateAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 7,
                    Nome = "Luan",
                    Email = "luan@mail.com",
                    CreateAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nome = "Sofia Marli Porto",
                    Email = "sofia@mail.com",
                    CreateAt = DateTime.UtcNow
                },
                new Cliente
                {
                    Id = 2,
                    Nome = "Raimunda Isis Olivia Vieira",
                    Email = "raimunda@mail.com",
                    CreateAt = DateTime.UtcNow
                },
                new Cliente
                {
                    Id = 3,
                    Nome = "Oliver Arthur da Mota",
                    Email = "oliver@mail.com",
                    CreateAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Venda>().HasData(
                new Venda
                {
                    Id = 1,
                    ClienteId = 2,
                    DataVenda = DateTime.UtcNow,
                    CreateAt = DateTime.UtcNow,
                    TotalVenda = 100.00m,
                },
                new Venda
                {
                    Id = 2,
                    ClienteId = 3,
                    DataVenda = DateTime.UtcNow,
                    CreateAt = DateTime.UtcNow,
                    TotalVenda = 75.00m,
                },
                new Venda
                {
                    Id = 3,
                    ClienteId = 1,
                    DataVenda = DateTime.UtcNow.AddDays(2),
                    CreateAt = DateTime.UtcNow.AddDays(2),
                    TotalVenda = 200.00m,
                }
            );

            modelBuilder.Entity<VendaItem>().HasData(
                new VendaItem
                {
                    Id = 1,
                    ProdutoId = 2,
                    VendaId = 1,
                    Quantidade = 18.18m,
                    ValorProduto = 5.50m,
                    TotalProduto = 100.00m
                },
                new VendaItem
                {
                    Id = 2,
                    ProdutoId = 1,
                    VendaId = 2,
                    Quantidade = 9.80m,
                    ValorProduto = 5.10m,
                    TotalProduto = 50.00m
                },
                new VendaItem
                {
                    Id = 3,
                    ProdutoId = 9,
                    VendaId = 2,
                    Quantidade = 12m,
                    ValorProduto = 2.10m,
                    TotalProduto = 25.00m
                },
                new VendaItem
                {
                    Id = 4,
                    ProdutoId = 5,
                    VendaId = 3,
                    Quantidade = 50.24m,
                    ValorProduto = 3.98m,
                    TotalProduto = 200.00m
                }
            );
        }
    }
}