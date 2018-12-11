using DAL.Db;
using DAL.Db.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Log4NetLogger;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository
    {
        #region Get User Methods
        public EmployeeEntity GetEmployeebyId(int id)
        {
            EmployeeEntity employee = new EmployeeEntity();

            try
            {
                using (var db = new CellularDbContext())
                {
                    employee = (from u in db.Employees
                                where u.UserId == id
                                select u).FirstOrDefault();
                }
                return employee;
            }
            catch (Exception e) { Logger.log.Fatal(e.Message, e); return null; }
        }

        public CustomerEntity GetCustoemrById(int id)
        {
            CustomerEntity customer = new CustomerEntity();

            try
            {
                using (var db = new CellularDbContext())
                {
                    customer = (from u in db.Customers
                                where u.UserId == id
                                select u).FirstOrDefault();
                }
                return customer;
            }
            catch { /*  Write to log*/ return null; }
        }

        public EmployeeEntity GetUserByUsernameAndPassword(string username, string password)
        {
            EmployeeEntity employee = new EmployeeEntity();

            try
            {
                using (var db = new CellularDbContext())
                {
                    employee = (from u in db.Employees
                                where u.Username == username && u.Password == password
                                select u).FirstOrDefault();
                }
                return employee;
            }
            catch { /*  Write to log*/ return null; }
        }

        public CustomerEntity GetCustomerByPhoneAndPassword(string phone, string password)
        {
            CustomerEntity customer = new CustomerEntity();
            try
            {
                using (var db = new CellularDbContext())
                {
                    customer = (from u in db.Customers
                                where u.PhoneNumber == phone && u.Password == password
                                select u).FirstOrDefault();
                }
            }
            catch { /*  Write to log */ return null; }

            return customer;
        }

        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            var allCustomers = new List<CustomerEntity>();
            try
            {
                using (var db = new CellularDbContext())
                {
                    allCustomers = (from u in db.Customers
                                    select u).ToList();
                }
            }
            catch { /* write to log */ return allCustomers; }

            return allCustomers;
        }

        public IEnumerable<CustomerEntity> GetFilteredCustomers(string searchInput)
        {
            var filteredCollection = new List<CustomerEntity>();
            using (var context = new CellularDbContext())
            {
                filteredCollection = (from c in context.Customers
                                      where c.PhoneNumber.Contains(searchInput)
                                      select c).ToList();
            }
            return filteredCollection;
        }
        #endregion

        #region Is User Exist
        public bool IsEmployeeExistByUsername(string username)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    bool contains = context.Employees.Any(e => e.Username == username);
                    return contains;
                }
            }
            catch (Exception) { /*write fatal error to logger*/ return false; }
        }

        public bool IsCustomerExistByPhoneNumber(string phone)
        {
            try
            {
                using (var context = new CellularDbContext())
                {
                    bool contains = context.Customers.Any(e => e.PhoneNumber == phone);
                    return contains;
                }
            }
            catch (Exception) { /*write fatal error to logger*/ return true; }
        }
        #endregion

        #region Add User Methods
        public bool AddUser(UserEntity user)
        {
            try
            {
                using (var db = new CellularDbContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // write fatal error to logger
                return false;
            }

        }

        public bool AddUser(EmployeeEntity user)
        {
            try
            {
                using (var db = new CellularDbContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // write fatal error to logger
                return false;
            }

        }

        public bool AddUser(CustomerEntity user)
        {
            try
            {
                using (var db = new CellularDbContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // write fatal error to logger
                return false;
            }
        }
        #endregion
    }
}
