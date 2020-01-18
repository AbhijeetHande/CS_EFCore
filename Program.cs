using CS_EFCore.Models;
using System;
using System.Linq;

namespace CS_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				ManageDatabase();
				using (var ctx = new PersonDbContext())
				{
					var Person = new Person()
					{  PersonName = "Abhijeet", Gender = "Male", Age = 28 };
					ctx.Persons.Add(Person);
					ctx.SaveChanges();
					Console.WriteLine("Added Person");
					foreach (var p in ctx.Persons.ToList())
					{
						//$ use as interpolation no need to do  + p.Personid+p.PersoName
						Console.WriteLine($"{p.PersonId}{p.PersonName}{p.Age}{p.Gender}" );
					}
				}
				
			}
			catch (Exception ex)
			{

				Console.WriteLine($"{ex.Message}{ex.InnerException}");
			}
			Console.ReadLine();
        }
		//this method will make sure that if database is already avilable 
		//then delete it
		static void ManageDatabase()
		{
			using (var ctx=new PersonDbContext())
			{
				ctx.Database.EnsureDeleted();
				ctx.Database.EnsureCreated();
			}
		}
    }
}
