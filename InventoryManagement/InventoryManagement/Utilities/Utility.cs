using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Utilities;

public class Utility
{
    // This method is used to generate a unique ID for each order
    public static int GenerateUniqueId()
    {
        return new Random().Next(1, 1000000); // Generates a random number between 1 and 1,000,000
    }
}
