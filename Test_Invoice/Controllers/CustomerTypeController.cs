using Microsoft.AspNetCore.Mvc;
using Test_Invoice.Common.Entities;
using Test_Invoice.Common.interfaces;
using Test_Invoice.ViewModel;

namespace Test_Invoice.Controllers;

public class CustomerTypeController : Controller
{

    private readonly ICustomerType _customerType;

    public CustomerTypeController(ICustomerType customerType)
    {
        this._customerType = customerType;
    }
    
    public async Task<IActionResult> Index()
    {
        return View();
    }



    [HttpGet]
    public async Task<ViewResult> GetAllCustomerType()
    {
        var customerList = await _customerType.GetAll();
        
        return View(customerList);
    }
    

    [HttpGet]
    public async Task<IActionResult> AddCustomerType()
    {
        return View();
    }

    [HttpPost]
    public async Task<JsonResult> AddCustomerType(CustomerType customerType)
    {
        if (ModelState.IsValid)
        {
            await _customerType.Add(customerType);
            return new JsonResult(new { Message = "Se ha agregado con exito", id = 1 });
        }


        return new JsonResult(new { Message = "No se ha podido crear el tipo de cliente", id = 2 });

    }



    [HttpGet]
    public async Task<IActionResult> UpdateCustomerType(int id)
    {
        var getCustomerType = await _customerType.GetById(id);
        return View(getCustomerType);
    }

    [HttpPost]
    public async Task<JsonResult> UpdateCustomerType(CustomerType customerType)
    {
        await _customerType.Update(customerType);

        return new JsonResult(new { Message = "Se ha actualizado con exito", id = 1 });
    }


    [HttpGet]
    public async Task<IActionResult> RemoveCustomerType(int id)
    {
        
        /*
         *Si se intenta eliminar el registro este daria problemas de foreigh key con la tabla de Customer por ende se necesita agregar un campo tipo status en customerType,
         * cuando se quiera eliminar un tipo este quede deshabilitado y no se pierdan los registros de los customers que fueron registrados, como se solicito usar el script
         * recibido en la prueba no realizaré modificaciones al mismo.
         */
        
        // var getCustomerType = await _customerType.GetById(id);
        // var result =  await _customerType.Remove(getCustomerType);
        //
        // if (result)
        // {
        //     return new JsonResult(new { Message = "Se ha eliminado con exito", id = 1 });
        // }
        // else
        // {
        //     return new JsonResult(new { Message = "No se ha podido eliminar el registro", id = 2 });
        // }

        return new JsonResult(new {});
    }
}