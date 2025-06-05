Scaffold-DbContext
	-Connection "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LEXICON;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
	-Provider "Microsoft.EntityFrameworkCore.SqlServer"
	-OutputDir "Entities"
	-Context "ContactsContext"
	-Tables Adress, Kontakt, Kontaktmetod, Kontakttyp, Ort
	-Force
	-NoOnConfiguring


Scaffold-DbContext -Connection "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LEXICON;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" -Provider "Microsoft.EntityFrameworkCore.SqlServer" -OutputDir "Entities" -Context "ContactsContext" -Tables Adress, Kontakt, Kontaktmetod, Kontakttyp, Ort -Force -NoOnConfiguring
