using Microsoft.EntityFrameworkCore.Migrations;

namespace D11_EFCore.Migrations
{
    public partial class UpdateLoaiRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaLoaiCha",
                table: "Loai",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loai_MaLoaiCha",
                table: "Loai",
                column: "MaLoaiCha");

            migrationBuilder.AddForeignKey(
                name: "FK_Loai_Loai_MaLoaiCha",
                table: "Loai",
                column: "MaLoaiCha",
                principalTable: "Loai",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loai_Loai_MaLoaiCha",
                table: "Loai");

            migrationBuilder.DropIndex(
                name: "IX_Loai_MaLoaiCha",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "MaLoaiCha",
                table: "Loai");
        }
    }
}
