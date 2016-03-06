using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using TDD_Day1_Homework.Interface;
using TDD_Day1_Homework.Model;

namespace TDD_Day1_Homework.Service.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void 總合計算_以Cost欄位分組_3筆資料一組_結果應為6_15_24_21()
        {
            //arrange
            IOrderDao orderDao = Substitute.For<IOrderDao>();
            orderDao.ListOrderData().Returns(ListOrderData());

            var target = new OrderService(orderDao);

            string column = "Cost";
            string count = "3";
            List<int> expected = new List<int>() { 6, 15, 24, 21 };

            //act
            List<int> actual = target.ListOrderSumByColumnGroupByCount(column, count);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 總合計算_以Revenue欄位分組_4筆資料一組_結果應為50_66_60()
        {
            //arrange
            IOrderDao orderDao = Substitute.For<IOrderDao>();
            orderDao.ListOrderData().Returns(ListOrderData());

            var target = new OrderService(orderDao);

            string column = "Revenue";
            string count = "4";
            List<int> expected = new List<int>() { 50, 66, 60 };

            //act
            List<int> actual = target.ListOrderSumByColumnGroupByCount(column, count);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        private List<Order> ListOrderData()
        {
            List<Order> listResult = new List<Order>();

            listResult.Add(new Order { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 });
            listResult.Add(new Order { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 });
            listResult.Add(new Order { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 });
            listResult.Add(new Order { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 });
            listResult.Add(new Order { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 });
            listResult.Add(new Order { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 });
            listResult.Add(new Order { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 });
            listResult.Add(new Order { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 });
            listResult.Add(new Order { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 });
            listResult.Add(new Order { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 });
            listResult.Add(new Order { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 });

            return listResult;
        }
    }
}