using System;
using System.Collections.Generic;

namespace KolekcjaPlyt_Web.Models;

public partial class Plytum
{
    public int IdPlyta { get; set; }

    public string Nazwa { get; set; } = null!;

    public string? Komentarz { get; set; }

    public string RodzajPlyty { get; set; } = null!;

    public string StatusPosiadania { get; set; } = null!;

    public int? IdNabycie { get; set; }

    public virtual Nabycie? IdNabycieNavigation { get; set; }

    public virtual ICollection<Utwor> Utwors { get; set; } = new List<Utwor>();

    public virtual ICollection<Wypozyczenie> Wypozyczenies { get; set; } = new List<Wypozyczenie>();
}
