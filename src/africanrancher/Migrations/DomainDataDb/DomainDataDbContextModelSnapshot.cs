using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using africanrancher.Models.Domain;

namespace africanrancher.Migrations.DomainDataDb
{
    [DbContext(typeof(DomainDataDbContext))]
    partial class DomainDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("africanrancher.Models.Domain.Ailment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BovineId");

                    b.Property<DateTimeOffset?>("Diagnosed");

                    b.Property<int>("Type");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.Bovine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("BirthDate");

                    b.Property<string>("Bolus");

                    b.Property<string>("Brand");

                    b.Property<int?>("Breed");

                    b.Property<int?>("DamId");

                    b.Property<DateTimeOffset?>("Death");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("EarTag");

                    b.Property<DateTimeOffset?>("Purchase");

                    b.Property<DateTimeOffset?>("Sale");

                    b.Property<int?>("SireId");

                    b.Property<DateTimeOffset?>("WeeningDate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Bovine");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.BreedType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.Heard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.HeardMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BovineId");

                    b.Property<DateTimeOffset>("Entry");

                    b.Property<int?>("HeardId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AilmentId");

                    b.Property<DateTimeOffset>("Applied");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.Weighing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BovineId");

                    b.Property<DateTimeOffset>("DateTime");

                    b.Property<float>("WeightInKgs");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.FemaleBovine", b =>
                {
                    b.HasBaseType("africanrancher.Models.Domain.Bovine");


                    b.HasAnnotation("Relational:DiscriminatorValue", "FemaleBovine");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.MaleBovine", b =>
                {
                    b.HasBaseType("africanrancher.Models.Domain.Bovine");

                    b.Property<DateTimeOffset?>("CastrationDate");

                    b.HasAnnotation("Relational:DiscriminatorValue", "MaleBovine");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.Ailment", b =>
                {
                    b.HasOne("africanrancher.Models.Domain.Bovine")
                        .WithMany()
                        .HasForeignKey("BovineId");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.Bovine", b =>
                {
                    b.HasOne("africanrancher.Models.Domain.FemaleBovine")
                        .WithMany()
                        .HasForeignKey("DamId");

                    b.HasOne("africanrancher.Models.Domain.MaleBovine")
                        .WithMany()
                        .HasForeignKey("SireId");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.HeardMovement", b =>
                {
                    b.HasOne("africanrancher.Models.Domain.Bovine")
                        .WithMany()
                        .HasForeignKey("BovineId");

                    b.HasOne("africanrancher.Models.Domain.Heard")
                        .WithMany()
                        .HasForeignKey("HeardId");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.Treatment", b =>
                {
                    b.HasOne("africanrancher.Models.Domain.Ailment")
                        .WithMany()
                        .HasForeignKey("AilmentId");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.Weighing", b =>
                {
                    b.HasOne("africanrancher.Models.Domain.Bovine")
                        .WithMany()
                        .HasForeignKey("BovineId");
                });

            modelBuilder.Entity("africanrancher.Models.Domain.FemaleBovine", b =>
                {
                });

            modelBuilder.Entity("africanrancher.Models.Domain.MaleBovine", b =>
                {
                });
        }
    }
}
