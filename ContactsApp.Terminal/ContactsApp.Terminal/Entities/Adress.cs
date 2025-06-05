using System;
using System.Collections.Generic;

namespace ContactsApp.Terminal.Entities;

public partial class Adress
{
    public int Id { get; set; }

    public string Gata { get; set; } = null!;

    public int Gatunummer { get; set; }

    public string Postnummer { get; set; } = null!;

    public int? OrtId { get; set; }

    public virtual ICollection<Kontakt> Kontakts { get; set; } = new List<Kontakt>();

    public virtual Ort? Ort { get; set; }
}
