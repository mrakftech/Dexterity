using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedHealthCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Setting",
                table: "ICPC2",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "Setting",
                table: "ICPC2",
                keyColumn: "Id",
                keyValue: 97);
        }
    }
}
