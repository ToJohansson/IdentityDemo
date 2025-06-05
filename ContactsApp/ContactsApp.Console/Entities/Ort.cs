using System;
using System.Collections.Generic;

namespace ContactsApp.Console.Entities;

public partial class Ort
{
    public int Id { get; set; }

    public string Ortsnamn { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();
}
