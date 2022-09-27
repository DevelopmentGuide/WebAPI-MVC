using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private DataBaseContext order_context;
        public OrderController(DataBaseContext order_context)
        {
            this.order_context = order_context;
        }

        // CREATE
        [HttpPost]
        public string Post([FromBody] Order transaction)
        {
            this.order_context.Orders.Add(transaction);
            this.order_context.SaveChanges();
            return "Order sent successfully!";
        }


        // GET ORDERS
        [Authorize(Roles = "Admin")]
        [HttpGet("order")]
        public IEnumerable<UserOrder> GetOrder()
        {
            var usersOrder = from o in order_context.Set<Order>()
                             join u in order_context.Set<Users>()
                             on o.UserId equals u.UserId
                             select new UserOrder
                             {
                                 TransactionId = o.TransactionId,

                                 MemberId = o.MemberId,
                                 ProductName = o.ProductName,
                                 RequiredDate = o.RequiredDate,
                                 Quantities = o.Quantities,
                                 UserId = o.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                             };
            return usersOrder.ToList();
        }

        [HttpGet("email/{email}")]
        public IEnumerable<UserOrder> GetOrderById(string email)
        {
            var usersOrder = from o in order_context.Set<Order>()
                             join u in order_context.Set<Users>()
                             on o.UserId equals u.UserId
                             select new UserOrder
                             {
                                 TransactionId = o.TransactionId,

                                 MemberId = o.MemberId,
                                 ProductName = o.ProductName,
                                 RequiredDate = o.RequiredDate,
                                 Quantities = o.Quantities,

                                 UserId = o.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                             };
            return usersOrder.ToList().Where(x => x.Email == email);
        }

    }
}
