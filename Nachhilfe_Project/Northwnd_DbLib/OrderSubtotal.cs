using System;
using System.Collections.Generic;

namespace Northwnd_DbLib;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
