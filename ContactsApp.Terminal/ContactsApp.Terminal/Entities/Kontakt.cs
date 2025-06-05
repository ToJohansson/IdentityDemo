using System;
using System.Collections.Generic;

namespace ContactsApp.Terminal.Entities;

public partial class Kontakt
{
    public int Id { get; set; }

    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;

    public int? AdressId { get; set; }

    public virtual Adress? Adress { get; set; }

    public virtual ICollection<Kontaktmetod> Kontaktmetods { get; set; } = new List<Kontaktmetod>();
}
