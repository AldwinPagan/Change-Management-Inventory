namespace ChangeManagementInventory.Migrations
{
    using ChangeManagementInventory.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChangeManagementInventory.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ChangeManagementInventory.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.AppLicenseTypes.AddOrUpdate(x => x.Id,
                new AppLicenseType
                {
                    Id = new Guid("0b0f8d67-9d02-4bd9-9186-d20bf857fbc1"),
                    Description = "Internal"
                },
                new AppLicenseType
                {
                    Id = new Guid("c72f986f-d144-497e-91ca-cebd5df082e9"),
                    Description = "External"
                }
                );

            context.AppTypes.AddOrUpdate(x => x.Id,
                new AppType
                {
                    Id = new Guid("d4228769-c4ad-443a-ae60-430aaa93614e"),
                    Description = "Windows"
                },
                new AppType
                {
                    Id = new Guid("a7532282-0b56-49a1-b8e4-e715dc57819c"),
                    Description = "Web"
                },
                new AppType
                {
                    Id = new Guid("a8b51665-f2e9-4c9b-b0e8-08d2733187b0"),
                    Description = "iSeries"
                },
                new AppType
                {
                    Id = new Guid("b9d4e4aa-f46a-4358-afeb-3df90c0792fd"),
                    Description = "Mainframe"
                }
                );

            context.Companies.AddOrUpdate(x => x.Id,
             new Company
             {
                 Id = new Guid("0004f448-8dee-4d6e-8246-d3d2519ca352"),
                 Address = "Address 1",
                 BusinessPhone = "1 (800) 234-4567",
                 FaxPhone = "1 (800) 432-4567",
                 isManufacturer = false,
                 isSupplier = true,
                 Name = "Vendor A",

             },
            new Company
            {
                Id = new Guid("8dd132d4-f95e-4713-abd8-f260e5b18ee8"),
                Address = "Address 2",
                BusinessPhone = "1 (800) 234-4567",
                FaxPhone = "1 (800) 432-4567",
                isManufacturer = false,
                isSupplier = true,
                Name = "Vendor B",

            },
             new Company
             {
                 Id = new Guid("01499923-644f-4493-99f1-6c023fbe3c3c"),
                 Address = "Address 3",
                 BusinessPhone = "1 (800) 234-4567",
                 FaxPhone = "1 (800) 432-4567",
                 isManufacturer = true,
                 isSupplier = false,
                 Name = "Vendor C",

             },
            new Company
            {
                Id = new Guid("7a177de8-7ceb-46c3-a11b-80c535596c3b"),
                Address = "Address 4",
                BusinessPhone = "1 (800) 234-4567",
                FaxPhone = "1 (800) 432-4567",
                isManufacturer = true,
                isSupplier = false,
                Name = "Vendor D",


            }
                );

            context.Applications.AddOrUpdate(x => x.Id,
                                new Application
                                {
                                    Id = new Guid("c3c20b35-9c3c-4b81-9bbc-7087aecd628e"),
                                    Abbreviation = "AA",
                                    AppSupportTime = new DateTime(2021, 2, 6),
                                    DBManualPath = "/Path/DB/File1.db",
                                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                                    Name = "Application A",
                                    OpsManualPath = "/Path/Ops/Manual1.txt",
                                    UserManualPath = "/Path/User/Manual1.txt",
                                    Version = "1.0.2",
                                    AppLicenseTypeId = new Guid("0b0f8d67-9d02-4bd9-9186-d20bf857fbc1"),
                                    AppTypeId = new Guid("a8b51665-f2e9-4c9b-b0e8-08d2733187b0"),
                                    ManufacturerId = new Guid("01499923-644f-4493-99f1-6c023fbe3c3c"),
                                    SupplierId = new Guid("7a177de8-7ceb-46c3-a11b-80c535596c3b"),
                                    HighAvailable = true,
                                    NeedADAuthentication = false,
                                    Support = false,
                                    IsActive = true,
                                    UseProcesses = false
                                },

                new Application
                {
                    Id = new Guid("9379183f-0293-4f2c-ba93-b2869562c22b"),
                    Abbreviation = "BB",
                    AppSupportTime = new DateTime(2021, 3, 6),
                    DBManualPath = "/Path/DB/File2.db",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Name = "Application B",
                    OpsManualPath = "/Path/Ops/Manual2.txt",
                    UserManualPath = "/Path/User/Manual2.txt",
                    Version = "1.0.2",
                    AppLicenseTypeId = new Guid("0b0f8d67-9d02-4bd9-9186-d20bf857fbc1"),
                    AppTypeId = new Guid("b9d4e4aa-f46a-4358-afeb-3df90c0792fd"),
                    ManufacturerId = new Guid("0004f448-8dee-4d6e-8246-d3d2519ca352"),
                    SupplierId = new Guid("8dd132d4-f95e-4713-abd8-f260e5b18ee8")

                },

                new Application
                {
                    Id = new Guid("40907551-43cf-42e7-a295-a4d42b68301d"),
                    Abbreviation = "CC",
                    AppSupportTime = new DateTime(2021, 4, 5),
                    DBManualPath = "/Path/DB/File3.pdf",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Name = "Application C",
                    OpsManualPath = "/Path/Ops/Manual3.pdf",
                    UserManualPath = "/Path/User/Manual3.txt",
                    Version = "2.5.89",

                    AppLicenseTypeId = new Guid("c72f986f-d144-497e-91ca-cebd5df082e9"),
                    AppTypeId = new Guid("a7532282-0b56-49a1-b8e4-e715dc57819c"),
                    ManufacturerId = new Guid("7a177de8-7ceb-46c3-a11b-80c535596c3b"),
                    SupplierId = new Guid("0004f448-8dee-4d6e-8246-d3d2519ca352")

                }
                ,

                new Application
                {
                    Id = new Guid("609e0834-5495-48da-a005-4230cc8b3255"),
                    Abbreviation = "DD",
                    AppSupportTime = new DateTime(2025, 7, 8),
                    DBManualPath = "/Path/DB/File4.pdf",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Name = "Application D",
                    OpsManualPath = "/Path/Ops/Manual4.pdf",
                    UserManualPath = "/Path/User/Manual4.txt",
                    Version = "12.5.89",

                    AppLicenseTypeId = new Guid("c72f986f-d144-497e-91ca-cebd5df082e9"),
                    AppTypeId = new Guid("a7532282-0b56-49a1-b8e4-e715dc57819c"),
                    ManufacturerId = new Guid("7a177de8-7ceb-46c3-a11b-80c535596c3b"),
                    SupplierId = new Guid("0004f448-8dee-4d6e-8246-d3d2519ca352")

                }
                );

        }
    }
}
