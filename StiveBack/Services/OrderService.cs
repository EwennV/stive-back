using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;
using System.Security.Claims;

namespace StiveBack.Services
{
    public class OrderService
    {
        private MainDbContext _database;
        private readonly UserService _userService;

        public OrderService()
        {
        }

        public OrderService(MainDbContext mainDbContext, UserService userService)
        {
            _database = mainDbContext;
            _userService = userService;
        }

        public OrderRessource Add(OrderSaveRessource orderSaveRessource)
        {
            var order = OrderSaveRessourceToOrder(orderSaveRessource);

            _database.orders.Add(order);
            _database.SaveChanges();

            return OrderToOrderRessource(order);
        }

        public List<OrderRessource> Get()
        {
            var orders = _database.orders.ToList();
            var orderRessources = orders.Select(o => OrderToOrderRessource(o)).ToList();

            return orderRessources;
        }

        public OrderRessource GetById(int id)
        {
            var order = _database.orders.Find(id);

            if (order == null)
            {
                return null;
            }

            return OrderToOrderRessource(order);
        }

        public List<OrderRessource> GetByUser(User user)
        {
            var orders = _database.orders.Where(order => order.User == user).Select(order => OrderToOrderRessource(order)).ToList();
            
            return orders;
        }

        public OrderRessource Modify(int id, OrderSaveRessource orderSaveRessource)
        {
            Order order = _database.orders.Find(id);

            order.UserId = orderSaveRessource.UserId;
            order.OrderProduct = orderSaveRessource.Products.Select(p => new OrderProduct
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            _database.SaveChanges();

            return OrderToOrderRessource(order);
        }


        public void Delete(int id)
        {
            var order = _database.orders.Find(id);

            _database.orders.Remove(order);
            _database.SaveChanges();
        }

        private OrderRessource OrderToOrderRessource(Order order)
        {

            List<OrderProduct> orderProducts = _database.orderproducts.Where(orderProduct => orderProduct.Order == order).ToList();

            var orderRessource = new OrderRessource
            {
                Id = order.Id,
                Date = order.Date,
                UserId = order.UserId,
                OrderProducts = orderProducts.Select(p => new OrderProductRessource
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                }).ToList()
            };

            return orderRessource;
        }

        private Order OrderSaveRessourceToOrder(OrderSaveRessource orderSaveRessource)
        {

            var order = new Order
            {
                Date = DateTime.Now,
                UserId = orderSaveRessource.UserId,
                OrderProduct = orderSaveRessource.Products.Select(p => new OrderProduct {
                    ProductId = p.ProductId, Quantity = p.Quantity 
                }).ToList(),
            };

            return order;
        }

        internal List<OrderRessource> GetByUser(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}
