using System.Collections.Generic;
using TDD_Day1_Homework.Model;

namespace TDD_Day1_Homework.Interface
{
    public interface IOrderDao
    {
        List<Order> ListOrderData();
    }
}