using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyMVCWebApp.Migrations
{
    /// <inheritdoc />
    public partial class tableRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                  name: "MyProperty",
            schema: "dbo",
            newName: "Categories",
            newSchema: "dbo"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                 name: "Categories",
           schema: "dbo",
           newName: "MyProperty",
           newSchema: "dbo"
               );
        }
    }
}
