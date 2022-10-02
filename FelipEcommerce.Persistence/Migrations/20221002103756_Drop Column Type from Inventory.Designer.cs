﻿// <auto-generated />
using System;
using FelipEcommerce.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FelipEcommerce.Persistence.Migrations
{
    [DbContext(typeof(FelipEcommerceContext))]
    [Migration("20221002103756_Drop Column Type from Inventory")]
    partial class DropColumnTypefromInventory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "2246 Joy Lane Burbank CA 91502",
                            Age = 65,
                            Dni = "548875445",
                            FirstName = "Heather",
                            LastName = " K. Garcia",
                            Phone = "818-567-4835"
                        },
                        new
                        {
                            Id = 2,
                            Address = "1323 Merivale Road Ottawa, ON K2P 0K1",
                            Age = 76,
                            Dni = "370 670 952",
                            FirstName = "Quintin P.",
                            LastName = "Evans",
                            Phone = "613-380-4940"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Lakeview Heights, BC V1Z 1K2",
                            Age = 18,
                            Dni = "667 962 229",
                            FirstName = "Ruby C.",
                            LastName = "Crawford",
                            Phone = "416-609-6578"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Nanaimo, BC V9R 3A8",
                            Age = 38,
                            Dni = "328 840 673",
                            FirstName = "Stephanie F.",
                            LastName = "Fahey",
                            Phone = "250-816-8363"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Cranbrook, BC V1C 2R9",
                            Age = 65,
                            Dni = "598 123 990",
                            FirstName = "Hugh A.",
                            LastName = "Logan",
                            Phone = "250-417-7243"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Windsor, ON N8Y 4V1",
                            Age = 25,
                            Dni = "451 591 119",
                            FirstName = "David M.",
                            LastName = "Yang",
                            Phone = "519-981-6925"
                        },
                        new
                        {
                            Id = 7,
                            Address = "Alexandra, PE C1B 0N7",
                            Age = 34,
                            Dni = "038 970 604",
                            FirstName = "Randall Laureano",
                            LastName = "Rodrígez",
                            Phone = "902-368-0646"
                        },
                        new
                        {
                            Id = 8,
                            Address = "Calgary, AB T2P 0H3",
                            Age = 77,
                            Dni = "234 463 297",
                            FirstName = "Ezequías Regalado",
                            LastName = "Henríquez",
                            Phone = "403-473-8979"
                        },
                        new
                        {
                            Id = 9,
                            Address = "Calgary, AB T2V 2W2",
                            Age = 26,
                            Dni = "544 769 607",
                            FirstName = "Carissa Gutiérrez",
                            LastName = "Sarabia",
                            Phone = "403-861-4303"
                        },
                        new
                        {
                            Id = 10,
                            Address = "Cobourg, ON K9A 1J1",
                            Age = 36,
                            Dni = "201 756 269",
                            FirstName = "Fabrizio Vázquez",
                            LastName = "Cepeda",
                            Phone = "905-373-3704"
                        },
                        new
                        {
                            Id = 11,
                            Address = "Fort Erie, ON L2A 1P3",
                            Age = 45,
                            Dni = "342 233 863",
                            FirstName = "Achill Magana",
                            LastName = "Pedroza",
                            Phone = "289-321-0566"
                        },
                        new
                        {
                            Id = 12,
                            Address = "Toronto, ON M3H 4J1",
                            Age = 68,
                            Dni = "554 687 665",
                            FirstName = "Inalén Medrano",
                            LastName = "Lebrón",
                            Phone = "416-378-8701"
                        },
                        new
                        {
                            Id = 13,
                            Address = "Tingwick, QC J0A 1L0",
                            Age = 45,
                            Dni = "490 494 556",
                            FirstName = "Petronio Dueñas",
                            LastName = "Galindo",
                            Phone = "819-359-4816"
                        },
                        new
                        {
                            Id = 14,
                            Address = "St Catharines, ON L2N 1S8",
                            Age = 63,
                            Dni = "081 465 452",
                            FirstName = "Debra Tirado",
                            LastName = "Trejo",
                            Phone = "289-228-2329"
                        },
                        new
                        {
                            Id = 15,
                            Address = "Mission, BC V2V 1J7",
                            Age = 23,
                            Dni = "116 625 781",
                            FirstName = "Tibalt Alejandro",
                            LastName = "Velásquez",
                            Phone = "604-814-7305"
                        },
                        new
                        {
                            Id = 16,
                            Address = "Quebec, QC G1V 3V5",
                            Age = 63,
                            Dni = "079 929 295",
                            FirstName = "Justiniano Vigil",
                            LastName = "Castellanos",
                            Phone = "418-569-7055"
                        },
                        new
                        {
                            Id = 17,
                            Address = "Edmonton, AB T5C 2L2",
                            Age = 29,
                            Dni = "460 547 342",
                            FirstName = "Crisóstomo Raya",
                            LastName = "Cantú",
                            Phone = "780-475-8399"
                        },
                        new
                        {
                            Id = 18,
                            Address = "Ottawa, ON K1P 5M7",
                            Age = 37,
                            Dni = "716 623 541",
                            FirstName = "Palemon",
                            LastName = "Peres Vega",
                            Phone = "613-978-8428"
                        },
                        new
                        {
                            Id = 19,
                            Address = "Bouchette, QC H0H 0H0",
                            Age = 42,
                            Dni = "757 081 815",
                            FirstName = "Edelira",
                            LastName = "Rodrígez Muñoz",
                            Phone = "819-465-9142"
                        },
                        new
                        {
                            Id = 20,
                            Address = "Rocky Mountain House, AB T0M 1T1",
                            Age = 66,
                            Dni = "652 341 447",
                            FirstName = "Elijah",
                            LastName = "Ceja Caballero",
                            Phone = "403-846-2441"
                        },
                        new
                        {
                            Id = 21,
                            Address = "Montreal, QC H4J 1M9",
                            Age = 80,
                            Dni = "445 737 539",
                            FirstName = "Amir",
                            LastName = "Sevilla Gamez",
                            Phone = "514-377-1176"
                        },
                        new
                        {
                            Id = 22,
                            Address = "Nobel, ON P0G 1G0",
                            Age = 50,
                            Dni = "064 667 884",
                            FirstName = "Aimée",
                            LastName = "Fernández Gracia",
                            Phone = "705-342-5282"
                        },
                        new
                        {
                            Id = 23,
                            Address = "Minburn, AB T0B 3B0",
                            Age = 23,
                            Dni = "479 099 640",
                            FirstName = "Ona Negrete",
                            LastName = "Arenas",
                            Phone = "780-593-0182"
                        },
                        new
                        {
                            Id = 24,
                            Address = "Victoria, BC V8Z 2J8",
                            Age = 45,
                            Dni = "106 469 133",
                            FirstName = "Mili",
                            LastName = "Arriaga Lozada",
                            Phone = "250-881-7583"
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InventoryDate")
                        .HasColumnType("Date");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Inventory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InventoryDate = new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            ProductId = 1,
                            Qty = 2
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("Date");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Isv")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("InvoiceNumber")
                        .IsUnique()
                        .HasFilter("[InvoiceNumber] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 2,
                            Discount = 10,
                            InvoiceDate = new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            InvoiceNumber = "8D65S96X8D",
                            Isv = 19,
                            SubTotal = 0m,
                            Total = 0m,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoicesDetail");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                            Name = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                            Price = 497854m,
                            UrlImage = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                            Name = "Mens Casual Premium Slim Fit T-Shirts",
                            Price = 100974m,
                            UrlImage = "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.",
                            Name = "Mens Cotton Jacket",
                            Price = 253523m,
                            UrlImage = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Description = "he color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.",
                            Name = "Mens Casual Slim Fit",
                            Price = 72402m,
                            UrlImage = "https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Description = "From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean's pearl. Wear facing inward to be bestowed with love and abundance, or outward for protection.",
                            Name = "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet",
                            Price = 3146966m,
                            UrlImage = "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Satisfaction Guaranteed. Return or exchange any order within 30 days.Designed and sold by Hafeez Center in the United States. Satisfaction Guaranteed. Return or exchange any order within 30 days.",
                            Name = "Solid Gold Petite Micropave",
                            Price = 760705m,
                            UrlImage = "https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Classic Created Wedding Engagement Solitaire Diamond Promise Ring for Her. Gifts to spoil your love more for Engagement, Wedding, Anniversary, Valentine's Day...",
                            Name = "White Gold Plated Princess",
                            Price = 45234m,
                            UrlImage = "https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Rose Gold Plated Double Flared Tunnel Plug Earrings. Made of 316L Stainless Steel",
                            Name = "Pierced Owl Rose Gold Plated Stainless Steel Double",
                            Price = 49762m,
                            UrlImage = "https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg"
                        },
                        new
                        {
                            Id = 9,
                            Description = "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg",
                            Name = "WD 2TB Elements Portable External Hard Drive - USB 3.0",
                            Price = 289792m,
                            UrlImage = "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Easy upgrade for faster boot up, shutdown, application load and response (As compared to 5400 RPM SATA 2.5” hard drive",
                            Name = "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s",
                            Price = 496752m,
                            UrlImage = "https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_.jpg"
                        },
                        new
                        {
                            Id = 11,
                            Description = "3D NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. ",
                            Name = "Silicon Power 256GB SSD 3D NAND A55 SLC Cache Performance Boost SATA III 2.5",
                            Price = 498081m,
                            UrlImage = "https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_.jpg"
                        },
                        new
                        {
                            Id = 12,
                            Description = "WD NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. ",
                            Name = "WD 4TB Gaming Drive Works with Playstation 4 Portable External Hard Drive",
                            Price = 510721m,
                            UrlImage = "https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_.jpg"
                        },
                        new
                        {
                            Id = 13,
                            Description = "1. 5 inches Full HD (1920 x 1080) widescreen IPS display And Radeon free Sync technology. ",
                            Name = "Acer SB220Q bi 21.5 inches Full HD (1920 x 1080) IPS Ultra-Thin",
                            Price = 2712277m,
                            UrlImage = "https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_.jpg"
                        },
                        new
                        {
                            Id = 14,
                            Description = "49 INCH SUPER ULTRAWIDE 32:9 CURVED GAMING MONITOR with dual 27 inch screen side by side QUANTUM DOT (QLED) TECHNOLOGY",
                            Name = "Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor (LC49HG90DMNXZA) – Super Ultrawide Screen QLED",
                            Price = 4527964m,
                            UrlImage = "https://fakestoreapi.com/img/81Zt42ioCgL._AC_SX679_.jpg"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Note:The Jackets is US standard size, Please choose size as your usual wear Material: 100% Polyester; Detachable Liner Fabric: Warm Fleece",
                            Name = "BIYLACLESEN Women's 3-in-1 Snowboard Jacket Winter Coats",
                            Price = 258051m,
                            UrlImage = "https://fakestoreapi.com/img/51Y5NI-I5jL._AC_UX679_.jpg"
                        },
                        new
                        {
                            Id = 16,
                            Description = "00% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON (SWEATER)",
                            Name = "Lock and Love Women's Removable Hooded Faux Leather Moto Biker Jacket",
                            Price = 135613m,
                            UrlImage = "https://fakestoreapi.com/img/81XH0e8fefL._AC_UY879_.jpg"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Lightweight perfet for trip or casual wear---Long sleeve with hooded, adjustable drawstring waist design. ",
                            Name = "Rain Jacket Women Windbreaker Striped Climbing Raincoats",
                            Price = 181075m,
                            UrlImage = "https://fakestoreapi.com/img/71HblAHs5xL._AC_UY879_-2.jpg"
                        },
                        new
                        {
                            Id = 18,
                            Description = "5% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach, Lightweight fabric with great stretch for comfort, Ribbed on sleeves and neckline / Double stitching on bottom hem",
                            Name = "MBJ Women's Solid Short Sleeve Boat Neck V",
                            Price = 44600m,
                            UrlImage = "https://fakestoreapi.com/img/71z3kpMAYsL._AC_UY879_.jpg"
                        },
                        new
                        {
                            Id = 19,
                            Description = "100% Polyester, Machine wash, 100% cationic polyester interlock",
                            Name = "Opna Women's Short Sleeve Moisture",
                            Price = 35997m,
                            UrlImage = "https://fakestoreapi.com/img/51eg55uWmdL._AC_UX679_.jpg"
                        },
                        new
                        {
                            Id = 20,
                            Description = "5%Cotton,5%Spandex, Features: Casual, Short Sleeve, Letter Print,V-Neck,Fashion Tees, The fabric is soft and has some stretch",
                            Name = "DANVOUY Womens T Shirt Casual Cotton Short",
                            Price = 90560m,
                            UrlImage = "https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_.jpg"
                        },
                        new
                        {
                            Id = 21,
                            Description = "XD",
                            Name = "Producto de prueba",
                            Price = 5000m,
                            UrlImage = "https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_.jpg"
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Edwin Trevino",
                            Password = "edwingladiatoryoda123$",
                            UserName = "edwingladiatoryoda"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Donald Smith MD",
                            Password = "Donaldspinachcheetah123$",
                            UserName = "Donaldspinachcheetah"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "James Taylor",
                            Password = "jameshippopotamuspie",
                            UserName = "jamescitizenkanewind"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Todd Hobbs",
                            Password = "Toddroastpeardrumrye",
                            UserName = "Toddthegraduaterye"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Vanessa Leblanc",
                            Password = "Vanessacowriverpig",
                            UserName = "Vanessagandalftimon"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Reginald Cruz",
                            Password = "Reginaldngc5195bread",
                            UserName = "Reginaldpomegranate"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "John Collins",
                            Password = "Johnbirthdaycakelog",
                            UserName = "Johnspiralshapeflute"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Juan Ball",
                            Password = "Juanplatoonfrognet",
                            UserName = "Juanrearwindowbridge"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Brian Henry",
                            Password = "Brianbatthegoldrush",
                            UserName = "Brianastronoutwine"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Kathleen Ramirez",
                            Password = "Kathleenhaloakirapig",
                            UserName = "Kathleenxylophonered"
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Inventory", b =>
                {
                    b.HasOne("FelipEcommerce.Domain.Models.Product", "Product")
                        .WithOne("Inventory")
                        .HasForeignKey("FelipEcommerce.Domain.Models.Inventory", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Invoice", b =>
                {
                    b.HasOne("FelipEcommerce.Domain.Models.Client", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FelipEcommerce.Domain.Models.User", "User")
                        .WithMany("Invoices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.InvoiceDetail", b =>
                {
                    b.HasOne("FelipEcommerce.Domain.Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetail")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FelipEcommerce.Domain.Models.Product", "Product")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Client", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetail");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Product", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.User", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
