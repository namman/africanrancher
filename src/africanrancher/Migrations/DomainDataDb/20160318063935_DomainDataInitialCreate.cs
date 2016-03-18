using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace africanrancher.Migrations.DomainDataDb
{
    

    public partial class DomainDataInitialCreate : Migration
    {
        

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Bovine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTimeOffset>(nullable: true),
                    Bolus = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Breed = table.Column<int>(nullable: true),
                    DamId = table.Column<int>(nullable: true),
                    Death = table.Column<DateTimeOffset>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    EarTag = table.Column<string>(nullable: true),
                    Purchase = table.Column<DateTimeOffset>(nullable: true),
                    Sale = table.Column<DateTimeOffset>(nullable: true),
                    SireId = table.Column<int>(nullable: true),
                    WeeningDate = table.Column<DateTimeOffset>(nullable: true),
                    CastrationDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bovine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bovine_FemaleBovine_DamId",
                        column: x => x.DamId,
                        principalTable: "Bovine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bovine_MaleBovine_SireId",
                        column: x => x.SireId,
                        principalTable: "Bovine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "BreedType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedType", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Heard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heard", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Ailment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BovineId = table.Column<int>(nullable: true),
                    Diagnosed = table.Column<DateTimeOffset>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ailment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ailment_Bovine_BovineId",
                        column: x => x.BovineId,
                        principalTable: "Bovine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Weighing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BovineId = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTimeOffset>(nullable: false),
                    WeightInKgs = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weighing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weighing_Bovine_BovineId",
                        column: x => x.BovineId,
                        principalTable: "Bovine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "HeardMovement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BovineId = table.Column<int>(nullable: true),
                    Entry = table.Column<DateTimeOffset>(nullable: false),
                    HeardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeardMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeardMovement_Bovine_BovineId",
                        column: x => x.BovineId,
                        principalTable: "Bovine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeardMovement_Heard_HeardId",
                        column: x => x.HeardId,
                        principalTable: "Heard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AilmentId = table.Column<int>(nullable: true),
                    Applied = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatment_Ailment_AilmentId",
                        column: x => x.AilmentId,
                        principalTable: "Ailment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("BreedType");
            migrationBuilder.DropTable("HeardMovement");
            migrationBuilder.DropTable("Treatment");
            migrationBuilder.DropTable("Weighing");
            migrationBuilder.DropTable("Heard");
            migrationBuilder.DropTable("Ailment");
            migrationBuilder.DropTable("Bovine");
        }
    }
}
