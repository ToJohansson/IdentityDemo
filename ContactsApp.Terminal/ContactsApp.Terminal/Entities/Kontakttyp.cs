using System;
using System.Collections.Generic;

namespace ContactsApp.Terminal.Entities;

public partial class Kontakttyp
{
    public int Id { get; set; }

    public string Kontakttyp1 { get; set; } = null!;

    public virtual ICollection<Kontaktmetod> Kontaktmetods { get; set; } = new List<Kontaktmetod>();
}
