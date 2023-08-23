using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoogleSolution.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUser = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allow = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DownloadCount = table.Column<int>(type: "int", nullable: false),
                    Allow = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageLikes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLikes", x => new { x.ImageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ImageLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageLikes_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageTags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTags", x => new { x.ImageId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ImageTags_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsUser", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", null, 0, "ef6a94d4-0741-4c90-89b1-f4f549781ec6", "hsnrz2002@gmail.com", false, "Hesen", "~\\images\\user\\adilabbasov.png", true, "Rzayev", false, null, null, null, null, null, false, "6184f32b-fb3e-451d-abf9-ab759744f2fc", false, "Hesen_Rzayev" },
                    { "2", null, 0, "5aa9957d-0177-48d1-a5d2-3cd1c038cc01", "ffff@gmail.com", false, "Adil", null, true, "Abbasov", false, null, null, null, null, null, false, "b2227343-957d-4bf9-94da-24eee3c1c1aa", false, "Adil_Abbasov" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "About", "AccessFailedCount", "Allow", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsCompleted", "LockoutEnabled", "LockoutEnd", "LogoUrl", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SiteUrl", "TwoFactorEnabled", "UserId", "UserName", "VideoUrl" },
                values: new object[,]
                {
                    { "1", "Oxfam International fights for a world in which an opportunity is not a privilege, but a right for everyone and in which human rights can be claimed. At the core of the organization’s work is working with partner organizations, as well as with vulnerable women and men to end the injustices that cause poverty. It also conducts campaigns to raise the voices of poor on local and global agendas to influence decisions that affect them. During the last two years, Oxfam International worked directly with 22.3 million people across the world and provided immediate relief in times of crisis.", 0, true, "d960d9b2-d218-4c24-9d4a-bbf8189468b3", "info@oxfam.org", false, false, false, null, "https://www.oxfamamerica.org/documents/536/OX_HL_C_RGB.png", "Oxfam International", null, null, null, null, false, "7976d7a9-4a78-4412-a42e-2347a7ccbafe", "https://www.oxfam.org/", false, null, null, "https://www.youtube.com/embed/3TlucE_-kRw" },
                    { "10", "World Relief is an international Christian humanitarian organization working to overcome poverty, injustice and violence. It brings restoration and healing to millions of world’s most vulnerable categories through programs in economic development, peace keeping, health and child development and refugee and immigration services.", 0, true, "7df21993-b88b-4cd2-88a6-439b4aab23f3", "mail@muslimhands.org.uk", false, false, false, null, "https://www.backabuddy.co.za/misc/charity/65cecd293579b98e57c8230a1908cca9.jpg", "Muslim Hands", null, null, null, null, false, "44a40af1-bd0c-49f6-9e7e-ae715a12f2af", "https://muslimhands.org.uk/", false, null, null, "https://www.youtube.com/embed/17X67AojG84" },
                    { "11", "World Relief partners up with churches and communities in more than 20 countries to provide relief and help those suffering rebuild their live. The organization is based in the US, but has offices worldwide, which are supported by churches, foundations and individual donors. So far, World Relief has reached around seven million beneficiaries with the help of 75.000 volunteers who are actively engaged in reaching their communities. It brings together local leaders and pastors to discuss challenges their communities face and provides them with tools to improve their livelihoods.", 0, true, "ec2fe808-0b86-41f6-b1b8-73f70fed216e", "info@brac.net", false, false, false, null, "http://www.brac.net/images/brac-logo-big.png", "BRAC", null, null, null, null, false, "16df818e-f01f-4487-b294-a1b3072b9410", "http://www.brac.net/", false, null, null, "https://www.youtube.com/embed/7Sih7Og4-30" },
                    { "12", "Care International is one of the biggest aid organizations with a mission to fight poverty and injustice. It works in over 90 countries and helps around 65 million people annually to find routes out of poverty.", 0, true, "4e13f59d-62bf-42ce-9e57-43a32ff9fff8", "info@eapn.eu", false, false, false, null, "https://www.eapn.eu/wp-content/uploads/2015/10/logo-eapn-grand.jpg", "European Anti-Poverty Network", null, null, null, null, false, "7138f780-a966-4cb5-9986-92bc2d5c1521", "https://www.eapn.eu/", false, null, null, "https://www.youtube.com/embed/rmSWZOFo8Uk" },
                    { "13", "Care’s International vision is to “seek a world of hope, tolerance and social justice, where poverty has been overcome and all people live with dignity and security”. It delivers emergency aid to survivors of conflict and natural disasters and helps them rebuild their lives afterwards. The programs of the organization tackle the deepest roots that cause poverty and works with private companies to create opportunities for marginalized and poor people to have more access to services, goods and livelihoods. The organization puts women and girls in the center because it believes that world cannot overcome poverty until all people have equal opportunities and rights.", 0, true, "36477404-bcdc-4de1-8515-6208b1efc880", "info@borgenproject.org", false, false, false, null, "https://borgenproject.org/wp-content/uploads/1-copy.jpg", "The Borgen Project", null, null, null, null, false, "58530cad-52b2-49b6-97a7-4122241b513c", "https://borgenproject.org/", false, null, null, "https://www.youtube.com/embed/3Tj7r8IU_Kg" },
                    { "14", "Institute for Research on Poverty (IRP) is a non-profit organization dedicated to producing and disseminating evidence to inform policies and programs to combat poverty and inequality in the US. It conducts national research and trainings by collaborating with researchers, policymakers and practitioners.", 0, true, "f098fee0-48e1-4a29-a92b-1dc7f4a01c28", "info@a4id.org", false, false, false, null, "https://yt3.ggpht.com/ytc/AMLnZu-i4mcY3cgy3aXmtCOA5aIa2Eacuq-xsku5L8To4w=s900-c-k-c0x00ffffff-no-rj", "Advocates for International Development", null, null, null, null, false, "dc2a0bbe-502a-435e-bb8c-c97db69fc7c1", "http://www.a4id.org/", false, null, null, "https://www.youtube.com/embed/FfHwGF_RL9A" },
                    { "15", "The IRP builds, develops and supports a large network of scholars who deal with the issues related to poverty in multiple discipline and conduct interdisciplinary research on the issue. The IRP applies research evidence on key policy questions and advances the understanding of consequences and causes of poverty and inequality in the following areas: child support, children, economic support, education and training, employment, family and partnering, food and nutrition, health, housing, inequality, mobility, justice system, place and poverty measurement.", 0, true, "2679f667-338d-494c-8be4-174772ab3d86", "info@greenshootsfoundation.org", false, false, false, null, "https://greenshootsfoundation.org/wp-content/uploads/2020/10/greenshoots-logo-10years.png", "Green Shots Foundation", null, null, null, null, false, "c4d214c5-4389-451b-9994-1ac1cd736e45", "https://greenshootsfoundation.org/", false, null, null, "https://www.youtube.com/embed/f9dWTTEED14" },
                    { "16", "Innovations for Poverty Action (IPA) is a research and policy NGO that discovers and promotes effective solutions to worldwide poverty problems. It brings together researchers and decision-makers to evaluate these solutions and apply them so to improve the lives of poor populations.", 0, true, "84f252d8-b210-4d3b-a64f-ea0d0cbe2a5f", "iccusa@internationalchildcare.org", false, false, false, null, "https://images.squarespace-cdn.com/content/v1/54d6624ae4b0249186209c53/1498321453884-3M69SNTGNDLPN4OC05HI/GCHiccLogo-CMYK-Enlarged.png", "International Child Care", null, null, null, null, false, "60f1c689-1224-42e3-b025-ae70fe77ed15", "http://www.internationalchildcare.org/", false, null, null, "https://www.youtube.com/embed/sDXYG277hm4" },
                    { "17", "Until today, IPA has designed and evaluated more than 550 solutions to poverty issues and currently it has more than 280 evaluations in progress. The organization has developed extensive expertise in conducting successful evaluations by bringing in leading researchers to ensure that evidence it creates leads to tangible impact on the world. Since its establishment in 2002, IPA has worked with over 600 researchers to conduct over 830 evaluations in 51 countries, which has led to implementation of successful programs that impact the lives of millions of individuals worldwide.", 0, true, "9e51a3d1-fef6-48b2-97c8-a7ca965c866d", "info@one.org", false, false, false, null, "https://upload.wikimedia.org/wikipedia/commons/8/82/ONE-Logo.png", "ONE", null, null, null, null, false, "ddce0937-66f0-4a6a-aa64-c453eb38cfa2", "https://www.one.org/", false, null, null, "https://www.youtube.com/embed/rWoSsKiIcD0" },
                    { "18", "Muslim Hands is an international NGO based in the UK that works in over 50 countries around the globe and is dedicated to tackling the root causes of poverty. The organization is passionate about working beyond the immediate relief, towards supporting communities in the long-term.", 0, true, "feaa7e58-a2f9-4b6a-b5e9-52523fecefa2", "info@ewb-international.org", false, false, false, null, "https://ewb-ye.org/wp-content/uploads/2022/06/ewb-logo-new-1-2-2-copy2.png", "Engineers Without Borders International", null, null, null, null, false, "48259d85-41c7-4bc3-b6fb-261bf8ff97aa", "http://ewb-international.com/", false, null, null, "https://www.youtube.com/embed/0yztUcfSdws" },
                    { "19", "The organization has implemented many long-term project, including schools, healthcare clinics and livelihoods around the world. It works closely with partners and distributes aid in efficient and transparent was to make a lasting difference to the communities it works with. The organization believes that every human being has the right to education, access to clean water and food, as well as means to supports themselves and their families. It approaches each situation on a case by case basis to find appropriate solutions and strives to empower people for the long-term.", 0, true, "3c3e146c-4f11-4c75-9874-cbba875b4c63", "info@worldvision.org", false, false, false, null, "https://logos-download.com/wp-content/uploads/2016/12/World_Vision_logo_logotype.png", "World Vision", null, null, null, null, false, "d76d5e33-eafb-4af5-943a-bc77f06a1467", "https://www.worldvision.org/", false, null, null, "https://www.youtube.com/embed/nCVWcQnDX8I" },
                    { "2", "The Organization for Poverty Alleviation and Development (OPAD) is an international NGO that actively works on poverty alleviation by promoting human rights, sustainable development and climate change. The vision of the organization is to “improve the standard of living of all people by recognizing them as resources and not as victims.", 0, true, "6004c11f-58c2-4ad1-9846-e622e01fd671", "info@opad.eu", false, false, false, null, "https://static.wixstatic.com/media/002cd6_937d4903f0fd45949fee3cc2e4f037eb~mv2.png/v1/crop/x_57,y_0,w_1701,h_783/fill/w_482,h_204,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/logo-2_edited.png", "The Organization for Poverty Alleviation and Development", null, null, null, null, false, "c5062be2-420b-499a-aa66-6ed39952c9a1", "http://www.opadint.org/", false, null, null, "https://www.youtube.com/embed/4XUd7xbOYYU" },
                    { "20", "BRAC is the largest Bangladesh based international NGO with a mission to alleviate poverty and encourage economic participation by empowering people through social and economic programs. The organization works and has positive impact in the poorest Asian and African countries in the world, reaching around 138 million people.", 0, true, "803e7bb7-fda7-4d0d-a50d-ccccc28fb4f4", "info@worldhope.org", false, false, false, null, "https://www.pngitem.com/pimgs/m/366-3661876_world-hope-international-logo-hd-png-download.png", "World Hope International", null, null, null, null, false, "5fe0708d-946a-40ef-903f-5484822fb463", "https://www.worldhope.org/", false, null, null, "https://www.youtube.com/embed/8yVFTw3qAgU" },
                    { "21", "BRAC works in four main areas, including social enterprises, investments, university and social development. It approaches the issue of poverty by using a businesslike approach and takes into considerations factors that go beyond economy that account for why people are impoverished. It tackles social issues and inequality and allows individuals to come out of poverty by providing them with tools to participate in the economy. So far, BRAC has been successful in establishing many enterprises and has provided primary education for 400.000 children and lifted 86.975 households in Bangladesh out of extreme poverty.", 0, true, "9ad9ea2b-8e05-4f25-bf13-083467f2e5c4", "info@villageenterprise.org", false, false, false, null, "https://upload.wikimedia.org/wikipedia/commons/d/d5/VE-Logo_Primary2400_RGB.png", "Village Enterprise", null, null, null, null, false, "a250e87d-2caa-49b4-b3cf-a427cad43987", "http://villageenterprise.org/", false, null, null, "https://www.youtube.com/embed/jo8Zcw465SI" },
                    { "22", "The European Anti-Poverty Network (EAPN) was established in 1990 and since then it has become the largest Europe based network gathering anti-poverty NGOs, grassroots organizations and European organizations that are active in fight against poverty and social exclusion. Currently, the EAPN is a network of 31 national networks of NGOs and 13 European organizations.", 0, true, "6ddd3638-c3d3-471e-93a7-c0e4ae2ee76a", "info@trickleup.org", false, false, false, null, "https://trickleup.org/wp-content/uploads/2020/09/LogoIndigoOrangeLarge.png", "Trickle Up", null, null, null, null, false, "48f61f57-475b-48e1-8938-d3c19da5293a", "https://trickleup.org/", false, null, null, "https://www.youtube.com/embed/4fMMQKYejPQ" },
                    { "23", "The EAPN fights against poverty by using tools such as education, training, service provision and participation to empower people who are faced with poverty and social exclusion. The aim of the EAPN is to put poverty issue on the EU agenda and to ensure cooperation at EU level aimed at the eradication of poverty and social exclusion. The work of the EAPN is concentrated around enhancing of actions to eradicate poverty, raising awareness around the issue, empowering people who are faced with it and lobbying for all people and groups facing poverty and social exclusion.", 0, true, "06e5a700-9336-45d3-9128-0a13520fdeb5", "info@results.org", false, false, false, null, "https://cdn.resultscanada.ca/wp-content/uploads/Results-Logo-ID-1.png", "RESULTS", null, null, null, null, false, "c13db143-ab8c-40a6-ac47-b374c88b4428", "https://results.org/", false, null, null, "https://www.youtube.com/embed/m7M1i1Kf3oY" },
                    { "24", "The Borgen Project is the US based non-profit working to make poverty a focus of the US foreign policy. The organization operates at political levels and advocates for programs that are effective in fighting extreme poverty.", 0, true, "b527d8da-27a6-410b-9da1-dc0127eb8312", "info@orphansinneed.org.uk", false, false, false, null, " https://images.jg-cdn.com/image/e9987b3e-fa5a-4a55-a79f-01f4338a679d.jpg", "Orphans in Need", null, null, null, null, false, "af7385b3-b43f-4676-b6ea-3533287e8533", "https://www.orphansinneed.org.uk/", false, null, null, "https://www.youtube.com/embed/WMolKf7iap0" },
                    { "25", "The focus of the organization’s advocacy efforts are starvation and global food security, newborn, child and mother survival, access to clear water and sanitation and food aid reform. The Borgen Project advocates for solutions of these issues by meeting the US congressional members to secure support for poverty reducing legislation. It also mobilizes people around the world to make the issue of poverty a political priority and teaches them basic advocacy skills that will allow them to communicate with their governments. In this way, the Borgen Project builds awareness of global issues and innovations in poverty reduction.", 0, true, "af3f856f-119e-4aba-ac04-9960f19f4901", "info@street-child.org", false, false, false, null, "https://images.squarespace-cdn.com/content/v1/5612639be4b0b2769222579e/1444046635914-WNI5KS1NUD9417IGSVRA/STREETCHILD+FB.jpg", "Street Child", null, null, null, null, false, "8b8216ae-47d0-4eb7-b4cb-2d381b326c78", "https://street-child.org/", false, null, null, "https://www.youtube.com/embed/SZtYxanbZKE" },
                    { "3", "OPAD acts internationally by offering a variety of services directed towards eradicating poverty. The organization implements many projects of poverty eradication in developing countries by using tools such as education, economic development, health promotion and income redistribution. It also advocates for equal rights to economic resources amongst men and women and works with small-scale food producers, such as women, indigenous groups, family farmers and pastoralists, to improve their income and sources of livelihood. It supports local initiatives by promoting self-reliance amongst women, men and youth in poor countries.", 0, true, "89bfc8b5-bbe1-4687-a276-ec83a84780d9", "info@concern.net", false, false, false, null, "https://getlogovector.com/wp-content/uploads/2020/04/concern-worldwide-logo-vector.png", "Concern Worldwide", null, null, null, null, false, "39c7b044-2fca-482f-a8c7-37953d081128", "https://concernworldwide.org/", false, null, null, "https://www.youtube.com/embed/oGqDyoTcDKk" },
                    { "4", "Concern Worldwide is an international humanitarian organization working to free the world from poverty, fear and oppression. It intervenes in the world’s poorest countries and helps the most vulnerable people. The ultimate goal of the organization is to end extreme poverty. Concern Worldwide has, thus, been working for over 50 years with the world’s poorest people to transform their lives. Its team is comprised of 3.500 professionals coming from 50 countries, and who, each year, work with 25 million underprivileged people.", 0, true, "5ab1384c-8a84-4cca-a2da-00dc7b9557bf", "info@endpovertynowinc.org", false, false, false, null, "https://endpovertynowinc.org/wp-content/uploads/2022/10/cropped-EPN_Logo_white.png", "End Poverty Now", null, null, null, null, false, "e0f1d488-2b47-45b0-a0eb-8c01ac34b769", "https://endpovertynowinc.org/", false, null, null, "https://www.youtube.com/embed/N6UqjIwfz3k" },
                    { "5", "Concern Worldwide reaches and helps the most fragile communities affected by conflict, natural disasters, climate change, flooding, and extreme hunger. The organization implements various programs designed to address specific causes of extreme poverty in communities in 25 countries. It focuses on six thematic areas: livelihoods, health and nutrition, education, emergencies, gender equality and innovations. The core of the organization’s work is empowering local communities to build their resilience and ensure their transformation is sustainable and long-lasting, with an aim to achieve a vision of a world free poverty, fear and oppression.", 0, true, "abf998fc-b15b-4794-a76f-32f820eb7382", "info@globalcitizen.org", false, false, false, null, "https://static.globalcitizen.org/static/img/gc-logo-no-space.png", "Global Citizen", null, null, null, null, false, "5e747b67-0a16-4b3c-9949-89f0cd9b57d1", "https://www.globalcitizen.org/en/", false, null, null, "https://www.youtube.com/embed/JhlQKgiJH00" },
                    { "6", "End Poverty Now (EPN) is a Canadian NGO that passionately works on advocating for hungry, needy and politically under-represented people across the world. The organization is dedicated to alleviating poverty globally operating through grassroot projects and educational initiatives. The mission of the EPN is to partner with other organizations to support communities in need, fund sustainable community initiatives and educate and raise awareness of economic and social issues related to poverty.", 0, true, "db606001-6ee6-47e4-9057-0bed2eaaf573", "info@worldrelief.org", false, false, false, null, "https://upload.wikimedia.org/wikipedia/commons/1/1b/World_Relief.jpg", "World Relief", null, null, null, null, false, "9d65530c-b3dc-4f0a-b3a9-3e9d4704fbc4", "https://worldrelief.org/", false, null, null, "https://www.youtube.com/embed/Z3-1SfRTwGc" },
                    { "7", "The EPN fosters a network of non-profit organizations, volunteers, and donors to fight poverty in local communities. It supports community-led projects to build leadership and lift people out of poverty and provide them with skills to create independent solutions for their future livelihoods. The projects that the EPN funds keep going after financial means are cut since the organization makes sure that the projects are funded in the future through other charitable organizations. It achieves this by bringing together organizations and individuals who, otherwise, would never meet before.", 0, true, "be0ee4b9-a71e-43c3-8b2f-5fb6dc33f886", "info@care.org", false, false, false, null, "https://landportal.org/sites/landportal.org/files/styles/220heightmax/public/care-social-image.jpg", "Care International", null, null, null, null, false, "c3a6bf8b-38cd-4033-b26a-496f515e7ae3", "https://www.care-international.org/", false, null, null, "https://www.youtube.com/embed/iiMQ8CVWRkY" },
                    { "8", "The Global Citizen is an international advocacy organization working on ending extreme poverty. It serves as a movement of engaged citizens who use their collective voice with a goal to end extreme poverty by 2030. The organization’s headquarters is in New York, with branch offices in Canada, Australia, South Africa, Germany and the UK.", 0, true, "5cdf7bac-c0b2-4726-a084-86254ee4e378", "irpweb@ssc.wisc.edu", false, false, false, null, "https://www.irp.wisc.edu/wp/wp-content/uploads/2018/04/IRP-2018b.png", "Institute for Research on Poverty", null, null, null, null, false, "1125d2eb-fc9e-47f7-bb9d-45826aa89d30", "https://www.irp.wisc.edu/", false, null, null, "https://www.youtube.com/embed/LuWcDAKld24" },
                    { "9", "The Global Citizen platform provides tools and knowledge to its members to learn about the systemic causes of extreme poverty and to take actions on those issue. So far, millions of global citizens around the world have taken over 24 million actions to target world leaders to eradicate extreme poverty by 2030. The Global Citizen organizes global campaigns to amplify these actions and so far, this has resulted in commitments and policy announcements by leaders, valued at over 48 billion dollars.", 0, true, "d770bd1c-c214-4051-8cf0-6ff976d7771d", "info@poverty-action.org", false, false, false, null, "https://poverty-action.org/sites/default/files/atoms/image/2020/12/17/IPA-Africa-RGB.jpg", "Innovations for Poverty Action", null, null, null, null, false, "83a980a6-63a2-4718-9d4b-5a2a4682e22d", "https://www.poverty-action.org/", false, null, null, "https://www.youtube.com/embed/jmtMf6VJklI" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, "upset" },
                    { 2, null, "worried" },
                    { 3, null, "africa" },
                    { 4, null, "worry" },
                    { 5, null, "diversity" },
                    { 6, null, "homeless" },
                    { 7, null, "homelessness" },
                    { 8, null, "indoors" },
                    { 9, null, "poverty" },
                    { 10, null, "unemployment" },
                    { 11, null, "workless" },
                    { 12, null, "jobsearch" },
                    { 13, null, "hunger" },
                    { 14, null, "poor" },
                    { 15, null, "sadness" },
                    { 16, null, "moneyless" },
                    { 17, null, "outdoors" },
                    { 18, null, "street" },
                    { 19, null, "unemployed" },
                    { 20, null, "beggar" },
                    { 21, null, "beggaring" },
                    { 22, null, "help" },
                    { 23, null, "misfortune" },
                    { 24, null, "hungry" },
                    { 25, null, "abandoned" },
                    { 26, null, "alone" },
                    { 27, null, "dirty" },
                    { 28, null, "grunge" },
                    { 29, null, "lonely" },
                    { 30, null, "outside" },
                    { 31, null, "urban" },
                    { 32, null, "begging" },
                    { 33, null, "indoors" },
                    { 34, null, "lifestyles" },
                    { 35, null, "socialissues" },
                    { 36, null, "dirt" },
                    { 37, null, "mud" },
                    { 38, null, "tents" },
                    { 39, null, "tent" },
                    { 40, null, "unhappy" },
                    { 41, null, "untidy" },
                    { 42, null, "charity" },
                    { 43, null, "donate" },
                    { 44, null, "health" },
                    { 45, null, "hope" },
                    { 46, null, "hopeless" },
                    { 47, null, "humanity" },
                    { 48, null, "justice" },
                    { 49, null, "humanrights" },
                    { 50, null, "endpoverty" },
                    { 51, null, "inequality" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Allow", "DownloadCount", "ImageUrl", "LikeCount", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmw4NDY3ODk0ODMzLWltYWdlLWtwMmVuZmFtLWtwMmY2aGNhLWt6ZWt5OW5lLmpwZw.jpg", 24, "A young Farahi girl stares into the camera at a local returnee and refugee village", "1" },
                    { 2, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9zdGF0aWMvZmlsZXMvd2Vic2l0ZS8yMDIyLTExL2ZsMTQ4MDAzMTE1MDQtaW1hZ2UuanBn.jpg", 24, "A boy with his mother brother in an IDP camp near the town of Jowhar, Somalia", "1" },
                    { 3, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmwzMzM0MjEyNzU4NS1pbWFnZS1rcHFvcjdhay5qcGc.jpg", 24, "Somali woman holds her malnourished child fitted with a nasogastric tube inside a ward dedicated for diarrhea patients at the Banadir hospital in Somalia's capital Mogadishu", "1" },
                    { 4, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvZmw1NzYyNTE5OTE0LWltYWdlLWt1Y2cxdmRqLmpwZw.jpg", 24, "Students at Nyanzwa Primary School in Iringa region, Tanzania", "1" },
                    { 5, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvay0yMDEtZXllLTAwMTIzLmpwZw.jpg", 24, "Unemployed homeless beggar", "1" },
                    { 6, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZnJmaXNoaW5nX3dvbWVuX25lcGFsX3JpdmVyLWltYWdlLWt5Y2gxN2d1LmpwZw.jpg", 24, "Women fishing in tuna industries", "1" },
                    { 7, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsNDg0NDM2MDQxNC1pbWFnZS1rcWFwcDR0eC5qcGc.jpg", 24, "Marines purify water in Africa", "1" },
                    { 8, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9zdGF0aWMvZmlsZXMvd2Vic2l0ZS8yMDIyLTExL2ZsMTI3OTU3MDgyMjMtaW1hZ2UuanBn.jpg", 24, "Ghana students chat with each other", "1" },
                    { 9, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvaW4tbS01MjA3LmpwZw.jpg?s=aQ9OjMGSpUawxXFjZgWZ0K4H6EcDmrXXiAjdX0VTf5E", 24, "Indigenous senior Indian man looking at the camera", "1" },
                    { 10, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvay1tby1rYXpha2hvdXNlLmpwZw.jpg", 24, "Old weathered house with mountain range in the background", "1" },
                    { 11, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmw4NDYwMTQzMjMzLWltYWdlLWtwcW9nNnNiLmpwZw.jpg", 24, "A young Somali girl walks through a market in Merca", "1" },
                    { 12, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmw0Mjg1NjU1NDczLWltYWdlLWtwMmVwMWNjLWt6ZWt5YWk0LmpwZw.jpg", 24, "Children wait in line for a humanitarian meal in Port-au-Prince, Haiti", "1" },
                    { 13, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvay0yMDEtdGVkZHktMDA4OS5qcGc.jpg", 24, "Homeless guy on the street", "1" },
                    { 14, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvay0yMDEtZXllLWFlLTAwODIxLmpwZw.jpg", 24, "Homeless guy sleeping on the street", "1" },
                    { 15, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmwxMTQwMTY4NjcwNC1pbWFnZS1rcHFvbGZtZi1remVtZmM5ZC5qcGc.jpg", 24, "A young Somali girl looks out of a tent at an IDP camp near the town of Jowhar, Somalia", "1" },
                    { 16, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmwxNTM1OTI0NTIwNC1pbWFnZS1rcHFvaXNuNC5qcGc.jpg", 24, "A girl holds her young sister in a camp during a bore hole handing over ceremony in Kismayo, Somalia", "1" },
                    { 17, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA1L2ZsMTUxMDQ0ODUyODMtaW1hZ2Uta3Bxb2R4bnkuanBn.jpg", 24, "Make shift houses in Internal Displaced Camp outside of Beled weyne Capital of Hiran Region, Somalia", "1" },
                    { 18, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvay1jYS1maXNoaW5nYm95MzIuanBn.jpg", 24, "Cambodian boy fishing in the river", "1" },
                    { 19, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA1L2ZsNjg0MDU5OTM5My1pbWFnZS1rcHFvaG4wcC5qcGc.jpg", 24, "A young Somali girl waits inside a tent for free medical check-ups and treatment in the Kaaran district, Somalia", "1" },
                    { 20, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsMzUxNDUyNTM2MTEtaW1hZ2Uta3VkaTM1cGwuanBn.jpg", 24, "A woman and her children wait to receive food at an Internally Displaced Persons camp at Doolow, Gedo region, Somalia", "1" },
                    { 21, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsMTA0MTg5MjQ1NjYtaW1hZ2Uta3Bxb3RtZDQuanBn.jpg", 24, "A woman holds a young child while they wait to enter a free medical clinic in Somalia", "1" },
                    { 22, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmw4NTQzODQxODczLWltYWdlLWtwcW9mc2poLWt6ZWt5OWZiLmpwZw.jpg", 24, "A girl stands in an IDP camp on the outskirts of Belet Weyne, Somalia", "1" },
                    { 23, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmw4NTQzODQwNTQ5LWltYWdlLWtwcW9mdXpnLmpwZw.jpg", 24, "A woman sits in an IDP camp on the outskirts of Belet Weyne, Somalia", "1" },
                    { 24, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvcGQ1OGJhdGNoMS0xOTM1OV8xLmpwZw.jpg", 24, "An infant diagnosed with having a Guinea worm disease (GWD)", "1" },
                    { 25, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsNDUxODgzODMxNC1pbWFnZS1rcWFtNTgxMy5qcGc.jpg", 24, "Afghan children stand next to their father", "1" },
                    { 26, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAzL2ZsMzY3OTUwMjg0Ni1pbWFnZS5qcGc.jpg", 24, "Children Living in a Camp Between Weedpatch and Lamont, Kern County, California", "1" },
                    { 27, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsOTY1Mjg5MTQyNC1pbWFnZS1rcHFvdTN2ay5qcGc.jpg", 24, "A woman waits in the shade of a derelict building to see a doctor at a free medical clinic in Somalia", "1" },
                    { 28, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvay1jYS1maXNoaW5nYm95My1idy5qcGc.jpg", 24, "Cambodian boy by the river", "1" },
                    { 29, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9zdGF0aWMvaW1hZ2Uvd2Vic2l0ZS8yMDIyLTA0L2xyL2ZydW5zcGxhc2gxNTEyNi1pbWFnZS1rejJlNmo5bC5qcGc.jpg", 24, "Cute Asian children smiling at the camera", "1" },
                    { 30, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvay0yMDEtZXllLTAwMDQxLmpwZw.jpg", 24, "Homeless woman", "1" },
                    { 31, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsMzQzOTA1ODg2NDUtaW1hZ2Uta3VkaTNkbGMuanBn.jpg", 24, "Mothers with their children stand in front of their makeshift houses at Maqori Manyow Camp", "1" },
                    { 32, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvcHgxMjk5MzktaW1hZ2Uta3d5cXMwdjcuanBn.jpg", 24, "Homeless beggar", "1" },
                    { 33, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvcHg1NTk1NTQtaW1hZ2Uta3d2dmZoeHEuanBn.jpg", 24, "Free homeless eating rice", "1" },
                    { 34, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA1L2ZsODU0Mzg0MDk3My1pbWFnZS1rcHFvZnE2Yi5qcGc.jpg", 24, "A girl stands in an IDP camp on the outskirts of Belet Weyne, Somalia", "1" },
                    { 35, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsODY1NDczODY2OC1pbWFnZS1rcHFvdmh2Yy5qcGc.jpg", 24, "Mohammed, suffering from Malaria, recovers at a Burundian run clinic in Somalia", "1" },
                    { 36, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmw0Nzc1MTAyMzEyMS1pbWFnZS1rdWY3NzF4ei5qcGc.jpg", 24, "Homesteads within the Howlwadaag Internally Displaced Persons (IDPs) camp in Baidoa, Somalia", "1" },
                    { 37, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmw0MDI1NjYyNzM4Mi1pbWFnZS1rencyYnRkMi5qcGc.jpg", 24, "Musahar children in town, Sauraha, Chitwan District, Nepal", "1" },
                    { 38, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvZmw0OTY3Mjg0MjI1LWltYWdlLWtxYnNyNDV1LmpwZw.jpg", 24, "Pakistanis rush to pick up supplies from Marines", "1" },
                    { 39, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsNDUxODgzODg0Ni1pbWFnZS1rcWFtNWc0ay5qcGc.jpg", 24, "Afghan child sits with her little sister", "1" },
                    { 40, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvbHIvZmw1Mzg0Njk0OTAyLWltYWdlLWtxYW0zbXpoLmpwZw.jpg", 24, "Marines help keep children healthy", "1" },
                    { 41, true, 24, "https://images.rawpixel.com/image_social_landscape/czNmcy1wcml2YXRlL3Jhd3BpeGVsX2ltYWdlcy93ZWJzaXRlX2NvbnRlbnQvZmw1MDgwNjQwMzY3LWltYWdlLWtxYXBveHhoLmpwZw.jpg", 24, "Marines hard at work", "1" },
                    { 42, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsMjU0Nzg0NjkxNDUtaW1hZ2Uta3Bxb241aXguanBn.jpg", 24, "A young boy poses for the camera as Burundian troops, part of the African Union Mission in Somalia", "1" },
                    { 43, true, 24, "https://images.rawpixel.com/image_social_landscape/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA0L2ZsNDk5NDkxNjE4NDctaW1hZ2Uta3VkaTNkcnEuanBn.jpg", 24, "The United Nations has been providing clean water, food and non-food emergency supplies to families displaced by floods at Ceel Jaale IDP camp in Belet Weyne, Somalia", "1" }
                });

            migrationBuilder.InsertData(
                table: "ImageTags",
                columns: new[] { "ImageId", "TagId", "Id" },
                values: new object[,]
                {
                    { 1, 10, 4 },
                    { 1, 13, 5 },
                    { 1, 24, 3 },
                    { 1, 40, 1 },
                    { 1, 48, 2 },
                    { 2, 6, 8 },
                    { 2, 28, 6 },
                    { 2, 36, 9 },
                    { 2, 41, 7 },
                    { 3, 1, 10 },
                    { 3, 4, 13 },
                    { 3, 8, 11 },
                    { 3, 27, 14 },
                    { 3, 29, 15 },
                    { 3, 35, 12 },
                    { 3, 39, 16 },
                    { 4, 19, 17 },
                    { 5, 9, 19 },
                    { 5, 20, 20 },
                    { 5, 43, 18 },
                    { 5, 46, 21 },
                    { 6, 5, 24 },
                    { 6, 12, 26 },
                    { 6, 18, 22 },
                    { 6, 31, 25 },
                    { 6, 33, 27 },
                    { 6, 34, 23 },
                    { 8, 11, 29 },
                    { 8, 23, 30 },
                    { 8, 25, 28 },
                    { 8, 26, 31 },
                    { 9, 16, 34 },
                    { 9, 22, 33 },
                    { 9, 47, 32 },
                    { 10, 37, 35 },
                    { 12, 2, 38 },
                    { 12, 3, 37 },
                    { 12, 7, 36 },
                    { 13, 30, 39 },
                    { 14, 32, 40 },
                    { 15, 42, 41 },
                    { 16, 14, 42 },
                    { 17, 38, 43 },
                    { 17, 44, 44 },
                    { 27, 17, 45 },
                    { 31, 45, 46 },
                    { 35, 21, 47 },
                    { 37, 15, 48 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLikes_UserId",
                table: "ImageLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTags_TagId",
                table: "ImageTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ImageLikes");

            migrationBuilder.DropTable(
                name: "ImageTags");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
