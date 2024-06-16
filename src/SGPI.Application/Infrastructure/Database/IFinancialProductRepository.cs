using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database.Contracts;

namespace SGPI.Application.Infrastructure.Database;

public interface IFinancialProductRepository :
    IAddRepository<FinancialProduct>,
    IGetByIdRepository<FinancialProduct>,
    IGetAllRepository<FinancialProduct>,
    IUpdateRepository<FinancialProduct>,
    IDeleteRepository,
    ISaveRepository;