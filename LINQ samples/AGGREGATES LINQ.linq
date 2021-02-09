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

//AGGREGRATES
//.Count(), .Sum(), .Min(), .Max(), .Average()

//AGGREGRATES OPERATE ON COLLECTIONS
 var ex1 = Albums.Count();

//FOR AGGREGRATES .Sum, .Min, .Max, .Average
// YOU NEED TO SPECIFY A FIELD FOR THE AGGREGRATE

//HOW MUCH ROOM DOES THE MUSIC COLLECTION ON THE
//	DATABASE TAKE?
//TRACKS TABLE HAS A FIELD CALLED BYTES
//	THIS FIELD HOLDS THE SIZE OF A TRACK
//	SUMMING THE FIELD OF ALL TRACKS WILL GET ME
//	THE TOTAL REQUIRED DISK SPACE
var ex2 = Tracks.Where(x => x.Album.ReleaseYear == 1990).Sum(x => x.Bytes);
var ex21 = (from x in Tracks
			where x.Album.ReleaseYear == 1990
			select x.Bytes).Sum();

var ex3 = Tracks.Where(x => x.Album.ReleaseYear == 1990).Min(x => x.Bytes);
var ex4 = Tracks.Where(x => x.Album.ReleaseYear == 1990).Max(x => x.Bytes);
var ex5 = Tracks.Where(x => x.Album.ReleaseYear == 1990).Average(x => x.Bytes);
ex2.Dump();
ex3.Dump();
ex4.Dump();
ex5.Dump();
ex21.Dump();

//LIST OF ALL ALBUMS SHOWING THEIR TITLE, ARTIST NAME AND THE NUMBER OF TRACKS FOR THAT ALBUM
// SHOW ONLY ALBUMS OF THE 60'S. ORDERBY THE NUMBER OF TRACKS FROM MOST TO LEAST
var ex6 =   from x in Albums
   			where x.ReleaseYear < 1970 && x.ReleaseYear >= 1960
			orderby x.Tracks.Count() descending
   			select new 
  			 {
   				Artist = x.Artist.Name,
				Title = x.Title,
				ReleaseYear = x.ReleaseYear,
				NumberOfTracks = x.Tracks.Count()
   			};

ex6.Dump();
//METHOD SYNTAX
//Albums
//   .Where (x => ((x.ReleaseYear < 1970) && (x.ReleaseYear >= 1960)))
//   .OrderByDescending (x => x.Tracks.Count ())
//   .Select (
//      x => 
//         new  
//         {
//            Artist = x.Artist.Name, 
//            Title = x.Title, 
//            ReleaseYear = x.ReleaseYear, 
//            NumberOfTracks = x.Tracks.Count ()
//         }
//   )


//ex6a = from x in Albums
//   			where x.ReleaseYear < 1970 && x.ReleaseYear >= 1960
//			orderby x.Tracks.Count() descending
//   			select new 
//  			 {
//   				Artist = x.Artist.Name,
//				Title = x.Title,
//				ReleaseYear = x.ReleaseYear,
//				NumberOfTracks = (from y in x.Tracks
//									select y).Count()
//   			};


//PRODUCE A LIST OF  60s ALBUMS WHICH HAVE TRACKS SHOWING THEIR TITLE,
// ARTIST NAME, NUMBER OF TRACKS ON ALBUM, TOTAL PRICE OF ALL TRACKS ON ALBUM
// THE LONGEST ALBUM TRACK, THE SHORTEST ALBUM TRACK, THE AVERAGE TRACK LENGTh.
var ex7 =   from x in Albums
   			where x.ReleaseYear < 1970 && x.ReleaseYear >= 1960
			&& x.Tracks.Count() > 0
   			select new 
  			 {
   				Artist = x.Artist.Name,
				Title = x.Title,
				ReleaseYear = x.ReleaseYear,
				NumberOfTracks = x.Tracks.Count(),
				TrackPrices = x.Tracks.Sum(tr => tr.UnitPrice),
				LongestTrack = x.Tracks.Max(tra => tra.Milliseconds),
				ShortestTrack = x.Tracks.Min(y => y.Milliseconds),
				AverageTrack = x.Tracks.Average(track => track.Milliseconds),
				longestTrackSong = (from e in x.Tracks
									where e.Milliseconds == x.Tracks.Max(tr => tr.Milliseconds)
									select e.Name).FirstOrDefault()
				};

ex7.Dump();







