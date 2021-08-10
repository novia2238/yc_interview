using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yc_interview.Models;
using yc_interview.Models.ViewModel;

namespace yc_interview.Service.Customer
{
    public interface ICustomerService
    {
        List<CustomerViewModel> GetList();

        CustomerViewModel Get(string ID);
        Task<ReturnResult> Create(CustomerViewModel model);

        Task<ReturnResult> Edit(CustomerViewModel model);

        Task<ReturnResult> Delete(string ID);
    }
}
