using ContactsApp.Terminal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ContactsContext();

            var query = context.Kontakts
                .Select(k => new
                {
                    k.Id,
                    k.Förnamn,
                    k.Efternamn,
                    k.Adress.Gata,
                    k.Adress.Gatunummer,
                    k.Adress.Postnummer,
                    k.Adress.Ort,
                    kontaktsätt = k.Kontaktmetods
                    .Select(m => new
                    {
                        m.Kontaktdata
                    })
                });

            ShowQueryAsSQL(query.ToQueryString());

            foreach (var kontakt in query)
            {
                Console.WriteLine($"""
                --------------------------
                ID:      {kontakt.Id}
                Namn:    {kontakt.Förnamn} {kontakt.Efternamn}
                Adress:  {kontakt.Gata} {kontakt.Gatunummer}, {kontakt.Postnummer} {kontakt.Ort.Ortsnamn}

                """);
                foreach (var data in kontakt.kontaktsätt)
                {
                    Console.WriteLine($"         - {data}");
                }
                Console.WriteLine("--------------------------\n");

            }
        }

        private static void ShowQueryAsSQL(string value)
        {
            Console.Clear();
            Console.WriteLine(value);
            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
            Console.ReadKey(true);

        }
    }
}
