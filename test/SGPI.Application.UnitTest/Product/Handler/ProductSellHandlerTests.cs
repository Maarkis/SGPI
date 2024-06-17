using Ardalis.GuardClauses;
using FluentAssertions;
using Moq;
using SGPI.Application.Common;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database;
using SGPI.Application.Product.Commands;
using SGPI.Application.Product.Handlers;

namespace SGPI.Application.UnitTest.Product.Handler;

public class ProductSellHandlerTests
{
    private readonly CancellationToken _cancellationToken = default;
    private ProductSellCommand _command;
    private Mock<IFinancialProductRepository> _financialProductRepositoryMock;
    private Mock<IFinancialProductTransactionRepository> _financialProductTransactionRepositoryMock;
    private Mock<IProductCodeGenerator> _productCodeGeneratorMock;
    private ProductSellHandler _sut;

    [SetUp]
    public void SetUp()
    {
        _financialProductRepositoryMock = new Mock<IFinancialProductRepository>();
        _financialProductTransactionRepositoryMock = new Mock<IFinancialProductTransactionRepository>();
        _productCodeGeneratorMock = new Mock<IProductCodeGenerator>();
        _sut = new ProductSellHandler(_financialProductTransactionRepositoryMock.Object,
            _financialProductRepositoryMock.Object);
        _command = new ProductSellCommand(Guid.NewGuid(), 1, 10);
    }


    [Test]
    public async Task Handle_ThrowsNotFoundException_WhenProductNotFound()
    {
        _financialProductRepositoryMock
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FinancialProduct)null!);

        await FluentActions
            .Invoking(async () => await _sut.Handle(_command, CancellationToken.None))
            .Should()
            .ThrowExactlyAsync<NotFoundException>()
            .WithMessage($"Queried object Product with id: {_command.FinancialProductId} was not found, Key: Product");
    }

    [Test]
    public async Task Handle_CallsAddAsync_WithCorrectParameters()
    {
        _productCodeGeneratorMock
            .Setup(productCodeGenerator => productCodeGenerator
                .GenerateProductCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateOnly>()))
            .Returns("test");
        var financialProduct =
            FinancialProduct.Create("test", "test", 100, DateTime.Now, 10, _productCodeGeneratorMock.Object);
        _financialProductRepositoryMock
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(financialProduct);


        await _sut.Handle(_command, _cancellationToken);

        _financialProductTransactionRepositoryMock
            .Verify(repo => repo
                .AddAsync(It.Is<FinancialProductSale>(x =>
                        x.ClientId == _command.ClientId &&
                        x.ClientId == _command.ClientId &&
                        x.Quantity == _command.Quantity &&
                        x.Price == financialProduct.Value &&
                        x.ProductDetail.FinancialProductId == financialProduct.Id &&
                        x.ProductDetail.Name == financialProduct.Name &&
                        x.ProductDetail.Value == financialProduct.Value &&
                        x.ProductDetail.ProductCode == financialProduct.ProductCode),
                    It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task Handle_CallSavesChanges_TimesOnce()
    {
        _productCodeGeneratorMock
            .Setup(productCodeGenerator => productCodeGenerator
                .GenerateProductCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateOnly>()))
            .Returns("test");
        var financialProduct =
            FinancialProduct.Create("test", "test", 100, DateTime.Now, 10, _productCodeGeneratorMock.Object);
        _financialProductRepositoryMock
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(financialProduct);


        await _sut.Handle(_command, _cancellationToken);

        _financialProductTransactionRepositoryMock
            .Verify(repo => repo
                .SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}