using Net5.Worker.Models;
using Net5.Worker.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Worker.Services
{
    internal class CountryService : ICountryService
    {
        private readonly IHttpClientService _http;
        public CountryService(IHttpClientService httpClient)
        {
            _http = httpClient;
        }
        public void FetchAllCountries()
        {
           var response =  _http.GetHttpResponse("https://restcountries.com/v3.1/all", "", "");
           var data = Parser<Country>.ParseJson(response);

            data = data;
        }
    }
}
