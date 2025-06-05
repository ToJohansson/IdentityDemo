using System;
using System.Collections.Generic;

namespace ContactsApp.Terminal.Entities;

public partial class Kontaktmetod
{
    public int Id { get; set; }

    public int KontakttypId { get; set; }

    public string Kontaktdata { get; set; } = null!;

    public int? KontaktId { get; set; }

    public virtual Kontakt? Kontakt { get; set; }

    public virtual Kontakttyp Kontakttyp { get; set; } = null!;
}
