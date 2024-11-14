using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPessoal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiPessoal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }

        public DbSet<Contrato> TB_CONTRATOS { get; set; }
        public DbSet<Documento> TB_DOCUMENTOS { get; set; }
        public DbSet<Parte> TB_PARTES { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>().ToTable("TB_CONTRATOS");
            modelBuilder.Entity<Documento>().ToTable("TB_DOCUMENTOS");
            modelBuilder.Entity<Parte>().ToTable("TB_PARTES");


            //Relacionamento de 1 Parte ter vários Documentos
            modelBuilder.Entity<Parte>()
                .HasMany(e => e.Documentos)
                .WithOne(e => e.Parte)
                .HasForeignKey( e => e.ParteId)
                .IsRequired(false);



            //Relacionamento de 1 Parte ter 1 Contrato
            modelBuilder.Entity<Parte>()
                .HasOne(e => e.Contrato)
                .WithOne(e => e.Parte)
                .HasForeignKey<Contrato>(e => e.ParteId)
                .IsRequired();



            //Informações dos Contratos
            modelBuilder.Entity<Contrato>().HasData
            (
                new Contrato()
                {
                    Id = 1, Titulo = "Primeiro Contrato", DataInicio = new DateTime(2023, 10, 24), DataFim = new DateTime(2024, 10, 24),
                    Status = "Ativo", Cliente = "ETEC", Prestador = "EscritórioX", Valor = 1300, ParteId = 1    
                },
                new Contrato()
                {
                    Id = 2, Titulo = "Segundo Contrato", DataInicio = new DateTime(2023, 07, 08), DataFim = new DateTime(2024, 07, 08),
                    Status = "Desativado",Cliente = "Casa de Bolo",Prestador = "EscritórioY",Valor = 2500, ParteId = 2
                },
                new Contrato()
                {
                    Id = 3, Titulo = "Terceiro Contrato", DataInicio = new DateTime(2023, 04, 20), DataFim = new DateTime(2024, 04, 20),
                    Status = "Ativo", Cliente = "Mercadinho", Prestador = "EscritórioZ", Valor = 800, ParteId = 3
                }
                    );

            //Informações dos Documentos
            modelBuilder.Entity<Documento>().HasData
            (
                new Documento()
                {
                    Id = 1, Titulo = "Contrato de Prestação de Serviços", Tipo = "Contrato", DataCriacao = new DateTime(2023, 10, 24),
                    Status = "Ativo", Observacoes = "Contrato de prestação de serviços firmado entre as partes.", Assinado = true,
                    ParteId = 1
                },
                new Documento()
                {
                    Id = 2, Titulo = "Procuração", Tipo = "Procuração", DataCriacao = new DateTime(2023, 07, 08), 
                    Status = "Ativo", Observacoes = "Procuração para representação legal do cliente.", Assinado = false,
                    ParteId = 1
                },
                new Documento()
                {
                    Id = 3, Titulo = "Certidão de Casamento", Tipo = "Certidão", DataCriacao = new DateTime(2023, 04, 20),
                    Status = "Ativo", Observacoes = "Certidão de casamento registrada em cartório.", Assinado = false,
                    ParteId = 1
                },
                new Documento() 
                {
                    Id = 4, Titulo = "Alvará de Soltura", Tipo = "Alvará", DataCriacao = new DateTime(2024, 11, 01), 
                    Status = "Pendente", Observacoes = "Alvará de Soltura esperando análise do Juiz.", Assinado = false,
                    ParteId = 3 
                },

                new Documento() 
                { 
                    Id = 5, Titulo = "Petição de Invertário", Tipo = "Petição", DataCriacao = new DateTime(2021, 01, 01), 
                    Status = "Ativo", Observacoes = "Petição cadastrada e enviada para o Juiz.", Assinado = true, 
                    ParteId = 3 
                },

                new Documento() 
                 { 
                    Id = 6, Titulo = "Mandato de Busca", Tipo = "Mandato", DataCriacao = new DateTime(2022, 06, 15), 
                    Status = "Pendente", Observacoes = "Mandado de Busca aguardando assinatura do judiciário", Assinado = false, 
                    ParteId = 2 
                }
            );


            //Informações das Partes
            modelBuilder.Entity<Parte>().HasData
            (
                new Parte() { Id = 1, Nome = "Vitor", Tipo = "Cliente", DocumentoIdentidade = "RG", 
                    Endereco = "Rua 1, Bairro A, Cidade X", Telefone = "1234-5678", Email = "vitor@email.com", },
                new Parte() { Id = 2, Nome = "Ana", Tipo = "Advogado", DocumentoIdentidade = "OAB", 
                    Endereco = "Rua 2, Bairro B, Cidade Y", Telefone = "2345-6789", Email = "ana@adv.com" },
                new Parte() { Id = 3, Nome = "Carlos", Tipo = "Testemunha", DocumentoIdentidade = "CPF", 
                    Endereco = "Rua 3, Bairro C, Cidade Z", Telefone = "3456-7890", Email = "carlos@teste.com" }  
            );


            base.OnModelCreating(modelBuilder);
        }

            
           









        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
            .HaveColumnType("varchar").HaveMaxLength(200);


            base.ConfigureConventions(configurationBuilder);
        }

    }
}