using System;
using System.Collections.Generic;
using System.Linq;
using TDD_Day1_Homework.Interface;
using TDD_Day1_Homework.Model;

namespace TDD_Day1_Homework.Service
{
    public class OrderService
    {
        private IOrderDao _order;

        public OrderService(IOrderDao order)
        {
            this._order = order;
        }

        public List<int> ListOrderSumByColumnGroupByCount(string column, string count)
        {
            // 檢查count是否為大於0的正整數
            int _count = 0;
            if (int.TryParse(count, out _count) == false || _count <= 0)
            {
                throw new ArgumentException("錯誤的分組筆數!");
            }

            // 取得訂單資訊
            List<Order> listOrder = this._order.ListOrderData();
            bool propExists = listOrder[0].GetType().GetProperties()
                            .Where(item => item.Name == column)
                            .Any();
            if (!propExists)
            {
                throw new ArgumentException("錯誤的欄位名稱!");
            }

            // 取得要搜尋欄位的資料
            List<int> listItem = listOrder.Select(item => (int)item.GetType().GetProperty(column).GetValue(item)).ToList();

            // 回傳的結果
            List<int> listResult = new List<int>();

            // 分組資料的Index
            int groupIndex = 0;

            // 分組資料的總合
            int groupSum = 0;

            for (int i = 0; i < listItem.Count(); i++)
            {
                // 新的分組資料，新增至結果，分組資料的Index + 1，分組資料的總合歸0
                if (i / _count != groupIndex)
                {
                    listResult.Add(groupSum);
                    groupIndex++;
                    groupSum = 0;
                }

                // 同一組的分組資料，將資料加總
                if (i / _count == groupIndex)
                {
                    groupSum += listItem[i];
                }

                // 最後一筆資料，新增至結果
                if (i + 1 == listItem.Count())
                {
                    listResult.Add(groupSum);
                }
            }

            return listResult;
        }
    }
}