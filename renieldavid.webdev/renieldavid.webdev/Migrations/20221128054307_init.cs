using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace renieldavid.webdev.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StreamingAndServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamingAndServices", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VideoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfPublish = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_StreamingAndServices_Id",
                        column: x => x.Id,
                        principalTable: "StreamingAndServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "StreamingAndServices",
                columns: new[] { "Id", "Abbreviation", "Description", "Title" },
                values: new object[] { new Guid("1cef3b99-b69d-4b12-9b0a-b63c5fddcdc7"), "NFLX", "is an American subscription video on-demand over-the-top streaming service and production company based in Los Gatos, California. Founded in 1997 by Reed Hastings and Marc Randolph in Scotts Valley, California, it offers a film and television series library through distribution deals as well as its own productions, known as Netflix Originals.", "NETFLIX" });

            migrationBuilder.InsertData(
                table: "StreamingAndServices",
                columns: new[] { "Id", "Abbreviation", "Description", "Title" },
                values: new object[] { new Guid("e9735c93-7e74-4fbc-83e8-45d5999ccb1a"), "HIME", "Crunchyroll is an American subscription video on-demand over-the-top streaming service owned by Sony through a joint venture between Sony Pictures and Sony Music Entertainment Japan's Aniplex. The company primarily distributes films and television series from East Asian media, including Japanese anime outside Asia.", "Crunchyroll" });

            migrationBuilder.InsertData(
                table: "StreamingAndServices",
                columns: new[] { "Id", "Abbreviation", "Description", "Title" },
                values: new object[] { new Guid("e9ff85ab-f0c1-4de9-a9f2-5bee39150e4f"), "APV", "Watch award-winning Prime Originals on the web or Prime Video app. Enjoy Anywhere. Watch The Grand Tour. Unlimited Streaming. Start Free Trial. Download and Go.", "amazon prime video" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "DateOfPublish", "Description", "Title", "Type", "VideoId" },
                values: new object[] { new Guid("1cef3b99-b69d-4b12-9b0a-b63c5fddcdc7"), new DateTime(2022, 11, 28, 13, 43, 7, 769, DateTimeKind.Local).AddTicks(2093), null, "Turning Red", 1, new Guid("00965ecf-acae-46fe-8775-d7834b07fd96") });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "DateOfPublish", "Description", "Title", "Type", "VideoId" },
                values: new object[] { new Guid("e9735c93-7e74-4fbc-83e8-45d5999ccb1a"), new DateTime(2022, 11, 28, 13, 43, 7, 769, DateTimeKind.Local).AddTicks(2121), null, "Kimi", 2, new Guid("1d72f000-dbbd-419b-8af2-f571e1486ac2") });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "DateOfPublish", "Description", "Title", "Type", "VideoId" },
                values: new object[] { new Guid("e9ff85ab-f0c1-4de9-a9f2-5bee39150e4f"), new DateTime(2022, 11, 28, 13, 43, 7, 769, DateTimeKind.Local).AddTicks(2117), null, "Master", 2, new Guid("7ce68d5c-5b65-495a-8a63-14aeb48da87d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "StreamingAndServices");
        }
    }
}
