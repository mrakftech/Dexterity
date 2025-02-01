using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Setting");

            migrationBuilder.EnsureSchema(
                name: "Consultation");

            migrationBuilder.EnsureSchema(
                name: "PM");

            migrationBuilder.EnsureSchema(
                name: "Scheduler");

            migrationBuilder.EnsureSchema(
                name: "Messaging");

            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertCategories",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentCancellationReasons",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentCancellationReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSlots",
                schema: "Scheduler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTypes",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomForms",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BasedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentCategories",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentCategories_DocumentCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "Setting",
                        principalTable: "DocumentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmFam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenericName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackSize = table.Column<int>(type: "int", nullable: false),
                    PackSizeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackSizeUnits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteAutUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngredientCostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxRrp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GasCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoisonClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAuthortext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UomSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugCats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warnings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingrd1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingrd2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atc1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atc2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dentist = table.Column<bool>(type: "bit", nullable: false),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupHead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeathCodes",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chapter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeathCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlsoKnownAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthBoard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImmunisationPrograms",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefualt = table.Column<bool>(type: "bit", nullable: false),
                    IsChildhood = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunisationPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestigationGroups",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investigations",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestigationSelectionList",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationSelectionList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LetterTypes",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergies",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllergyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientDrugAllergies",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrugType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugAllergyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDrugAllergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PomrGroups",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomrGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefualt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shots",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IntervalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntervalMin = table.Column<int>(type: "int", nullable: false),
                    IntervalMax = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimForm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SketchCategories",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SketchCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsTemplates",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicSites",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicSites_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormTemplates",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormTemplates_CustomForms_CustomFormId",
                        column: x => x.CustomFormId,
                        principalSchema: "Setting",
                        principalTable: "CustomForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManfactureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchCount = table.Column<int>(type: "int", nullable: false),
                    Remaining = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BatchCompleteWhenZero = table.Column<bool>(type: "bit", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalSchema: "Setting",
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteTemplates",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HealthCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteTemplates_HeathCodes_HealthCodeId",
                        column: x => x.HealthCodeId,
                        principalSchema: "Setting",
                        principalTable: "HeathCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramCourses",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImmunisationProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Setting",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramCourses_ImmunisationPrograms_ImmunisationProgramId",
                        column: x => x.ImmunisationProgramId,
                        principalSchema: "Setting",
                        principalTable: "ImmunisationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedInvestigationGroups",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestigationGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedInvestigationGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedInvestigationGroups_InvestigationGroups_InvestigationGroupId",
                        column: x => x.InvestigationGroupId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedInvestigationGroups_Investigations_InvestigationId",
                        column: x => x.InvestigationId,
                        principalSchema: "Setting",
                        principalTable: "Investigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestigationDetails",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMaindatory = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbsoluteMinimum = table.Column<double>(type: "float", nullable: false),
                    AbsoluteMaximum = table.Column<double>(type: "float", nullable: false),
                    NormalMinimum = table.Column<double>(type: "float", nullable: false),
                    NormalMaximum = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestigationSelectionListId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationDetails_InvestigationSelectionList_InvestigationSelectionListId",
                        column: x => x.InvestigationSelectionListId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationSelectionList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvestigationDetails_Investigations_InvestigationId",
                        column: x => x.InvestigationId,
                        principalSchema: "Setting",
                        principalTable: "Investigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestigationSelectionValues",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationSelectionListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationSelectionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationSelectionValues_InvestigationSelectionList_InvestigationSelectionListId",
                        column: x => x.InvestigationSelectionListId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationSelectionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LetterTemplates",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TemplateFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetterTemplates_LetterTypes_LetterTypeId",
                        column: x => x.LetterTypeId,
                        principalSchema: "Setting",
                        principalTable: "LetterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allowed = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mcn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUpdatePassword = table.Column<bool>(type: "bit", nullable: false),
                    IsForceReset = table.Column<bool>(type: "bit", nullable: false),
                    ResetPasswordAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    StartHour = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndHour = table.Column<TimeSpan>(type: "time", nullable: false),
                    WorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseShots",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseShots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseShots_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Setting",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseShots_Shots_ShotId",
                        column: x => x.ShotId,
                        principalSchema: "Setting",
                        principalTable: "Shots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sketches",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SketchCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sketches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sketches_SketchCategories_SketchCategoryId",
                        column: x => x.SketchCategoryId,
                        principalSchema: "Setting",
                        principalTable: "SketchCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShotBatches",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShotBatches_Batches_BatchId",
                        column: x => x.BatchId,
                        principalSchema: "Setting",
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShotBatches_Shots_ShotId",
                        column: x => x.ShotId,
                        principalSchema: "Setting",
                        principalTable: "Shots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                schema: "Messaging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlagRecords",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentPatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReassignedToPatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FlaggedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResolvedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlagRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlagRecords_Users_FlaggedById",
                        column: x => x.FlaggedById,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlagRecords_Users_ResolvedById",
                        column: x => x.ResolvedById,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Letters",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LetterDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LetterTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Letters_LetterTemplates_LetterTemplateId",
                        column: x => x.LetterTemplateId,
                        principalSchema: "Setting",
                        principalTable: "LetterTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Letters_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisRegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisRegistrationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormerFamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherMaidenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispensingStatus = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalRecordNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NkaFlag = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalCardDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugPaymentSchemeDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateHealthInsuranceDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ppsn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IhiNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyMedicalScheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfEnrollment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClinics",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClinics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClinics_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClinics_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LetterReplies",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationLetterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetterReplies_Letters_ConsultationLetterId",
                        column: x => x.ConsultationLetterId,
                        principalSchema: "Consultation",
                        principalTable: "Letters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                schema: "Scheduler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllDay = table.Column<bool>(type: "bit", nullable: false),
                    IsSeries = table.Column<bool>(type: "bit", nullable: false),
                    CustomRecurrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecurrenceRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecurrenceException = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecurrenceID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CancelReasonId = table.Column<int>(type: "int", nullable: false),
                    AppointmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    ClinicSiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                        column: x => x.AppointmentTypeId,
                        principalSchema: "Setting",
                        principalTable: "AppointmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_ClinicSites_ClinicSiteId",
                        column: x => x.ClinicSiteId,
                        principalSchema: "Setting",
                        principalTable: "ClinicSites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaselineDetails",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Bmi = table.Column<float>(type: "real", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbdominalCircumference = table.Column<float>(type: "real", nullable: false),
                    SmokerStatus = table.Column<bool>(type: "bit", nullable: false),
                    SmokePerDay = table.Column<int>(type: "int", nullable: false),
                    SmokingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExSmokerYears = table.Column<int>(type: "int", nullable: false),
                    DrinkingStatus = table.Column<bool>(type: "bit", nullable: false),
                    WeeklyAlcohol = table.Column<int>(type: "int", nullable: false),
                    DrinkingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FamilyCvdHistory = table.Column<bool>(type: "bit", nullable: false),
                    Lvh = table.Column<bool>(type: "bit", nullable: false),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    Cholesterol = table.Column<float>(type: "real", nullable: false),
                    Ldl = table.Column<float>(type: "real", nullable: false),
                    Hdl = table.Column<float>(type: "real", nullable: false),
                    Pulse = table.Column<int>(type: "int", nullable: false),
                    PulseRhythm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    PeakFlow = table.Column<int>(type: "int", nullable: false),
                    RespiratoryRate = table.Column<int>(type: "int", nullable: false),
                    CurrentOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtanceMisuse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaselineDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaselineDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaselineDetails_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pomr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicSiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_ClinicSites_ClinicSiteId",
                        column: x => x.ClinicSiteId,
                        principalSchema: "Setting",
                        principalTable: "ClinicSites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorVisitCards",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DvNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DvReviewDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DvReviewNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DvDistanceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorVisitCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorVisitCards_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipToPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCarer = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupPatients",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationshipToPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupPatients_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "PM",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImmunisationSchedule",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImmunisationProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunisationSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmunisationSchedule_ImmunisationPrograms_ImmunisationProgramId",
                        column: x => x.ImmunisationProgramId,
                        principalSchema: "Setting",
                        principalTable: "ImmunisationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImmunisationSchedule_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPastHistory = table.Column<bool>(type: "bit", nullable: false),
                    IsFamilyHistory = table.Column<bool>(type: "bit", nullable: false),
                    IsActiveCondition = table.Column<bool>(type: "bit", nullable: false),
                    IsScoialHistory = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_HeathCodes_HealthCodeId",
                        column: x => x.HealthCodeId,
                        principalSchema: "Setting",
                        principalTable: "HeathCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAccounts",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAccounts_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAlerts",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAlerts_AlertCategories_AlertCategoryId",
                        column: x => x.AlertCategoryId,
                        principalSchema: "PM",
                        principalTable: "AlertCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAlerts_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientContacts",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientContacts_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientCustomForms",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCustomForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientCustomForms_FormTemplates_FormTemplateId",
                        column: x => x.FormTemplateId,
                        principalSchema: "Setting",
                        principalTable: "FormTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientCustomForms_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientCustomForms_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientHospitals",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHospitals_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "PM",
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientHospitals_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientInvestigations",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAbnormal = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInvestigations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientInvestigations_Investigations_InvestigationId",
                        column: x => x.InvestigationId,
                        principalSchema: "Setting",
                        principalTable: "Investigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientInvestigations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientInvestigations_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientOccupations",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientOccupations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientOccupations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientSketches",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sketch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSketches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientSketches_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientSmsHistories",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSmsHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientSmsHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenericOnly = table.Column<bool>(type: "bit", nullable: false),
                    Instruction1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instruction4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Initiated = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsInReview = table.Column<bool>(type: "bit", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalSchema: "Setting",
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Users_AddedById",
                        column: x => x.AddedById,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedHcps",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedHcps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedHcps_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemindDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminders_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reminders_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedDocuments",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachedFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedDocuments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                schema: "Messaging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTasks_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTasks_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_AssignedById",
                        column: x => x.AssignedById,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaitingAppointments",
                schema: "Scheduler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingAppointments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "Scheduler",
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaitingAppointments_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "Setting",
                        principalTable: "Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WaitingAppointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdministerShots",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GivenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Side = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGiven = table.Column<bool>(type: "bit", nullable: false),
                    IsDue = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsFirstShot = table.Column<bool>(type: "bit", nullable: false),
                    HcpId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImmunisationScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShotBatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministerShots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministerShots_ImmunisationSchedule_ImmunisationScheduleId",
                        column: x => x.ImmunisationScheduleId,
                        principalSchema: "Consultation",
                        principalTable: "ImmunisationSchedule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdministerShots_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "PM",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministerShots_ShotBatches_ShotBatchId",
                        column: x => x.ShotBatchId,
                        principalSchema: "Setting",
                        principalTable: "ShotBatches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdministerShots_Users_HcpId",
                        column: x => x.HcpId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientTransactions",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrinted = table.Column<bool>(type: "bit", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    PatientAccountType = table.Column<int>(type: "int", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientTransactions_PatientAccounts_PatientAccountId",
                        column: x => x.PatientAccountId,
                        principalSchema: "PM",
                        principalTable: "PatientAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestigationAudits",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HcpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientInvestigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationAudits_PatientInvestigations_PatientInvestigationId",
                        column: x => x.PatientInvestigationId,
                        principalSchema: "Consultation",
                        principalTable: "PatientInvestigations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvestigationResults",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PatientInvestigationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationResults_InvestigationDetails_InvestigationDetailId",
                        column: x => x.InvestigationDetailId,
                        principalSchema: "Setting",
                        principalTable: "InvestigationDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvestigationResults_PatientInvestigations_PatientInvestigationId",
                        column: x => x.PatientInvestigationId,
                        principalSchema: "Consultation",
                        principalTable: "PatientInvestigations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                schema: "Consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Side = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministerShotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_AdministerShots_AdministerShotId",
                        column: x => x.AdministerShotId,
                        principalSchema: "Consultation",
                        principalTable: "AdministerShots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Setting",
                table: "HeathCodes",
                columns: new[] { "Id", "Chapter", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "General and Unspecified", "A01", "Pain general/multiple sites" },
                    { 2, "General and Unspecified", "A02", "Chills" },
                    { 3, "General and Unspecified", "A03", "Fever" },
                    { 4, "General and Unspecified", "A04", "Weakness/tiredness general" },
                    { 5, "General and Unspecified", "A05", "Feeling ill" },
                    { 6, "General and Unspecified", "A06", "Fainting/syncope" },
                    { 7, "General and Unspecified", "A07", "Coma" },
                    { 8, "General and Unspecified", "A08", "Swelling" },
                    { 9, "General and Unspecified", "A09", "Sweating problem" },
                    { 10, "General and Unspecified", "A10", "Bleeding/haemorrhage NOS" },
                    { 11, "General and Unspecified", "A11", "Chest pain NOS" },
                    { 12, "General and Unspecified", "A13", "Concern/fear medical treatment" },
                    { 13, "General and Unspecified", "A16", "Irritable infant" },
                    { 14, "General and Unspecified", "A18", "Concern about appearance" },
                    { 15, "General and Unspecified", "A20", "Euthanasia request/discussion" },
                    { 16, "General and Unspecified", "A21", "Risk factor for malignancy" },
                    { 17, "General and Unspecified", "A23", "Risk factor NOS" },
                    { 18, "General and Unspecified", "A25", "Fear of death/dying" },
                    { 19, "General and Unspecified", "A26", "Fear of cancer NOS" },
                    { 20, "General and Unspecified", "A27", "Fear of other disease NOS" },
                    { 21, "General and Unspecified", "A28", "Limited function/disability NOS" },
                    { 22, "General and Unspecified", "A29", "General symptom/complaint other" },
                    { 23, "General and Unspecified", "A70", "Tuberculosis" },
                    { 24, "General and Unspecified", "A71", "Measles" },
                    { 25, "General and Unspecified", "A72", "Chickenpox" },
                    { 26, "General and Unspecified", "A73", "Malaria" },
                    { 27, "General and Unspecified", "A74", "Rubella" },
                    { 28, "General and Unspecified", "A75", "Infectious mononucleosis" },
                    { 29, "General and Unspecified", "A76", "Viral exanthem other" },
                    { 30, "General and Unspecified", "A77", "Viral disease other/NOS" },
                    { 31, "General and Unspecified", "A78", "Infectious disease other/NOS" },
                    { 32, "General and Unspecified", "A79", "Malignancy NOS" },
                    { 33, "General and Unspecified", "A80", "Trauma/injury NOS" },
                    { 34, "General and Unspecified", "A81", "Multiple trauma/injuries" },
                    { 35, "General and Unspecified", "A82", "Secondary effect of trauma" },
                    { 36, "General and Unspecified", "A84", "Poisoning by medical agent" },
                    { 37, "General and Unspecified", "A85", "Adverse effect medical agent" },
                    { 38, "General and Unspecified", "A86", "Toxic effect non-medicinal substance" },
                    { 39, "General and Unspecified", "A87", "Complication of medical treatment" },
                    { 40, "General and Unspecified", "A88", "Adverse effect physical factor" },
                    { 41, "General and Unspecified", "A89", "Effect prosthetic device" },
                    { 42, "General and Unspecified", "A90", "Congenital anomaly OS/multiple" },
                    { 43, "General and Unspecified", "A91", "Abnormal result investigation NOS" },
                    { 44, "General and Unspecified", "A92", "Allergy/allergic reaction NOS" },
                    { 45, "General and Unspecified", "A93", "Premature newborn" },
                    { 46, "General and Unspecified", "A94", "Perinatal morbidity other" },
                    { 47, "General and Unspecified", "A95", "Perinatal mortality" },
                    { 48, "General and Unspecified", "A96", "Death" },
                    { 49, "General and Unspecified", "A97", "No disease" },
                    { 50, "General and Unspecified", "A98", "Health maintenance/prevention" },
                    { 51, "General and Unspecified", "A99", "General disease NOS" },
                    { 55, "Respiratory", "R01", "Pain respiratory system" },
                    { 56, "Respiratory", "R02", "Shortness of breath/dyspnoea" },
                    { 57, "Respiratory", "R03", "Wheezing" },
                    { 58, "Respiratory", "R04", "Breathing problem, other" },
                    { 59, "Respiratory", "R05", "Cough" },
                    { 60, "Respiratory", "R06", "Nose bleed/epistaxis" },
                    { 61, "Respiratory", "R07", "Sneezing/nasal congestion" },
                    { 62, "Respiratory", "R08", "Nose symptom/complaint other" },
                    { 63, "Respiratory", "R09", "Sinus symptom/complaint" },
                    { 64, "Respiratory", "R21", "Throat symptom/complaint" },
                    { 65, "Respiratory", "R23", "Voice symptom/complaint" },
                    { 66, "Respiratory", "R24", "Haemoptysis" },
                    { 67, "Respiratory", "R25", "Sputum/phlegm abnormal" },
                    { 68, "Respiratory", "R26", "Fear of cancer respiratory system" },
                    { 69, "Respiratory", "R27", "Fear of respiratory disease, other" },
                    { 70, "Respiratory", "R28", "Limited function/disability (r)" },
                    { 71, "Respiratory", "R29", "Respiratory symptom/complaint oth." },
                    { 72, "Respiratory", "R71", "Whooping cough" },
                    { 73, "Respiratory", "R72", "Strep throat" },
                    { 74, "Respiratory", "R73", "Boil/abscess nose" },
                    { 75, "Respiratory", "R74", "Upper respiratory infection acute" },
                    { 76, "Respiratory", "R75", "Sinusitis acute/chronic" },
                    { 77, "Respiratory", "R76", "Tonsillitis acute" },
                    { 78, "Respiratory", "R77", "Laryngitis/tracheitis acute" },
                    { 79, "Respiratory", "R78", "Acute bronchitis/bronchiolitis" },
                    { 80, "Respiratory", "R79", "Chronic bronchitis" },
                    { 81, "Respiratory", "R80", "Influenza" },
                    { 82, "Respiratory", "R81", "Pneumonia" },
                    { 83, "Respiratory", "R82", "Pleurisy/pleural effusion" },
                    { 84, "Respiratory", "R83", "Respiratory infection other" },
                    { 85, "Respiratory", "R84", "Malignant neoplasm bronchus/lung" },
                    { 86, "Respiratory", "R85", "Malignant neoplasm respiratory, other" },
                    { 87, "Respiratory", "R86", "Benign neoplasm respiratory" },
                    { 88, "Respiratory", "R87", "Foreign body nose/larynx/bronch" },
                    { 89, "Respiratory", "R88", "Injury respiratory other" },
                    { 90, "Respiratory", "R89", "Congenital anomaly respiratory" },
                    { 91, "Respiratory", "R90", "Hypertrophy tonsils/adenoids" },
                    { 92, "Respiratory", "R92", "Neoplasm respiratory unspecified" },
                    { 93, "Respiratory", "R95", "Chronic obstructive pulmonary dis" },
                    { 94, "Respiratory", "R96", "Asthma" },
                    { 95, "Respiratory", "R97", "Allergic rhinitis" },
                    { 96, "Respiratory", "R98", "Hyperventilation syndrome" },
                    { 97, "Respiratory", "R99", "Respiratory disease other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministerShots_HcpId",
                schema: "Consultation",
                table: "AdministerShots",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministerShots_ImmunisationScheduleId",
                schema: "Consultation",
                table: "AdministerShots",
                column: "ImmunisationScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministerShots_PatientId",
                schema: "Consultation",
                table: "AdministerShots",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministerShots_ShotBatchId",
                schema: "Consultation",
                table: "AdministerShots",
                column: "ShotBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                schema: "Scheduler",
                table: "Appointments",
                column: "AppointmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicId",
                schema: "Scheduler",
                table: "Appointments",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicSiteId",
                schema: "Scheduler",
                table: "Appointments",
                column: "ClinicSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_HcpId",
                schema: "Scheduler",
                table: "Appointments",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                schema: "Scheduler",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedInvestigationGroups_InvestigationGroupId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                column: "InvestigationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedInvestigationGroups_InvestigationId",
                schema: "Setting",
                table: "AssignedInvestigationGroups",
                column: "InvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_BaselineDetails_HcpId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_BaselineDetails_PatientId",
                schema: "Consultation",
                table: "BaselineDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_DrugId",
                schema: "Setting",
                table: "Batches",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_FromUserId",
                schema: "Messaging",
                table: "ChatMessages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ToUserId",
                schema: "Messaging",
                table: "ChatMessages",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicSites_ClinicId",
                schema: "Setting",
                table: "ClinicSites",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseShots_CourseId",
                schema: "Setting",
                table: "CourseShots",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseShots_ShotId",
                schema: "Setting",
                table: "CourseShots",
                column: "ShotId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ClinicSiteId",
                schema: "Consultation",
                table: "Details",
                column: "ClinicSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_HcpId",
                schema: "Consultation",
                table: "Details",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_PatientId",
                schema: "Consultation",
                table: "Details",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisitCards_PatientId",
                schema: "PM",
                table: "DoctorVisitCards",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentCategories_ParentCategoryId",
                schema: "Setting",
                table: "DocumentCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_PatientId",
                schema: "PM",
                table: "FamilyMembers",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FlagRecords_FlaggedById",
                schema: "Common",
                table: "FlagRecords",
                column: "FlaggedById");

            migrationBuilder.CreateIndex(
                name: "IX_FlagRecords_ResolvedById",
                schema: "Common",
                table: "FlagRecords",
                column: "ResolvedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormTemplates_CustomFormId",
                schema: "Setting",
                table: "FormTemplates",
                column: "CustomFormId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPatients_GroupId",
                schema: "PM",
                table: "GroupPatients",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPatients_PatientId",
                schema: "PM",
                table: "GroupPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunisationSchedule_ImmunisationProgramId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "ImmunisationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunisationSchedule_PatientId",
                schema: "Consultation",
                table: "ImmunisationSchedule",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationAudits_PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationAudits",
                column: "PatientInvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationDetails_InvestigationId",
                schema: "Setting",
                table: "InvestigationDetails",
                column: "InvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationDetails_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationDetails",
                column: "InvestigationSelectionListId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationResults_InvestigationDetailId",
                schema: "Consultation",
                table: "InvestigationResults",
                column: "InvestigationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationResults_PatientInvestigationId",
                schema: "Consultation",
                table: "InvestigationResults",
                column: "PatientInvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationSelectionValues_InvestigationSelectionListId",
                schema: "Setting",
                table: "InvestigationSelectionValues",
                column: "InvestigationSelectionListId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterReplies_ConsultationLetterId",
                schema: "Consultation",
                table: "LetterReplies",
                column: "ConsultationLetterId");

            migrationBuilder.CreateIndex(
                name: "IX_Letters_HcpId",
                schema: "Consultation",
                table: "Letters",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_Letters_LetterTemplateId",
                schema: "Consultation",
                table: "Letters",
                column: "LetterTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterTemplates_LetterTypeId",
                schema: "Setting",
                table: "LetterTemplates",
                column: "LetterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_HcpId",
                schema: "Consultation",
                table: "Notes",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_HealthCodeId",
                schema: "Consultation",
                table: "Notes",
                column: "HealthCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PatientId",
                schema: "Consultation",
                table: "Notes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteTemplates_HealthCodeId",
                schema: "Setting",
                table: "NoteTemplates",
                column: "HealthCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccounts_PatientId",
                schema: "PM",
                table: "PatientAccounts",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientAlerts_AlertCategoryId",
                schema: "PM",
                table: "PatientAlerts",
                column: "AlertCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAlerts_PatientId",
                schema: "PM",
                table: "PatientAlerts",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientContacts_PatientId",
                schema: "PM",
                table: "PatientContacts",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCustomForms_FormTemplateId",
                schema: "Consultation",
                table: "PatientCustomForms",
                column: "FormTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCustomForms_HcpId",
                schema: "Consultation",
                table: "PatientCustomForms",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCustomForms_PatientId",
                schema: "Consultation",
                table: "PatientCustomForms",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHospitals_HospitalId",
                schema: "PM",
                table: "PatientHospitals",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHospitals_PatientId",
                schema: "PM",
                table: "PatientHospitals",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInvestigations_HcpId",
                schema: "Consultation",
                table: "PatientInvestigations",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInvestigations_InvestigationId",
                schema: "Consultation",
                table: "PatientInvestigations",
                column: "InvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInvestigations_PatientId",
                schema: "Consultation",
                table: "PatientInvestigations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOccupations_PatientId",
                schema: "PM",
                table: "PatientOccupations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ClinicId",
                schema: "PM",
                table: "Patients",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HcpId",
                schema: "PM",
                table: "Patients",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSketches_PatientId",
                schema: "Consultation",
                table: "PatientSketches",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSmsHistories_PatientId",
                schema: "PM",
                table: "PatientSmsHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_PatientAccountId",
                schema: "PM",
                table: "PatientTransactions",
                column: "PatientAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                schema: "Identity",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AddedById",
                schema: "Consultation",
                table: "Prescriptions",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DrugId",
                schema: "Consultation",
                table: "Prescriptions",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                schema: "Consultation",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramCourses_CourseId",
                schema: "Setting",
                table: "ProgramCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramCourses_ImmunisationProgramId",
                schema: "Setting",
                table: "ProgramCourses",
                column: "ImmunisationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_AdministerShotId",
                schema: "Consultation",
                table: "Reactions",
                column: "AdministerShotId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedHcps_PatientId",
                schema: "PM",
                table: "RelatedHcps",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_HcpId",
                schema: "Consultation",
                table: "Reminders",
                column: "HcpId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_PatientId",
                schema: "Consultation",
                table: "Reminders",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedDocuments_PatientId",
                schema: "Consultation",
                table: "ScannedDocuments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotBatches_BatchId",
                schema: "Setting",
                table: "ShotBatches",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotBatches_ShotId",
                schema: "Setting",
                table: "ShotBatches",
                column: "ShotId");

            migrationBuilder.CreateIndex(
                name: "IX_Sketches_SketchCategoryId",
                schema: "Setting",
                table: "Sketches",
                column: "SketchCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClinics_ClinicId",
                schema: "Identity",
                table: "UserClinics",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClinics_UserId",
                schema: "Identity",
                table: "UserClinics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "Identity",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AssignedById",
                schema: "Messaging",
                table: "UserTasks",
                column: "AssignedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_ClinicId",
                schema: "Messaging",
                table: "UserTasks",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_PatientId",
                schema: "Messaging",
                table: "UserTasks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserId",
                schema: "Messaging",
                table: "UserTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingAppointments_AppointmentId",
                schema: "Scheduler",
                table: "WaitingAppointments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingAppointments_ClinicId",
                schema: "Scheduler",
                table: "WaitingAppointments",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingAppointments_PatientId",
                schema: "Scheduler",
                table: "WaitingAppointments",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTypes",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "AppointmentCancellationReasons",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "AppointmentSlots",
                schema: "Scheduler");

            migrationBuilder.DropTable(
                name: "AssignedInvestigationGroups",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "BaselineDetails",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "ChatMessages",
                schema: "Messaging");

            migrationBuilder.DropTable(
                name: "CourseShots",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Details",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "DoctorVisitCards",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "DocumentCategories",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "EmailTemplates",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "FamilyMembers",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "FlagRecords",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "GroupPatients",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "InvestigationAudits",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "InvestigationResults",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "InvestigationSelectionValues",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "LetterReplies",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "Notes",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "NoteTemplates",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "PatientAlerts",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "PatientAllergies",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "PatientContacts",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "PatientCustomForms",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "PatientDrugAllergies",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "PatientHospitals",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "PatientOccupations",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "PatientSketches",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "PatientSmsHistories",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "PatientTransactions",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PomrGroups",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Prescriptions",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "ProgramCourses",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Reactions",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "RelatedHcps",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "Reminders",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "ScannedDocuments",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "Sketches",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "SmsTemplates",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "UserClinics",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTasks",
                schema: "Messaging");

            migrationBuilder.DropTable(
                name: "WaitingAppointments",
                schema: "Scheduler");

            migrationBuilder.DropTable(
                name: "InvestigationGroups",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "InvestigationDetails",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "PatientInvestigations",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "Letters",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "HeathCodes",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "AlertCategories",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "FormTemplates",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Hospitals",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "PatientAccounts",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "AdministerShots",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "SketchCategories",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Appointments",
                schema: "Scheduler");

            migrationBuilder.DropTable(
                name: "InvestigationSelectionList",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Investigations",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "LetterTemplates",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "CustomForms",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "ImmunisationSchedule",
                schema: "Consultation");

            migrationBuilder.DropTable(
                name: "ShotBatches",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "AppointmentTypes",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "ClinicSites",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "LetterTypes",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "ImmunisationPrograms",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "PM");

            migrationBuilder.DropTable(
                name: "Batches",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Shots",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Clinic",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Drugs",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");
        }
    }
}
