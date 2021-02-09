<Query Kind="Expression">
  <Connection>
    <ID>0efe4a00-4357-451f-9220-c6fb794a5c90</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>LAPTOP-TABA6QBI\SQLEXPRESS</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//method syntax (code as objects)
//Albums.Take (100)
Albums
.Select(currentrow => currentrow)

//query syntax
// the placeholder "currentrow" represents any individual row
//		on your table at any point in time during processing
//"currentrow" can be any name you wish
from placeholder in Albums
select placeholder

//partial table rows
//In this example we will create a new output instance layout
//The default layout is the specified receiving field names and order
//the data that fills the new output instance comes from the current row of the table
//query syntax
from x in Albums
select new 
{
	Title = x.Title,
	Year = x.ReleaseYear
}

//method syntax
Albums
   .Select (
      x => 
         new  
         {
            Title = x.Title, 
            Year = x.ReleaseYear
         }
   )
   
   
   
//where clause
//is used for filter your selections
//query syntax
//select only albums in the year 1990
from x in Albums
where x.ReleaseYear == 1990
select x


//method syntax
Albums
   .Where (x => (x.ReleaseYear == 1990))
   .Select (x => x)

//orderby clause
//ascending and/or descending
//query syntax
from x in Albums
where x.ReleaseYear >= 1990 && x.ReleaseYear < 2000
orderby x.ReleaseYear, x.Title descending
select x


//method syntax
Albums
   .Where (x => ((x.ReleaseYear >= 1990) && (x.ReleaseYear < 2000)))
   .OrderBy (x => x.ReleaseYear)
   .ThenByDescending (x => x.Title)
   
//create a list of albums showing the Album Title, Artist and Release Year for the 70s



Albums
 .Where (x => ((x.ReleaseYear >= 1970) && (x.ReleaseYear <1980)))
 .OrderBy (x => x.Artist.Name)
 .ThenBy (x => x.Title)
   .Select (
      x => 
         new  
         {
		 	Artist = x.Artist.Name,
            Title = x.Title,
            Year = x.ReleaseYear
         }
   )
   
   
   
   from x in Albums
   where x.ReleaseYear < 1980 && x.ReleaseYear >= 1970
   orderby x.Artist.Name, x.Title
   select new 
   {
   		Artist = x.Artist.Name,
		Title = x.Title,
		Year = x.ReleaseYear
   }








