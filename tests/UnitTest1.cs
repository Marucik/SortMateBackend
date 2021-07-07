using System;
using Xunit;
using FluentAssertions;
using SMB.Core.Domain;
using SMB.Core.Domain.ProductRequest;

namespace tests
{
  public class UnitTest1
  {
    [Fact]
    public void TestProductClass()
    {
      var product = new Product("Test product", "123123123", "Test product description", "plastic");

      product.Name.Should().StartWith("Test");
      product.Code.Should().Be("123123123");
    }
    [Fact]
    public void TestProductRequest()
    {
      var productRequest = new ProductRequest("Test request", "321321321", "Test request description", "glass");

      productRequest.Name.Should().StartWith("Test");
      productRequest.Description.Should().Contain("request").And.EndWith("description");
    }
  }
}
