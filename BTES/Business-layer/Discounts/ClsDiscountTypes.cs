using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Data_Access.Discounts
{
    public class DiscountType
    {
        public int typeNumber { get; set; }
        public string typeName { get; set; }
        public float value { get; set; }

        public DiscountType(int typeNumber, string typeName, float value)
        {
            this.typeNumber = typeNumber;
            this.typeName = typeName;
            this.value = value;
        }
    }

    public static class ClsDiscountTypes
    {
        public static readonly DiscountType[] DiscountTypes =
        {
            new DiscountType(1, "Military People", 0.90f),
            new DiscountType(2, "Seniors +65", 0.95f),
            new DiscountType(3, "Students", 0.90f),
            new DiscountType(4, "Teachers", 0.90f)
        };

    }
}
