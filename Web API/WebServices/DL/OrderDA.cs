using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebServices.Models;
using System.Data;

namespace WebServices.DL
{
    public class OrderDA
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        internal List<MenuItemDOM> GetMenuItems()
        {
            try
            {
                string SQL = string.Empty;

                List<MenuItemDOM> Menu_recs = new List<MenuItemDOM>();

                SQL = @"SELECT ITM.ID, ITM.ItemCode, ITM.ItemName, S.ItemPrice, S.PortionSize
                        FROM MenuItem AS S 
                        INNER JOIN ItemMaster AS ITM ON ITM.ID = S.ItemID
 ";
                DataTable dt = DbHelper.GetDataTable(SQL, conn);

                foreach (DataRow dr in dt.Rows)
                {
                    MenuItemDOM Menu = new MenuItemDOM();

                    Menu.ID = Convert.ToInt32(dr["ID"]);
                    Menu.ItemCode = dr["ItemCode"].ToString();
                    Menu.Name = dr["ItemName"].ToString();
                    Menu.ItemPrice = Convert.ToDecimal(dr["ItemPrice"]);
                    Menu.PortionSize = dr["PortionSize"].ToString();
                    Menu_recs.Add(Menu);

                }
                return Menu_recs;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        internal OrderCountsDOM GetOrderCounts()
        {
            try
            {
                string SQL = string.Empty;

                SQL = @"SELECT*,(SELECT COUNT(ID) FROM OrderHeader WHERE OrderStatus = '1') AS INQueue,
                        (SELECT COUNT(ID) FROM OrderHeader WHERE OrderStatus = '2') AS Prepared,
                        (SELECT COUNT(ID) FROM OrderHeader WHERE OrderStatus = '3') AS Cancelled
                        FROM OrderHeader ";
                DataTable DT = DbHelper.GetDataTable(SQL, conn);

                OrderCountsDOM Count = new OrderCountsDOM();

                Count.InQueue = Convert.ToInt32(DT.Rows[0]["INQueue"]);
                Count.Prepared = Convert.ToInt32(DT.Rows[0]["Prepared"]);
                Count.Cancelled = Convert.ToInt32(DT.Rows[0]["Cancelled"]);

                return Count;


            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        internal string UpdateOrder(int orderID, string Status)
        {
            try
            {
                string SQL = string.Empty;
                string Message = string.Empty;

                SQL = @"UPDATE OrderHeader SET OrderStatus = '" + Status + "' WHERE ID = '" + orderID + "' ";
                DbHelper.Execute(SQL, conn);

                Message = "Success";

                return Message;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        internal Orders_rec GetOrders()
        {
            Orders_rec Orders_recs = new Orders_rec();
            try
            {
                string SQL = string.Empty;
                string SQL1 = string.Empty;

                List<OrderItemsResponceDOM> OrderItems_recs = new List<OrderItemsResponceDOM>();

                SQL += "SELECT* FROM OrderHeader ";
                
                DataTable dt = DbHelper.GetDataTable(SQL, conn);

                foreach (DataRow dr in dt.Rows)
                {
                    OrderItemsResponceDOM Order = new OrderItemsResponceDOM();

                    Order.OrderID = Convert.ToInt32(dr["ID"]);
                    Order.OrderType = dr["OrderType"].ToString();
                    Order.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                    Order.OrderThrough = dr["OrderThrough"].ToString();
                    Order.OrderUser = dr["OrderUser"].ToString();
                    Order.OrderStatus = dr["OrderStatus"].ToString();
                    OrderItems_recs.Add(Order);

                    List<OrderItemsDOM> OrdermenuItems_rec = new List<OrderItemsDOM>();

                    SQL1 = @"SELECT OS.*, S.ItemName FROM OrderItem AS OS
                            INNER JOIN MenuItem AS M ON M.ID = OS.MenuItemID
                            INNER JOIN ItemMaster AS S ON S.ID = M.ItemID
                            WHERE OrderID = '" + Order.OrderID + "' ";
                    DataTable Dt = DbHelper.GetDataTable(SQL1, conn);

                    foreach (DataRow OItems in Dt.Rows)
                    {
                        OrderItemsDOM OItem_rec = new OrderItemsDOM();

                        OItem_rec.ID = Convert.ToInt32(OItems["ID"]);
                        OItem_rec.OrderID = Convert.ToInt32(OItems["OrderID"]);
                        OItem_rec.MenuItemID = Convert.ToInt32(OItems["MenuItemID"]);
                        OItem_rec.ItemName = OItems["ItemName"].ToString();
                        OItem_rec.Remark = OItems["Remarks"].ToString();
                        OrdermenuItems_rec.Add(OItem_rec);

                    }
                    Order.OrderItems = OrdermenuItems_rec;


                }
                Orders_recs.OrdersResponce = OrderItems_recs;

                return Orders_recs;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        internal string CreateOrder(CreateOrderDOM orderRequest)
        {
            var tran = conn.BeginTransaction();
            string Message = string.Empty;

            try
            {
                string SQL = string.Empty;
                string SQL1 = string.Empty;


                SQL = @"INSERT INTO OrderHeader (OrderType,OrderDate,OrderThrough,OrderUser,OrderStatus) VALUES('" + orderRequest.OrderType + "',GETDATE(),'" + orderRequest.OrderThrough + "', '" + orderRequest.OrderUser + "', '" + orderRequest.OrderStatus + "') SELECT ID FROM OrderHeader WHERE id = SCOPE_IDENTITY() ";
                int ID = Convert.ToInt32(DbHelper.GetScalar(SQL, conn));


                foreach (var Orders in orderRequest.OrderItems)
                {
                    SQL1 = @"INSERT INTO OrderItem (OrderID, MenuItemID,Qty, Remarks) VALUES ('" + ID + "','" + Orders.MenuItemID + "','" + Orders.Qty + "','" + Orders.Remark + "' ) ";
                    DbHelper.Execute(SQL1, conn);
                }

                tran.Commit();
                conn.Close();

                Message = "Success";

                return Message;

            }
            catch (Exception Ex)
            {
                tran.Rollback();
                conn.Close();
                return Message = "UnSuccessfull";
            }
        }
    }
}