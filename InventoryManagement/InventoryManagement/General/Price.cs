using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.General;

public class Price
{
    public double ItemPrice { get; set; }
    public Currency Currency { get; set; }

    public Price(double itemPrice, Currency currency)
    {
        ItemPrice = itemPrice;
        Currency = currency;
    }
}
