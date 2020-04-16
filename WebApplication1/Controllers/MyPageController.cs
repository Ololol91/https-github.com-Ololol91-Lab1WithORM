using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scaffolding.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MyPageController : Controller
    {
        private readonly ScladContext _context;
        

        public MyPageController(ScladContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<object> myModel = new List<object>();
            myModel.Add(_context.Countries.ToList());
            myModel.Add(_context.Creators.Include(c => c.Country).ToList());
            myModel.Add(_context.Clients.ToList());
            myModel.Add(_context.Employees.ToList());
            myModel.Add(_context.Order.ToList());
            myModel.Add(_context.Posts.ToList());
            myModel.Add(_context.Products.ToList());
            myModel.Add(_context.Providers.ToList());
            myModel.Add(_context.Sendings.ToList());
            myModel.Add(_context.TypeProducts.ToList());
            return View(myModel);
        }


    }
}
