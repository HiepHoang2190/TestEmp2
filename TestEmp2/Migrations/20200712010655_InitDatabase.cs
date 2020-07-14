using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEmp2.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AvatarPatch = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "AvatarPatch", "Department", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "images/img_avatar1.png", 2, "hoangbachhiep2190@gmail.com", "hoangbachhiep" },
                    { 2, "images/img_avatar5.png", 0, "lequangvu11@gmail.com", "lequangvu23" },
                    { 3, "images/img_avatar5.png", 3, "lequangvu11@gmail.com", "lequangvu23" },
                    { 4, "images/img_avatar5.png", 1, "lequangvu11@gmail.com", "lequangvu23" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
