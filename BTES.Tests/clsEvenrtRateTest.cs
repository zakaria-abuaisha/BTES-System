namespace BTES.Tests
{
    using System.Windows;
    using BTES.Business_layer.Event_Management;
    using BTES.Forms.Events;

    public class clsEvenrtRateTest
    {
        //[Fact]

        //public void TestIsRequired_EmptyTextBox()
        //{
        //    FRM_RaateEvent form = new FRM_RaateEvent(1);
        //    form.txtUsername

        //    // Create a textbox with empty text
        //    var textbox = new System.Windows.Forms.TextBox();
        //    var cancelEventArgs = new System.ComponentModel.CancelEventArgs();
        //    var result = form.IsRequired(textbox, cancelEventArgs); 
        //    // Check if the method returns false for an empty textbox
        //    Assert.False(result); 

        //}

        [Theory]
        [InlineData(2)]
        public void Findby_ReturnsclsEventRate(int ID)
        {
            // Act
            var result = clsEventRate.FindbyID(ID);

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(100)]
        public void FindbyID_ReturnsNull(int ID)
        {
            // Act
            var result = clsEventRate.FindbyID(ID);
            Assert.Null(result);
        }

        [Theory]
        [InlineData(2, 1)]
        public void IsEventRateExist_ReturnsTrue(int EventID, int CustomerID)
        {
            // Act
            var result = clsEventRate.IsEventRateExist(EventID, CustomerID);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(10, 1)]
        public void IsEventRateExist_ReturnsFalse(int EventID, int CustomerID)
        {
            // Act
            var result = clsEventRate.IsEventRateExist(EventID, CustomerID);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Get_Record_ShouldReturnDataTable()
        { 
            // Act
            var result = clsEventRate.Get_Record();

            Assert.NotNull(result); 
            Assert.True(result.Rows.Count > 0);
        }
    }
}