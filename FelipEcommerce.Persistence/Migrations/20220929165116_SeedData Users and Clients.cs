using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class SeedDataUsersandClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Age", "Dni", "FirstName", "LastName", "Phone" },
                values: new object[] { "2246 Joy Lane Burbank CA 91502", 65, "548875445", "Heather", " K. Garcia", "818-567-4835" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Age", "Dni", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 2, "1323 Merivale Road Ottawa, ON K2P 0K1", 76, "370 670 952", "Quintin P.", "Evans", "613-380-4940" },
                    { 24, "Victoria, BC V8Z 2J8", 45, "106 469 133", "Mili", "Arriaga Lozada", "250-881-7583" },
                    { 23, "Minburn, AB T0B 3B0", 23, "479 099 640", "Ona Negrete", "Arenas", "780-593-0182" },
                    { 22, "Nobel, ON P0G 1G0", 50, "064 667 884", "Aimée", "Fernández Gracia", "705-342-5282" },
                    { 21, "Montreal, QC H4J 1M9", 80, "445 737 539", "Amir", "Sevilla Gamez", "514-377-1176" },
                    { 20, "Rocky Mountain House, AB T0M 1T1", 66, "652 341 447", "Elijah", "Ceja Caballero", "403-846-2441" },
                    { 19, "Bouchette, QC H0H 0H0", 42, "757 081 815", "Edelira", "Rodrígez Muñoz", "819-465-9142" },
                    { 17, "Edmonton, AB T5C 2L2", 29, "460 547 342", "Crisóstomo Raya", "Cantú", "780-475-8399" },
                    { 16, "Quebec, QC G1V 3V5", 63, "079 929 295", "Justiniano Vigil", "Castellanos", "418-569-7055" },
                    { 15, "Mission, BC V2V 1J7", 23, "116 625 781", "Tibalt Alejandro", "Velásquez", "604-814-7305" },
                    { 14, "St Catharines, ON L2N 1S8", 63, "081 465 452", "Debra Tirado", "Trejo", "289-228-2329" },
                    { 18, "Ottawa, ON K1P 5M7", 37, "716 623 541", "Palemon", "Peres Vega", "613-978-8428" },
                    { 12, "Toronto, ON M3H 4J1", 68, "554 687 665", "Inalén Medrano", "Lebrón", "416-378-8701" },
                    { 11, "Fort Erie, ON L2A 1P3", 45, "342 233 863", "Achill Magana", "Pedroza", "289-321-0566" },
                    { 10, "Cobourg, ON K9A 1J1", 36, "201 756 269", "Fabrizio Vázquez", "Cepeda", "905-373-3704" },
                    { 9, "Calgary, AB T2V 2W2", 26, "544 769 607", "Carissa Gutiérrez", "Sarabia", "403-861-4303" },
                    { 8, "Calgary, AB T2P 0H3", 77, "234 463 297", "Ezequías Regalado", "Henríquez", "403-473-8979" },
                    { 7, "Alexandra, PE C1B 0N7", 34, "038 970 604", "Randall Laureano", "Rodrígez", "902-368-0646" },
                    { 6, "Windsor, ON N8Y 4V1", 25, "451 591 119", "David M.", "Yang", "519-981-6925" },
                    { 5, "Cranbrook, BC V1C 2R9", 65, "598 123 990", "Hugh A.", "Logan", "250-417-7243" },
                    { 4, "Nanaimo, BC V9R 3A8", 38, "328 840 673", "Stephanie F.", "Fahey", "250-816-8363" },
                    { 3, "Lakeview Heights, BC V1Z 1K2", 18, "667 962 229", "Ruby C.", "Crawford", "416-609-6578" },
                    { 13, "Tingwick, QC J0A 1L0", 45, "490 494 556", "Petronio Dueñas", "Galindo", "819-359-4816" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Password", "UserName" },
                values: new object[] { "Edwin Trevino", "edwingladiatoryoda123$", "edwingladiatoryoda" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Password", "UserName" },
                values: new object[,]
                {
                    { 4, "Todd Hobbs", "Toddroastpeardrumrye", "Toddthegraduaterye" },
                    { 5, "Vanessa Leblanc", "Vanessacowriverpig", "Vanessagandalftimon" },
                    { 6, "Reginald Cruz", "Reginaldngc5195bread", "Reginaldpomegranate" },
                    { 7, "John Collins", "Johnbirthdaycakelog", "Johnspiralshapeflute" },
                    { 8, "Juan Ball", "Juanplatoonfrognet", "Juanrearwindowbridge" },
                    { 9, "Brian Henry", "Brianbatthegoldrush", "Brianastronoutwine" },
                    { 10, "Kathleen Ramirez", "Kathleenhaloakirapig", "Kathleenxylophonered" },
                    { 3, "James Taylor", "jameshippopotamuspie", "jamescitizenkanewind" },
                    { 2, "Donald Smith MD", "Donaldspinachcheetah123$", "Donaldspinachcheetah" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Age", "Dni", "FirstName", "LastName", "Phone" },
                values: new object[] { "XXX", 34, "1X2X3X", "Gina", "Balanta", "123456789" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Password", "UserName" },
                values: new object[] { "Juan Felipe Balanta Rentería", "felipe123", "felipe" });
        }
    }
}
