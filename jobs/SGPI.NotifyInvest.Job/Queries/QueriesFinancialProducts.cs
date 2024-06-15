using Dapper;
using SGPI.NotifyInvest.Job.Models;

namespace SGPI.NotifyInvest.Job.Queries;

public interface IQueriesFinancialProducts
{
    public Task<List<FinancialProduct>> GetFinancialProducts(DateTime date);
}

public class QueriesFinancialProducts(IDatabase database) : IQueriesFinancialProducts
{
    public async Task<List<FinancialProduct>> GetFinancialProducts(DateTime date)
    {
        var connection = await database.ConnectAsync();
        const string query = """
                             SELECT 
                                 "id",
                                 "name",
                                 "type",
                                 "value",
                                 "maturity_date" as "maturityDate",
                                 "interest_rate" as "interestRate",
                                 "product_code" as "productCode"
                             FROM 
                                 public.financial_products
                             WHERE
                                 "maturity_date" <= @date
                             """;

        var financialProducts = await connection.QueryAsync<FinancialProduct>(query, new { date });
        return financialProducts.ToList();
    }
}