using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders(DateTime date);
        void AddOrder(Order order);
        void EditOrder(Order orderToUpdate);
        Order LoadOrder(int orderNumber, DateTime date);
        void RemoveOrder(int orderNumbertoRemove, DateTime date);
        void OverwriteFile(List<Order> orders);
        void CreateAndWrite(Order order);
        List<Product> GetProductInfo(string productType);
        List<Tax> GetTaxInfo(string State);
        string GetFileName(DateTime date);
        bool SeeIfFileExists(string path);
    }
}
