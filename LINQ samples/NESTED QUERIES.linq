<Query Kind="Program">
  <Connection>
    <ID>0efe4a00-4357-451f-9220-c6fb794a5c90</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>LAPTOP-TABA6QBI\SQLEXPRESS</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
//Nested queries
// A QUERY WITHIN A QUERY

//LIST ALL SALES SUPPORT EMPLOYEES SHOWING THEIR FULL NAME (LAST, FIRST)
//THEIR TITLE, THE NUMBER OF CUSTOMERS EACH SUPPORTS
//ORDERBY FULLNAME
//IN ADDITION, SHOW A LIST OF THE CUSTOMERS FOR EACH EMPLOYEE
//THERE WILL BE 2 SEPARATE LISTS WITHIN THE SAME DATASET COLLECTION
//ONE FOR EMPLOYEES
//ONE FOR CUSTOMERS OF AN EMPLOYEE

//C# POINT OF VIEW IN A CLASS
//CLASSNAME
//	PROPERTY1 (FIELD)
//	PROPERTY2 (FIELD)
// 	.................
//	COLLECTION<T> SET OF RECORDS

//TO ACCOMPLISH THE LIST OF CUSTOMERS, WE WILL USE A NESTED QUERY
//THE DATASOURCE FOR THE LSIT OF CUSTOMERS WILL BE X.COLLECTION<CUSTOMERS>
//x.NavCollectionName
//x represents the current record on the outer query


var results = from x in Employees
			  where x.Title.Contains("Sales Support")
			  orderby x.LastName, x.FirstName
			  select new EmployeeCustomerList
			  {
			  	EmployeeName = x.LastName + ", " + x.FirstName,
				Title = x.Title,
				CustomersSupportCount = x.SupportRepCustomers.Count(),
				CustomerList = (from y in x.SupportRepCustomers
							   select new CustomerSupportItem
							   {
							   		CustomerName = y.LastName + ", " + y.FirstName,
							   		Phone = y.Phone,
									City = y.City,
									State = y.State
							   }).ToList()
			  };
results.Dump();



//Create a list of albums showing its title and artist
//Show albums with 25 or more tracks only.
//Show the song on the album listing the name and song length
var ex1 = from x in Albums
		  where x.Tracks.Count() >= 25
	      select new 
		  {
		  	Artist = x.Artist.Name,
			Title = x.Title,
			TrackCount = x.Tracks.Count(),
			SongList = (from y in x.Tracks
						//or you could do from y in Tracks
						//where y.AlbumId == x.AlbumId
						select new
						{
							Name = y.Name,
							Length = y.Milliseconds / 1000.0
						}).ToList()
		  };
ex1.Dump();


}

//DEFINE OTHER METHODS AND CLASSES HERE

public class EmployeeCustomerList
{
	public string EmployeeName {get;set;}
	public string Title {get;set;}
	public int CustomersSupportCount {get;set;}
	public IEnumerable<CustomerSupportItem> CustomerList {get;set;}
}

public class CustomerSupportItem 
{
	public string CustomerName {get;set;}
	public string Phone {get;set;}
	public string City {get;set;}
	public string State {get;set;}
}
