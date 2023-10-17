using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test_Invoice.Common.Entities;
using Test_Invoice.Common.interfaces;
using Test_Invoice.ViewModel;

namespace Test_Invoice.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        private readonly ICustomerType _customerType;
        
        public CustomerController(ICustomer customer, ICustomerType customerType)
        {
            _customer = customer;
            _customerType = customerType;

        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {

            var result = await _customer.GetAll();

            var listOfCustomer = new CustomerTypeViewModel()
            {
                Customers = await _customer.GetAll(),
                CustomerTypes = await _customerType.GetAll()
            };

            return View(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            var listCustomerType = await _customerType.GetAll();

            var items = listCustomerType.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            });

            ViewBag.customerType = items;
            
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddCustomer(Customer? customer)
        {
             if (customer?.CustName != null  && customer?.Adress != null)
             {
                 await _customer.Add(customer);

                 return new JsonResult(new { Message = "Se ha creado el cliente", id = 1 });
             }

             return new JsonResult(new { Message = "No se ha podido crear el cliente", id = 2 });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var getCustomer = await _customer.GetById(id);

            TempData["CustomerId"] = id;
            
            var listCustomerType = await _customerType.GetAll();

            var items = listCustomerType.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            });

            ViewBag.customerType = items;
            
            return View(getCustomer);
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer? customer)
        {
            customer!.Id = Convert.ToInt32(TempData["CustomerId"].ToString());
            
            if (customer != null)
            {
                await _customer.Update(customer);

                return new JsonResult(new { Message = "Se ha actualizado con exito", id = 1 });
            }

            return new JsonResult(new { Message = "No se ha podido actualizar", id = 2 });
        }
    }
}
