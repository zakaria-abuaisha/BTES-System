using BTES.Business_layer.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BTES.Test
{
    public class clsDiscountTest
    {
        
        [Theory]
        [InlineData(2)]
        public void IsDiscountExist_ShouldReturnTrue(int DiscountID)
        {
            // Act
            var result = ClsDiscount.IsDiscountExist(DiscountID);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        public void Find_ShouldReturnDiscount(int DiscountID)
        {
            // Act
            var result = ClsDiscount.Find(DiscountID);

            // Assert
            Assert.NotNull(result);
        }
    }
}
