using System;
using SQLite;
using medicinepricechecker.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace medicinepricechecker
{
	public class Repository
	{
		private readonly SQLiteAsyncConnection conn;
		public string StatusMessage { get; set; }

		public Repository(string dbPath)
		{
			conn = new SQLiteAsyncConnection(dbPath);
			conn.CreateTableAsync<Product>().Wait();
		}

		public async Task CreateContact(Product product)
		{
			try
			{
				// Basic validation to ensure we have a contact name.
				if (string.IsNullOrWhiteSpace(product.name))
					throw new Exception("Name is required");

				// Insert/update contact.
				var result = await conn.InsertOrReplaceAsync(product).ConfigureAwait(continueOnCapturedContext: false);
				StatusMessage = $"{result} record(s) added [Contact Name: {product.name}])";
			}
			catch (Exception ex)
			{
				StatusMessage = $"Failed to create contact: {product.name}. Error: {ex.Message}";
			}
		}

		public Task<List<Product>> GetAllProducts()
		{
			return conn.QueryAsync<Product>("select * from product LIMIT 30");
		}

		public async Task<List<Product>> GetProduct(string code)
		{
			return await conn.QueryAsync<Product>("Select * from product where nappi_code = ?", code);
		}



		public async Task<bool> ClearDatabase()
		{
			try
			{
				await conn.DropTableAsync<Product>();
				await conn.CreateTableAsync<Product>();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public Task<int> TableExists()
		{
			// Return a list of bills saved to the Bill table in the database.
			//return conn.Table<Product>().ToListAsync();
			return conn.ExecuteScalarAsync<int>("select count(*) from Product");
		}

	}
}
