using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yc_interview.Models;
using yc_interview.Models.DB;
using yc_interview.Models.ViewModel;

namespace yc_interview.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private NorthwindContext _context;
        public CustomerService(NorthwindContext context) 
        {
            _context = context;
        }

        public List<CustomerViewModel> GetList() 
        {
            var result = _context.Customers.Select(p => 
                new CustomerViewModel { 
                    CustomerId = p.CustomerId,
                    CompanyName = p.CompanyName,
                    ContactName = p.ContactName,
                    Phone = p.Phone
                }).ToList();

            return result;
        }

        public CustomerViewModel Get(string ID) 
        {
            var result = _context.Customers.Where(p => p.CustomerId == ID)
                .Select(p=> new CustomerViewModel {
                    CustomerId = p.CustomerId,
                    CompanyName = p.CompanyName,
                    ContactName = p.ContactName,
                    Phone = p.Phone
                }).FirstOrDefault();

            return result;
        }

        public async Task<ReturnResult> Create(CustomerViewModel model) 
        {
            try
            {

                var customer = new Models.DB.Customer()
                {
                    CustomerId = model.CustomerId,
                    CompanyName = model.CompanyName,
                    ContactName = model.ContactName,
                    Phone = model.Phone
                };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return new ReturnResult { result = "success" };
            }
            catch (Exception ex) 
            {
                return new ReturnResult { result = "error", msg = ex.Message };
            }
        }

        public async Task<ReturnResult> Edit(CustomerViewModel model) 
        {
            try
            {
                var data = _context.Customers.Where(p => p.CustomerId == model.CustomerId).FirstOrDefault();

                if (data != null)
                {
                    data.CompanyName = model.CompanyName;
                    data.ContactName = model.ContactName;
                    data.Phone = model.Phone;

                    await _context.SaveChangesAsync();
                    return new ReturnResult { result = "success" };
                }
                throw new Exception("Customer ID doesn't exsit");
            }
            catch (Exception ex)
            {
                return new ReturnResult { result = "error", msg = ex.Message };
            }
        }
    }
}
