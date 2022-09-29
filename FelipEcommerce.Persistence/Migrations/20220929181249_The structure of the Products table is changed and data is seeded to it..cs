using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class ThestructureoftheProductstableischangedanddataisseededtoit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maximum",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Minimum",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurshacePrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Products",
                newName: "UrlImage");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Products",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price", "UrlImage" },
                values: new object[] { "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday", "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops", 497854m, "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "UrlImage" },
                values: new object[,]
                {
                    { 19, "100% Polyester, Machine wash, 100% cationic polyester interlock", "Opna Women's Short Sleeve Moisture", 35997m, "https://fakestoreapi.com/img/51eg55uWmdL._AC_UX679_.jpg" },
                    { 18, "5% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach, Lightweight fabric with great stretch for comfort, Ribbed on sleeves and neckline / Double stitching on bottom hem", "MBJ Women's Solid Short Sleeve Boat Neck V", 44600m, "https://fakestoreapi.com/img/71z3kpMAYsL._AC_UY879_.jpg" },
                    { 17, "Lightweight perfet for trip or casual wear---Long sleeve with hooded, adjustable drawstring waist design. ", "Rain Jacket Women Windbreaker Striped Climbing Raincoats", 181075m, "https://fakestoreapi.com/img/71HblAHs5xL._AC_UY879_-2.jpg" },
                    { 16, "00% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON (SWEATER)", "Lock and Love Women's Removable Hooded Faux Leather Moto Biker Jacket", 135613m, "https://fakestoreapi.com/img/81XH0e8fefL._AC_UY879_.jpg" },
                    { 15, "Note:The Jackets is US standard size, Please choose size as your usual wear Material: 100% Polyester; Detachable Liner Fabric: Warm Fleece", "BIYLACLESEN Women's 3-in-1 Snowboard Jacket Winter Coats", 258051m, "https://fakestoreapi.com/img/51Y5NI-I5jL._AC_UX679_.jpg" },
                    { 14, "49 INCH SUPER ULTRAWIDE 32:9 CURVED GAMING MONITOR with dual 27 inch screen side by side QUANTUM DOT (QLED) TECHNOLOGY", "Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor (LC49HG90DMNXZA) – Super Ultrawide Screen QLED", 4527964m, "https://fakestoreapi.com/img/81Zt42ioCgL._AC_SX679_.jpg" },
                    { 13, "1. 5 inches Full HD (1920 x 1080) widescreen IPS display And Radeon free Sync technology. ", "Acer SB220Q bi 21.5 inches Full HD (1920 x 1080) IPS Ultra-Thin", 2712277m, "https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_.jpg" },
                    { 12, "WD NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. ", "WD 4TB Gaming Drive Works with Playstation 4 Portable External Hard Drive", 510721m, "https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_.jpg" },
                    { 11, "3D NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. ", "Silicon Power 256GB SSD 3D NAND A55 SLC Cache Performance Boost SATA III 2.5", 498081m, "https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_.jpg" },
                    { 10, "Easy upgrade for faster boot up, shutdown, application load and response (As compared to 5400 RPM SATA 2.5” hard drive", "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s", 496752m, "https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_.jpg" },
                    { 9, "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg", "WD 2TB Elements Portable External Hard Drive - USB 3.0", 289792m, "" },
                    { 8, "Rose Gold Plated Double Flared Tunnel Plug Earrings. Made of 316L Stainless Steel", "Pierced Owl Rose Gold Plated Stainless Steel Double", 49762m, "https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg" },
                    { 7, "Classic Created Wedding Engagement Solitaire Diamond Promise Ring for Her. Gifts to spoil your love more for Engagement, Wedding, Anniversary, Valentine's Day...", "White Gold Plated Princess", 45234m, "https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg" },
                    { 6, "Satisfaction Guaranteed. Return or exchange any order within 30 days.Designed and sold by Hafeez Center in the United States. Satisfaction Guaranteed. Return or exchange any order within 30 days.", "Solid Gold Petite Micropave", 760705m, "https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg" },
                    { 5, "From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean's pearl. Wear facing inward to be bestowed with love and abundance, or outward for protection.", "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet", 3146966m, "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg" },
                    { 4, "he color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.", "Mens Casual Slim Fit", 72402m, "" },
                    { 3, "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.", "Mens Cotton Jacket", 253523m, "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg" },
                    { 20, "5%Cotton,5%Spandex, Features: Casual, Short Sleeve, Letter Print,V-Neck,Fashion Tees, The fabric is soft and has some stretch", "DANVOUY Womens T Shirt Casual Cotton Short", 90560m, "https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_.jpg" },
                    { 2, "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.", "Mens Casual Premium Slim Fit T-Shirts", 100974m, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.RenameColumn(
                name: "UrlImage",
                table: "Products",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "SellingPrice");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Code");

            migrationBuilder.AddColumn<int>(
                name: "Maximum",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minimum",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PurshacePrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Maximum", "Minimum", "Name", "PurshacePrice", "SellingPrice", "Type" },
                values: new object[] { "das54a5da", 708, 50, "Televisor", 1500000m, 1700000m, "XDXDXD" });
        }
    }
}
