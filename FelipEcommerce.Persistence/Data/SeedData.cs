using System;
using FelipEcommerce.Domain.Models;
using System.Collections.Generic;

namespace FelipEcommerce.Persistence.Data
{
    public class SeedData
    {
        public static List<User> Users = new List<User>()
        {
            new User
            {
                Id = 1,
                FullName = "Edwin Trevino",
                UserName = "edwingladiatoryoda",
                Password = "edwingladiatoryoda123$"
            },
            new User
            {
                Id = 2,
                FullName = "Donald Smith MD",
                UserName = "Donaldspinachcheetah",
                Password = "Donaldspinachcheetah123$"
            },
            new User
            {
                Id = 3,
                FullName = "James Taylor",
                UserName = "jamescitizenkanewind",
                Password = "jameshippopotamuspie"
            },
            new User
            {
                Id = 4,
                FullName = "Todd Hobbs",
                UserName = "Toddthegraduaterye",
                Password = "Toddroastpeardrumrye"
            },
            new User
            {
                Id = 5,
                FullName = "Vanessa Leblanc",
                UserName = "Vanessagandalftimon",
                Password = "Vanessacowriverpig"
            },
            new User
            {
                Id = 6,
                FullName = "Reginald Cruz",
                UserName = "Reginaldpomegranate",
                Password = "Reginaldngc5195bread"
            },
            new User
            {
                Id = 7,
                FullName = "John Collins",
                UserName = "Johnspiralshapeflute",
                Password = "Johnbirthdaycakelog"
            },
            new User
            {
                Id = 8,
                FullName = "Juan Ball",
                UserName = "Juanrearwindowbridge",
                Password = "Juanplatoonfrognet"
            },
            new User
            {
                Id = 9,
                FullName = "Brian Henry",
                UserName = "Brianastronoutwine",
                Password = "Brianbatthegoldrush"
            },
            new User
            {
                Id = 10,
                FullName = "Kathleen Ramirez",
                UserName = "Kathleenxylophonered",
                Password = "Kathleenhaloakirapig"
            }
        };

        public static List<Client> Clients = new List<Client>()
        {
            new Client
            {
                Id = 1,
                Address = "2246 Joy Lane Burbank CA 91502",
                Dni = "548875445",
                FirstName = "Heather",
                LastName = " K. Garcia",
                Phone = "818-567-4835",
                Age = 65
            },
            new Client
            {
                Id = 2,
                FirstName = "Quintin P.",
                LastName = "Evans",
                Address = "1323 Merivale Road Ottawa, ON K2P 0K1",
                Dni = "370 670 952",
                Phone = "613-380-4940",
                Age = 76
            },
            new Client
            {
                Id = 3,
                FirstName = "Ruby C.",
                LastName = "Crawford",
                Address = "Lakeview Heights, BC V1Z 1K2",
                Dni = "667 962 229",
                Phone = "416-609-6578",
                Age = 18
            },
            new Client
            {
                Id = 4,
                FirstName = "Stephanie F.",
                LastName = "Fahey",
                Address = "Nanaimo, BC V9R 3A8",
                Dni = "328 840 673",
                Phone = "250-816-8363",
                Age = 38
            },
            new Client
            {
                Id = 5,
                FirstName = "Hugh A.",
                LastName = "Logan",
                Address = "Cranbrook, BC V1C 2R9",
                Dni = "598 123 990",
                Phone = "250-417-7243",
                Age = 65
            },
            new Client
            {
                Id = 6,
                FirstName = "David M.",
                LastName = "Yang",
                Address = "Windsor, ON N8Y 4V1",
                Dni = "451 591 119",
                Phone = "519-981-6925",
                Age = 25
            },
            new Client
            {
                Id = 7,
                FirstName = "Randall Laureano",
                LastName = "Rodrígez",
                Address = "Alexandra, PE C1B 0N7",
                Dni = "038 970 604",
                Phone = "902-368-0646",
                Age = 34
            },
            new Client
            {
                Id = 8,
                FirstName = "Ezequías Regalado",
                LastName = "Henríquez",
                Address = "Calgary, AB T2P 0H3",
                Dni = "234 463 297",
                Phone = "403-473-8979",
                Age = 77
            },
            new Client
            {
                Id = 9,
                FirstName = "Carissa Gutiérrez",
                LastName = "Sarabia",
                Address = "Calgary, AB T2V 2W2",
                Dni = "544 769 607",
                Phone = "403-861-4303",
                Age = 26
            },
            new Client
            {
                Id = 10,
                FirstName = "Fabrizio Vázquez",
                LastName = "Cepeda",
                Address = "Cobourg, ON K9A 1J1",
                Dni = "201 756 269",
                Phone = "905-373-3704",
                Age = 36
            },
            new Client
            {
                Id = 11,
                FirstName = "Achill Magana",
                LastName = "Pedroza",
                Address = "Fort Erie, ON L2A 1P3",
                Dni = "342 233 863",
                Phone = "289-321-0566",
                Age = 45
            },
            new Client
            {
                Id = 12,
                FirstName = "Inalén Medrano",
                LastName = "Lebrón",
                Address = "Toronto, ON M3H 4J1",
                Dni = "554 687 665",
                Phone = "416-378-8701",
                Age = 68
            },
            new Client
            {
                Id = 13,
                FirstName = "Petronio Dueñas",
                LastName = "Galindo",
                Address = "Tingwick, QC J0A 1L0",
                Dni = "490 494 556",
                Phone = "819-359-4816",
                Age = 45
            },
            new Client
            {
                Id = 14,
                FirstName = "Debra Tirado",
                LastName = "Trejo",
                Address = "St Catharines, ON L2N 1S8",
                Dni = "081 465 452",
                Phone = "289-228-2329",
                Age = 63
            },
            new Client
            {
                Id = 15,
                FirstName = "Tibalt Alejandro",
                LastName = "Velásquez",
                Address = "Mission, BC V2V 1J7",
                Dni = "116 625 781",
                Phone = "604-814-7305",
                Age = 23
            },
            new Client
            {
                Id = 16,
                FirstName = "Justiniano Vigil",
                LastName = "Castellanos",
                Address = "Quebec, QC G1V 3V5",
                Dni = "079 929 295",
                Phone = "418-569-7055",
                Age = 63
            },
            new Client
            {
                Id = 17,
                FirstName = "Crisóstomo Raya",
                LastName = "Cantú",
                Address = "Edmonton, AB T5C 2L2",
                Dni = "460 547 342",
                Phone = "780-475-8399",
                Age = 29
            },
            new Client
            {
                Id = 18,
                FirstName = "Palemon",
                LastName = "Peres Vega",
                Address = "Ottawa, ON K1P 5M7",
                Dni = "716 623 541",
                Phone = "613-978-8428",
                Age = 37
            },
            new Client
            {
                Id = 19,
                FirstName = "Edelira",
                LastName = "Rodrígez Muñoz",
                Address = "Bouchette, QC H0H 0H0",
                Dni = "757 081 815",
                Phone = "819-465-9142",
                Age = 42
            },
            new Client
            {
                Id = 20,
                FirstName = "Elijah",
                LastName = "Ceja Caballero",
                Address = "Rocky Mountain House, AB T0M 1T1",
                Dni = "652 341 447",
                Phone = "403-846-2441",
                Age = 66
            },
            new Client
            {
                Id = 21,
                FirstName = "Amir",
                LastName = "Sevilla Gamez",
                Address = "Montreal, QC H4J 1M9",
                Dni = "445 737 539",
                Phone = "514-377-1176",
                Age = 80
            },
            new Client
            {
                Id = 22,
                FirstName = "Aimée",
                LastName = "Fernández Gracia",
                Address = "Nobel, ON P0G 1G0",
                Dni = "064 667 884",
                Phone = "705-342-5282",
                Age = 50
            },
            new Client
            {
                Id = 23,
                FirstName = "Ona Negrete",
                LastName = "Arenas",
                Address = "Minburn, AB T0B 3B0",
                Dni = "479 099 640",
                Phone = "780-593-0182",
                Age = 23
            },
            new Client
            {
                Id = 24,
                FirstName = "Mili",
                LastName = "Arriaga Lozada",
                Address = "Victoria, BC V8Z 2J8",
                Dni = "106 469 133",
                Phone = "250-881-7583",
                Age = 45
            }
        };

        public static List<Product> Products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                Price = 497854,
                Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                UrlImage = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg"
            },
            new Product
            {
                Id = 2,
                Name = "Mens Casual Premium Slim Fit T-Shirts",
                Price = 100974,
                Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                UrlImage = ""
            },
            new Product
            {
                Id = 3,
                Name = "Mens Cotton Jacket",
                Price = 253523,
                Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.",
                UrlImage = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg"
            },
            new Product
            {
                Id = 4,
                Name = "Mens Casual Slim Fit",
                Price = 72402,
                Description = "he color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.",
                UrlImage = ""
            },
            new Product
            {
                Id = 5,
                Name = "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet",
                Price = 3146966,
                Description = "From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean's pearl. Wear facing inward to be bestowed with love and abundance, or outward for protection.",
                UrlImage = "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg"
            },
            new Product
            {
                Id = 6,
                Name = "Solid Gold Petite Micropave",
                Price = 760705,
                Description = "Satisfaction Guaranteed. Return or exchange any order within 30 days.Designed and sold by Hafeez Center in the United States. Satisfaction Guaranteed. Return or exchange any order within 30 days.",
                UrlImage = "https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg"
            },
            new Product
            {
                Id = 7,
                Name = "White Gold Plated Princess",
                Price = 45234,
                Description = "Classic Created Wedding Engagement Solitaire Diamond Promise Ring for Her. Gifts to spoil your love more for Engagement, Wedding, Anniversary, Valentine's Day...",
                UrlImage = "https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg"
            },
            new Product
            {
                Id = 8,
                Name = "Pierced Owl Rose Gold Plated Stainless Steel Double",
                Price = 49762,
                Description = "Rose Gold Plated Double Flared Tunnel Plug Earrings. Made of 316L Stainless Steel",
                UrlImage = "https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg"
            },
            new Product
            {
                Id = 9,
                Name = "WD 2TB Elements Portable External Hard Drive - USB 3.0",
                Price = 289792,
                Description = "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg",
                UrlImage = ""
            },
            new Product
            {
                Id = 10,
                Name = "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s",
                Price = 496752,
                Description = "Easy upgrade for faster boot up, shutdown, application load and response (As compared to 5400 RPM SATA 2.5” hard drive",
                UrlImage = "https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_.jpg"
            },
            new Product
            {
                Id = 11,
                Name = "Silicon Power 256GB SSD 3D NAND A55 SLC Cache Performance Boost SATA III 2.5",
                Price = 498081,
                Description = "3D NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. ",
                UrlImage = "https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_.jpg"
            },
            new Product
            {
                Id = 12,
                Name = "WD 4TB Gaming Drive Works with Playstation 4 Portable External Hard Drive",
                Price = 510721,
                Description = "WD NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. ",
                UrlImage = "https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_.jpg"
            },
            new Product
            {
                Id = 13,
                Name = "Acer SB220Q bi 21.5 inches Full HD (1920 x 1080) IPS Ultra-Thin",
                Price = 2712277,
                Description = "1. 5 inches Full HD (1920 x 1080) widescreen IPS display And Radeon free Sync technology. ",
                UrlImage = "https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_.jpg"
            },
            new Product
            {
                Id = 14,
                Name = "Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor (LC49HG90DMNXZA) – Super Ultrawide Screen QLED",
                Price = 4527964,
                Description = "49 INCH SUPER ULTRAWIDE 32:9 CURVED GAMING MONITOR with dual 27 inch screen side by side QUANTUM DOT (QLED) TECHNOLOGY",
                UrlImage = "https://fakestoreapi.com/img/81Zt42ioCgL._AC_SX679_.jpg"
            },
            new Product
            {
                Id = 15,
                Name = "BIYLACLESEN Women's 3-in-1 Snowboard Jacket Winter Coats",
                Price = 258051,
                Description = "Note:The Jackets is US standard size, Please choose size as your usual wear Material: 100% Polyester; Detachable Liner Fabric: Warm Fleece",
                UrlImage = "https://fakestoreapi.com/img/51Y5NI-I5jL._AC_UX679_.jpg"
            },
            new Product
            {
                Id = 16,
                Name = "Lock and Love Women's Removable Hooded Faux Leather Moto Biker Jacket",
                Price = 135613,
                Description = "00% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON (SWEATER)",
                UrlImage = "https://fakestoreapi.com/img/81XH0e8fefL._AC_UY879_.jpg"
            },
            new Product
            {
                Id = 17,
                Name = "Rain Jacket Women Windbreaker Striped Climbing Raincoats",
                Price = 181075,
                Description = "Lightweight perfet for trip or casual wear---Long sleeve with hooded, adjustable drawstring waist design. ",
                UrlImage = "https://fakestoreapi.com/img/71HblAHs5xL._AC_UY879_-2.jpg"
            },
            new Product
            {
                Id = 18,
                Name = "MBJ Women's Solid Short Sleeve Boat Neck V",
                Price = 44600,
                Description = "5% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach, Lightweight fabric with great stretch for comfort, Ribbed on sleeves and neckline / Double stitching on bottom hem",
                UrlImage = "https://fakestoreapi.com/img/71z3kpMAYsL._AC_UY879_.jpg"
            },
            new Product
            {
                Id = 19,
                Name = "Opna Women's Short Sleeve Moisture",
                Price = 35997,
                Description = "100% Polyester, Machine wash, 100% cationic polyester interlock",
                UrlImage = "https://fakestoreapi.com/img/51eg55uWmdL._AC_UX679_.jpg"
            },
            new Product
            {
                Id = 20,
                Name = "DANVOUY Womens T Shirt Casual Cotton Short",
                Price = 90560,
                Description = "5%Cotton,5%Spandex, Features: Casual, Short Sleeve, Letter Print,V-Neck,Fashion Tees, The fabric is soft and has some stretch",
                UrlImage = "https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_.jpg"
            }
        };

        public static List<Invoice> Invoices = new List<Invoice>()
        {
            new Invoice
            {
                Id = 1,
                ClientId = 1,
                UserId = 1,
                Discount = 19,
                SubTotal = 1000,
                Total = 10000,
                InvoiceDate = DateTime.Today
            }
        };

        public static List<InvoiceDetail> InvoiceDetails = new List<InvoiceDetail>()
        {
            new InvoiceDetail
            {
                Id = 1,
                InvoiceId = 1,
                Qty = 5,
                Price = 5000,
                ProductId = 1
            }
        };

        public static List<Inventory> Inventories = new List<Inventory>()
        {
            new Inventory
            {
                Id = 1,
                Type = "XD",
                ProductId = 1,
                Qty = 50,
                InventoryDate = DateTime.Today
            }
        };
    }
}