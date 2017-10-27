using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Windows;

namespace CarRentalClient.Models
{
	public class CustomerRepository : ICustomerRepository
	{
		private HttpClient Connect()
		{
			HttpClient client = new HttpClient
			{
				BaseAddress = new Uri("http://carrentalservice2017.azurewebsites.net/")
				//Address for local testing
				//BaseAddress = new Uri("http://localhost:51147/")
			};
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}

		public IEnumerable<Customer> GetAll()
		{
			HttpClient client = Connect();
			HttpResponseMessage response = client.GetAsync("api/Customer").Result;
			IEnumerable<Customer> customers = null;

			if (response.IsSuccessStatusCode)
			{
				customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
			}
			else
			{
				MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
			}
			return customers;
		}


	}
}