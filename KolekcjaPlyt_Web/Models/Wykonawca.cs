using System;
using System.Collections.Generic;

namespace KolekcjaPlyt_Web.Models;

public partial class Wykonawca
{
    public int IdWykonawca { get; set; }

    public string Wykonawca1 { get; set; } = null!;

    public virtual ICollection<Czlonek> Czloneks { get; set; } = new List<Czlonek>();

    public virtual ICollection<Utwor> Utwors { get; set; } = new List<Utwor>();
}
