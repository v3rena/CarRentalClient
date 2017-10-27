using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalClient.Models
{
	public class CarRepository : ICarRepository
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

		public Car Get(int id)
		{
			HttpClient client = Connect();
			HttpResponseMessage response = client.GetAsync("api/Car/" + id).Result;
			IEnumerable<Car> cars = null;

			if (response.IsSuccessStatusCode)
			{
				cars = response.Content.ReadAsAsync<IEnumerable<Car>>().Result;
			}
			else
			{
				MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
			}
			return cars.FirstOrDefault();
		}

		public IEnumerable<Car> GetAll()
		{
			HttpClient client = Connect();
			HttpResponseMessage response = client.GetAsync("api/Car").Result;
			IEnumerable<Car> cars = null;

			if (response.IsSuccessStatusCode)
			{
				cars = response.Content.ReadAsAsync<IEnumerable<Car>>().Result;
			}
			else
			{
				MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
			}
			return cars;
		}

		public bool Update(Car car)
		{
			HttpClient client = Connect();

			HttpResponseMessage response = client.PutAsJsonAsync("api/Car/" + car.ID, car).Result;
			response.EnsureSuccessStatusCode();

			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
				return false;
			}
		}
	}
}
