using System;
using System.Collections.Generic;

namespace KolekcjaPlyt_Web.Models;

public partial class Nabycie
{
    public int IdNabycie { get; set; }

    public DateTime? DataNabycia { get; set; }

    public decimal? Cena { get; set; }

    public virtual Plytum? Plytum { get; set; }
}
