using Xunit;
using BTES.Business_layer.Event_Management;
using BTES.Forms.Events;

namespace BTES.Test
{
    public class clsEvenrtRateTest
    {
        [Fact]
        public void TestIsRequired_EmptyTextBox()
        {
            FRM_RaateEvent frm = new FRM_RaateEvent(1);
            frm.txtUsername.Text = "";

            // Create a textbox with empty text
            
            var cancelEventArgs = new System.ComponentModel.CancelEventArgs();
            var result = frm.IsRequired(frm.txtUsername, cancelEventArgs);
            // Check if the method returns false for an empty textbox
            Assert.False(result);
        }

        [Fact]
        public void TestIsRequired_NotEmptyTextBox()
        {
            FRM_RaateEvent frm = new FRM_RaateEvent(1);
            frm.txtUsername.Text = "Not Empty";

            // Create a textbox with empty text
            var cancelEventArgs = new System.ComponentModel.CancelEventArgs();
            
            var result = frm.IsRequired(frm.txtUsername, cancelEventArgs);
            // Check if the method returns false for an empty textbox
            Assert.True(result);

        }

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
