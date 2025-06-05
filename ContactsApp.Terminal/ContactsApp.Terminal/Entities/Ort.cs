using System;
using System.Collections.Generic;

namespace ContactsApp.Terminal.Entities;

public partial class Ort
{
    public int Id { get; set; }

    public string Ortsnamn { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();
}
