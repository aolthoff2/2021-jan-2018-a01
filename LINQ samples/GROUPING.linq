<Query Kind="Statements">
  <Connection>
    <ID>0efe4a00-4357-451f-9220-c6fb794a5c90</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>LAPTOP-TABA6QBI\SQLEXPRESS</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//GROUPING

//A) BY A COLUMN			Key
//B) BY MULTIPPLE COLUMNS	Key.attribute
//C) BY AN ENTITY			Key.attribute

//GROUPS HAVE 2 COMPONENTS
// A) KEY COMPONENT (GROUPBY0 TO REFERENECE THIS COMPONENT USE Key[.attribute]
// B) DATA (INSTANCES IN THE GROUP)

//PROCESS
//START WITH A "PILE" OF DATA
//SPECIFY THE GROUPING
//THE RESULT IS SMALLER "PILES" OF DATA DETERMINED BY THE GROUP


//GROUPING CAN BE SAVED TEMPORARILY INTO DATASETS AND THE INDIVIDUAL GROUP DATASET CAN BE REPORTED ON

//REPORT ALBUMS BY RELEASEYEEAR
var resultsorderby = from x in Albums
					orderby x.ReleaseYear
					select x;
resultsorderby.Dump();

//group by column
var resultsgroupby = from x in Albums
					group x by x.ReleaseYear;
resultsgroupby.Dump();

//group by columns
var resultsgroupby1 = from x in Albums
					group x by new {x.Artist.Name,x.ReleaseYear};
resultsgroupby1.Dump();

//group tracks by their albums (entity)
var resultsgroupbyentity = from x in Tracks
							group x by x.Album;
resultsgroupbyentity.Dump();



//IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//IF YOU WISH TO REPORT ON GROUPS (AFTER THE GROUPBY)
//	YOU MUST SAVED THE GROUPING INTO A TEMPORARY DATASET
//	THEN YOU MUST USE THE TEMPORARY DATASET TO REPORT FROM

var resultsgroupbyReport = from x in Albums
							group x by x.ReleaseYear into gAlbumYear
							select new 
							{
								KeyValue = gAlbumYear.Key,
								numberofAlbums = gAlbumYear.Count(),
								albumandartist = from y in gAlbumYear
													select new
													{
														Title = y.Title,
														Artist = y.Artist.Name
													}
							};
resultsgroupbyReport.Dump();


//group by an entity
var groupAlbumsbyArtist = from x in Albums
							group x by x.Artist into gArtistAlbums
							select new
							{
								Artist = gArtistAlbums.Key.Name,
								numberofAlbums = gArtistAlbums.Count(),
								AlbumList = gArtistAlbums
											.Select( y => new 
															{
																Title = y.Title,
																Year = y.ReleaseYear
															})
							};

groupAlbumsbyArtist.Dump();


//CREATE A QUERY WHICH WILL REPORT THE EMPLOYEE AND THEIR CUSTOMER BASE 
//LIST THE EMPLOYEE FULL NAME (PHONE), NUMBER OF CUSTOMERS IN THEIR BASE
//LIST THE FULLNAME, CITY AND STATE FOR THE CUSTOMER BASE


var ex1 = from x in Customers
			group x by x.SupportRep into gTemp
			select new 
			{
				Employee = gTemp.Key.LastName + "," + 
							gTemp.Key.FirstName + "(" +
							gTemp.Key.Phone + ")",
				BaseCount = gTemp.Count(),
				CustomerList = from y in gTemp 
								select new 
								{
									Name = y.LastName + ", " + y.FirstName,
									City = y.City,
									State = y.State
								}
								
			};
			
ex1.Dump();










					






















