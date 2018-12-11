using Common.Enums;
using DAL.Db.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Log4NetLogger;

namespace DAL.Db
{
    class DbInit : DropCreateDatabaseIfModelChanges<CellularDbContext>
    {
        private int baseMinutePrice = 3;
        private int baseSmsPrice = 1;

        protected override void Seed(CellularDbContext context)
        {
            context.Packages.Add(new PackageEntity
            {
                PackageName = "Base Package",
                BasePricePerMinute = baseMinutePrice,
                BasePricePerSMS = baseSmsPrice,
                DateActivated = DateTime.Now

            });

            context.Employees.Add(new EmployeeEntity
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Username = "batman",
                Password = "iambatman",
                Address = "Gotham",
                Role = EmployeeRole.Manager,
                PhoneNumber = "0501111111",
                EmailAddress = "batman@cell.com",
                IsActive = true
            });

            context.Employees.Add(new EmployeeEntity
            {
                FirstName = "Alfred",
                LastName = "Paennyworth",
                Username = "eagle",
                Password = "masterwayne",
                Address = "Gotham",
                PhoneNumber = "0402222222",
                EmailAddress = "alfred@cell.com",
                Role = EmployeeRole.CustomerService,
                IsActive = true
            });

            context.Customers.Add(new CustomerEntity
            {
                FirstName = "Peter",
                LastName = "Parker",
                PhoneNumber = "0503333333",
                Password = "spiderman",
                Address = "New York",
                EmailAddress = "spidey@gmail.com",
                IsActive = true,
                Customer_Type = CustomerType.Standart,
                Lines = new List<LineEntity>
                {
                    new LineEntity
                    {
                        LineNumber = "0503333333",
                        Packages = new List<PackageEntity>
                        {
                            new MinutesBankPackageEntity
                            {
                                PackageName = "50 for 50",
                                BasePricePerMinute = 2,
                                BasePricePerSMS = 1,
                                DateActivated = DateTime.Now,
                                MinutesBankPrice = 50,
                                AmountOfMinutesInPackage = 35,
                                AmountOfSmsInPackage = 15
                            }
                        }
                    }
                }
            });

            context.Customers.Add(new CustomerEntity
            {
                FirstName = "Tony",
                LastName = "Stark",
                PhoneNumber = "0503345686",
                Password = "ironman",
                Address = "malibu california",
                EmailAddress = "tony@stark.com",
                IsActive = true,
                Customer_Type = CustomerType.Vip,
                Lines = new List<LineEntity>
                {
                    new LineEntity
                    {
                        LineNumber = "0503345686",
                        Packages = new List<PackageEntity>()
                        {
                            new MinutesBankPackageEntity
                            {
                                PackageName = "100 for 100",
                                BasePricePerMinute = 2,
                                BasePricePerSMS = 1,
                                DateActivated = DateTime.Now,
                                MinutesBankPrice = 100,
                                AmountOfMinutesInPackage = 75,
                                AmountOfSmsInPackage = 25
                            }
                        }
                    }
                }


            });

            context.Customers.Add(new CustomerEntity
            {
                FirstName = "Sela",
                LastName = "Group",
                PhoneNumber = "0508899663",
                Password = "123456",
                Address = "baruch hirsch 14 Bnei brak",
                EmailAddress = "aaa@bbb.com",
                IsActive = true,
                Customer_Type = CustomerType.Bussiness,
                Lines = new List<LineEntity>
                {
                    new LineEntity
                    {
                        LineNumber = "0500000001",
                        Packages = new List<PackageEntity>()
                        {
                            new SpecialPricePackageEntity
                            {
                                PackageName = "Special Program",
                                BasePricePerMinute = 2,
                                BasePricePerSMS = 1,
                                DateActivated = DateTime.Now,
                                PackagePricePerMinute = 1,
                                PackagePricePerSMS = 0.5
                            }
                        }
                    },
                    new LineEntity
                    {
                        LineNumber = "0500000002",
                        Packages = new List<PackageEntity>()
                        {
                            new SpecialPricePackageEntity
                            {
                                PackageName = "Special Program",
                                BasePricePerMinute = 2,
                                BasePricePerSMS = 1,
                                DateActivated = DateTime.Now,
                                PackagePricePerMinute = 1,
                                PackagePricePerSMS = 0.5
                            }
                        }
                    },
                    new LineEntity
                    {
                        LineNumber = "0500000003",
                        Packages = new List<PackageEntity>()
                        {
                            new SpecialPricePackageEntity
                            {
                                PackageName = "Special Program",
                                BasePricePerMinute = 2,
                                BasePricePerSMS = 1,
                                DateActivated = DateTime.Now,
                                PackagePricePerMinute = 1,
                                PackagePricePerSMS = 0.5
                            }
                        }
                    }
                }
            });

            try
            {
                context.SaveChanges();
                Logger.log.Debug(LogMessages.ChangesSavedToDb);
            }
            catch (DbEntityValidationException e)
            {
                Logger.log.Fatal(e.Message, e);
            }
            catch (DbUpdateException e)
            {
                Logger.log.Fatal(e.Message, e);
            }
            catch (Exception e)
            {
                Logger.log.Fatal(e.Message, e);
            }
        }
    }
}