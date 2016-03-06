using System.Collections.Generic;
using TDD_Day1_Homework.Interface;
using TDD_Day1_Homework.Model;

namespace TDD_Day1_Homework.Dao
{
    public class OrderDao : IOrderDao
    {
        public List<Order> ListOrderData()
        {
            int idItem = 1;
            int costItem = 1;
            int revenueItem = 11;
            int sellPriceItem = 21;

            List<Order> listResult = new List<Order>();

            for (int i = 0; i < 11; i++)
            {
                listResult.Add(new Order { Id = idItem, Cost = costItem, Revenue = revenueItem, SellPrice = sellPriceItem });

                idItem++;
                costItem++;
                revenueItem++;
                sellPriceItem++;
            }

            return listResult;
        }
    }
}