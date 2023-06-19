﻿using System;
using System.Collections.Generic;

namespace KolekcjaPlyt_Web.Models;

public partial class Wypozyczajacy
{
    public int IdWypozyczajacy { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public string? NrTelefonu { get; set; }

    public string? Email { get; set; }

    public string? KodPocztowy { get; set; }

    public string? Miasto { get; set; }

    public string? Ulica { get; set; }

    public string? NumerMieszkania { get; set; }

    public virtual ICollection<Wypozyczenie> Wypozyczenies { get; set; } = new List<Wypozyczenie>();
}
