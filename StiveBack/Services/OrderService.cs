using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;

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

        public OrderRessource Add(OrderRessource orderRessource)
        {
            var order = OrderRessourceToOrder(orderRessource);

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


        public void Delete(int id)
        {
            var order = _database.orders.Find(id);

            _database.orders.Remove(order);
            _database.SaveChanges();
        }

        private OrderRessource OrderToOrderRessource(Order order)
        {
            var orderRessource = new OrderRessource
            {
                Date = order.Date,
                UserId = order.UserId,
                UserRessource = _userService.UserToUserRessource(order.User)
            };

            return orderRessource;
        }

        private Order OrderRessourceToOrder(OrderRessource orderRessource)
        {
            var order = new Order
            {
                Date = orderRessource.Date,
                UserId = orderRessource.UserId,
                User = _database.users.Find(orderRessource.UserId)
            };

            return order;
        }

        public OrderRessource Update(int id, OrderRessource orderRessource)
        {
            var existingOrder = _database.orders.Find(id);

            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.Date = orderRessource.Date;
            existingOrder.UserId = orderRessource.UserId;
            existingOrder.User = _database.users.Find(orderRessource.UserId);

            _database.SaveChanges();

            return OrderToOrderRessource(existingOrder);
        }

    }
}
