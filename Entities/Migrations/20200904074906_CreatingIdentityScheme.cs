using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class CreatingIdentityScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NationalCode = table.Column<long>(nullable: false),
                    PostalCode = table.Column<long>(nullable: false),
                    ProvinceId = table.Column<long>(nullable: false),
                    CityId = table.Column<long>(nullable: false),
                    ProfilePic = table.Column<string>(nullable: true),
                    BirthDate = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatProduct",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Coding = table.Column<long>(nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    Icon = table.Column<string>(maxLength: 256, nullable: true),
                    URL = table.Column<string>(maxLength: 256, nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CatProduct_CatProduct",
                        column: x => x.PID,
                        principalTable: "CatProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatStatus",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    Color = table.Column<string>(maxLength: 64, nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    ColorCode = table.Column<string>(maxLength: 32, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    EnName = table.Column<string>(maxLength: 64, nullable: true),
                    LocationCode = table.Column<long>(nullable: true),
                    CountryID = table.Column<long>(nullable: true),
                    ProvinceID = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Location_Location1",
                        column: x => x.CountryID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_Location",
                        column: x => x.PID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_Location2",
                        column: x => x.ProvinceID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 512, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parameters_Parameters",
                        column: x => x.PID,
                        principalTable: "Parameters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMeter",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMeter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Offers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferType = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    FromDate = table.Column<long>(nullable: true),
                    ToDate = table.Column<long>(nullable: true),
                    Value = table.Column<double>(nullable: true),
                    OfferCode = table.Column<string>(maxLength: 32, nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offers_OfferType",
                        column: x => x.OfferType,
                        principalTable: "OfferType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatProductParameters",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParametersID = table.Column<long>(nullable: true),
                    CatProductID = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatProductParameters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CatProductParameters_CatProduct",
                        column: x => x.CatProductID,
                        principalTable: "CatProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatProductParameters_Parameters",
                        column: x => x.ParametersID,
                        principalTable: "Parameters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    NextStatusID = table.Column<long>(nullable: true),
                    Color = table.Column<string>(maxLength: 64, nullable: true),
                    StatusTypeID = table.Column<long>(nullable: true),
                    CatStatusID = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Status_CatStatus",
                        column: x => x.CatStatusID,
                        principalTable: "CatStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Status_StatusType",
                        column: x => x.StatusTypeID,
                        principalTable: "StatusType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    SystemID = table.Column<long>(nullable: true),
                    CatStatusID = table.Column<long>(nullable: true),
                    TableCode = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tables_CatStatus",
                        column: x => x.CatStatusID,
                        principalTable: "CatStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tables_Systems",
                        column: x => x.SystemID,
                        principalTable: "Systems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Fname = table.Column<string>(maxLength: 32, nullable: true),
                    MelliCode = table.Column<long>(nullable: true),
                    Mobile = table.Column<long>(nullable: true),
                    BDate = table.Column<long>(nullable: true),
                    Email = table.Column<string>(maxLength: 64, nullable: true),
                    ProfileImageURL = table.Column<string>(maxLength: 512, nullable: true),
                    ProfileImageHURL = table.Column<string>(maxLength: 514, nullable: true),
                    LocationID = table.Column<long>(nullable: true),
                    PostalCode = table.Column<long>(nullable: true),
                    Address = table.Column<string>(maxLength: 1024, nullable: true),
                    FinalStatusID = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customer_Status",
                        column: x => x.FinalStatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Location",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Fname = table.Column<string>(maxLength: 32, nullable: true),
                    MelliCode = table.Column<long>(nullable: true),
                    Mobile = table.Column<long>(nullable: true),
                    BDate = table.Column<long>(nullable: true),
                    Email = table.Column<string>(maxLength: 64, nullable: true),
                    ProfileImageURL = table.Column<string>(maxLength: 512, nullable: true),
                    ProfileImageHURL = table.Column<string>(maxLength: 514, nullable: true),
                    LocationID = table.Column<long>(nullable: true),
                    PostalCode = table.Column<long>(nullable: true),
                    Address = table.Column<string>(maxLength: 1024, nullable: true),
                    FinalStatusID = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seller_Status",
                        column: x => x.FinalStatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerActivation",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<long>(nullable: true),
                    Mobile = table.Column<long>(nullable: true),
                    Email = table.Column<long>(nullable: true),
                    SendDate = table.Column<long>(nullable: true),
                    Code = table.Column<long>(nullable: true),
                    FaileCount = table.Column<int>(nullable: true),
                    Status = table.Column<byte>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerActivation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerActivation_Customer",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOffer",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferID = table.Column<long>(nullable: true),
                    CustomerID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    FromDate = table.Column<long>(nullable: true),
                    ToDate = table.Column<long>(nullable: true),
                    Value = table.Column<double>(nullable: true),
                    OfferCode = table.Column<string>(maxLength: 32, nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOffer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerOffer_Customer",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOffer_Offers",
                        column: x => x.OfferID,
                        principalTable: "Offers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerID = table.Column<long>(nullable: true),
                    CatProductID = table.Column<long>(nullable: true),
                    ProductMeterID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    EnName = table.Column<string>(maxLength: 256, nullable: true),
                    Rkey = table.Column<long>(nullable: true),
                    Coding = table.Column<long>(nullable: true),
                    Price = table.Column<long>(nullable: true),
                    FinalStatusID = table.Column<long>(nullable: true),
                    FirstCount = table.Column<long>(nullable: true),
                    Count = table.Column<long>(nullable: true),
                    CoverImageURL = table.Column<string>(maxLength: 512, nullable: true),
                    CoverImageHURL = table.Column<string>(maxLength: 514, nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_CatProduct",
                        column: x => x.CatProductID,
                        principalTable: "CatProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Status",
                        column: x => x.FinalStatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductMeter",
                        column: x => x.ProductMeterID,
                        principalTable: "ProductMeter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Seller",
                        column: x => x.SellerID,
                        principalTable: "Seller",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellerCatProduct",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerID = table.Column<long>(nullable: true),
                    CatProductID = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerCatProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SellerCatProduct_CatProduct",
                        column: x => x.CatProductID,
                        principalTable: "CatProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellerCatProduct_Seller",
                        column: x => x.SellerID,
                        principalTable: "Seller",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomerComments",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<long>(nullable: true),
                    CustomerID = table.Column<long>(nullable: true),
                    CommentDate = table.Column<long>(nullable: true),
                    CommentDesc = table.Column<long>(nullable: true),
                    LikeCount = table.Column<int>(nullable: true),
                    DislikeCount = table.Column<int>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomerComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductCustomerComments_Customer",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductUserComments_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomerRate",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<long>(nullable: true),
                    ProductID = table.Column<long>(nullable: true),
                    Rate = table.Column<int>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomerRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductCustomerRate_Customer",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductUserRate_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<long>(nullable: true),
                    ImageURL = table.Column<string>(maxLength: 512, nullable: true),
                    ImageHURL = table.Column<string>(maxLength: 514, nullable: true),
                    ColorID = table.Column<long>(nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Color",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOffer",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<long>(nullable: true),
                    OfferID = table.Column<long>(nullable: true),
                    FromDate = table.Column<long>(nullable: true),
                    ToDate = table.Column<long>(nullable: true),
                    Value = table.Column<double>(nullable: true),
                    OfferCode = table.Column<string>(maxLength: 32, nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOffer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductOffer_Offers",
                        column: x => x.OfferID,
                        principalTable: "Offers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOffer_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductParameters",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<long>(nullable: true),
                    CatProductParameters = table.Column<long>(nullable: true),
                    Value = table.Column<string>(maxLength: 512, nullable: true),
                    CUserID = table.Column<long>(nullable: true),
                    CDate = table.Column<long>(nullable: true),
                    DUserID = table.Column<long>(nullable: true),
                    DDate = table.Column<long>(nullable: true),
                    MUserID = table.Column<long>(nullable: true),
                    MDate = table.Column<long>(nullable: true),
                    DaUserID = table.Column<long>(nullable: true),
                    DaDate = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductParameters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductParameters_CatProductParameters",
                        column: x => x.CatProductParameters,
                        principalTable: "CatProductParameters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductParameters_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_CatProduct_PID",
                table: "CatProduct",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_CatProductParameters_CatProductID",
                table: "CatProductParameters",
                column: "CatProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CatProductParameters_ParametersID",
                table: "CatProductParameters",
                column: "ParametersID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FinalStatusID",
                table: "Customer",
                column: "FinalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LocationID",
                table: "Customer",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivation_CustomerID",
                table: "CustomerActivation",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOffer_CustomerID",
                table: "CustomerOffer",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOffer_OfferID",
                table: "CustomerOffer",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CountryID",
                table: "Location",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_PID",
                table: "Location",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ProvinceID",
                table: "Location",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferType",
                table: "Offers",
                column: "OfferType");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_PID",
                table: "Parameters",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CatProductID",
                table: "Product",
                column: "CatProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FinalStatusID",
                table: "Product",
                column: "FinalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductMeterID",
                table: "Product",
                column: "ProductMeterID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellerID",
                table: "Product",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerComments_CustomerID",
                table: "ProductCustomerComments",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerComments_ProductID",
                table: "ProductCustomerComments",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerRate_CustomerID",
                table: "ProductCustomerRate",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerRate_ProductID",
                table: "ProductCustomerRate",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ColorID",
                table: "ProductImage",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductID",
                table: "ProductImage",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOffer_OfferID",
                table: "ProductOffer",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOffer_ProductID",
                table: "ProductOffer",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParameters_CatProductParameters",
                table: "ProductParameters",
                column: "CatProductParameters");

            migrationBuilder.CreateIndex(
                name: "IX_ProductParameters_ProductID",
                table: "ProductParameters",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_FinalStatusID",
                table: "Seller",
                column: "FinalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerCatProduct_CatProductID",
                table: "SellerCatProduct",
                column: "CatProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerCatProduct_SellerID",
                table: "SellerCatProduct",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Status_CatStatusID",
                table: "Status",
                column: "CatStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Status_StatusTypeID",
                table: "Status",
                column: "StatusTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_CatStatusID",
                table: "Tables",
                column: "CatStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_SystemID",
                table: "Tables",
                column: "SystemID");
        }

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
                name: "CustomerActivation");

            migrationBuilder.DropTable(
                name: "CustomerOffer");

            migrationBuilder.DropTable(
                name: "ProductCustomerComments");

            migrationBuilder.DropTable(
                name: "ProductCustomerRate");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ProductOffer");

            migrationBuilder.DropTable(
                name: "ProductParameters");

            migrationBuilder.DropTable(
                name: "SellerCatProduct");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "CatProductParameters");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "OfferType");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "CatProduct");

            migrationBuilder.DropTable(
                name: "ProductMeter");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "CatStatus");

            migrationBuilder.DropTable(
                name: "StatusType");
        }
    }
}
