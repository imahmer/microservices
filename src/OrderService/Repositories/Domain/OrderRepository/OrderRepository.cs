using Dapper;
using NLog;
using OrderService.Configuration;
using OrderService.Models.Domain.Order;
using OrderService.Repositories.Base;
using OrderService.Repositories.Database;
using System.Data;

namespace OrderService.Repositories.Domain.OrderRepository
{
    public class OrderRepository : BaseRepository<Order, int>, IOrderRepository
    {
        private readonly IDataConnection _dataConnection;
        private readonly IDBConfig _dBConfig;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public OrderRepository(IDataConnection dataConnection, IDBConfig dBConfig) : base(dBConfig.ConnectionString.Replace("DB_Placeholder", dBConfig.GetDBName()))
        {
            _dataConnection = dataConnection;
            _dBConfig = dBConfig;
        }

        public async Task<OrderListFilter> GetOrderList(OrderListFilter orderListFilter)
        {
            using (var connection = _dataConnection.Connect(_dBConfig.GetDBName(), _dBConfig.ConnectionString))
            {
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@SearchKeyword", orderListFilter.SearchKeyword);
                    param.Add("@Startindex", orderListFilter.StartIndex);
                    param.Add("@Pagesize", orderListFilter.PageSize);
                    param.Add("@Totalrecords", orderListFilter.TotalRecords, direction: ParameterDirection.Output);

                    var categoryGridFilterList = await connection.QueryAsync<OrderGridFilterListItem>("usp_GetOrderGridFilterList", param: param, commandType: CommandType.StoredProcedure);
                    _dataConnection.Disconnect();
                    orderListFilter.TotalRecords = param.Get<int>("@Totalrecords");
                    orderListFilter.OrderGridFilterList = categoryGridFilterList;
                    return orderListFilter;
                }
                catch (Exception ex)
                {
                    _logger.Fatal(ex);
                    _dataConnection.Disconnect();
                    throw;
                }
            }
        }
    }
}
