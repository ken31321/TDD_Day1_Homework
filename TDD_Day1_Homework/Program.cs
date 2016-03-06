using System;
using System.Collections.Generic;
using TDD_Day1_Homework.Dao;
using TDD_Day1_Homework.Service;

namespace TDD_Day1_Homework
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("請輸入你要加總的欄位名稱:");
            var column = Console.ReadLine();

            Console.WriteLine("請輸入你要每幾筆加總一次:");
            var count = Console.ReadLine();

            //建立OrderService
            var orderService = GetOrderService();

            //計算總合、回傳List<int>
            try
            {
                List<int> result = orderService.ListOrderSumByColumnGroupByCount(column, count);

                Console.WriteLine("查詢結果:" + String.Join(",", result));
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("查詢失敗! 失敗原因:" + ex.Message);
                Console.ReadKey();
            }
        }

        private static OrderService GetOrderService()
        {
            var order = new OrderDao();
            var result = new OrderService(order);

            return result;
        }
    }
}