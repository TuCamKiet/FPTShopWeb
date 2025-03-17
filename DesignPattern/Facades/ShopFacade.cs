using DO_AN_FPT_SHOP.DesignPattern.UnitOfWorkPattern;
using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.DesignPattern.Facades
{
    public class ShopFacade
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        public List<Order> GetAllOrders()
        {
            return _unitOfWork.Orders.GetAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _unitOfWork.Orders.GetById(id);
        }

        public void CreateOrder(Order order)
        {
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Commit();
        }

        public void UpdateOrder(Order order)
        {
            _unitOfWork.Orders.Update(order);
            _unitOfWork.Commit();
        }

        public void DeleteOrder(int id)
        {
            var order = _unitOfWork.Orders.GetById(id);
            _unitOfWork.Orders.Remove(order);
            _unitOfWork.Commit();
        }

        public List<Product> GetAllProducts()
        {
            return _unitOfWork.Products.GetAll().ToList();
        }

        public Product GetProductById(int id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public void CreateProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Commit();
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
        }

        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            _unitOfWork.Products.Remove(product);
            _unitOfWork.Commit();
        }

        public List<User> GetAllUsers()
        {
            return _unitOfWork.Users.GetAll().ToList();
        }

        public User GetUserById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public void CreateUser(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Commit();
        }

        public void UpdateUser(User user)
        {
            _unitOfWork.Users.Update(user);
            _unitOfWork.Commit();
        }

        public void DeleteUser(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            _unitOfWork.Users.Remove(user);
            _unitOfWork.Commit();
        }
    }
}