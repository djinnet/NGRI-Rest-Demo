namespace NGRI.Frontend.HttpClient
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using NGRI.Library.Model;


    // this class is used to make the http calls to the backend
    public class CustomHttpClient : ICustomHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CustomHttpClient> _logger;
        private readonly string _baseUrl = "https://localhost:7046";

        public CustomHttpClient(HttpClient httpClient, ILogger<CustomHttpClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        #region Estate
        /// <summary>
        /// Get all the estates from the backend
        /// </summary>
        /// <returns>Estates</returns>
        public async Task<Estate[]?> GetEstatesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Estate[]>($"{_baseUrl}/api/Estates");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        //delete an estate
        public async Task<bool> DeleteEstateAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Estates/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }

        //get an estate
        public async Task<Estate?> GetEstateAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Estate>($"{_baseUrl}/api/Estates/{id}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        //update an estate
        public async Task<bool> UpdateEstateAsync(Estate estate)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Estates", estate);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }

        //create an estate
        public async Task<bool> CreateEstateAsync(Estate estate)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Estates", estate);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
        #endregion

        #region Condition Reports
        // get all the reports from the backend with the given estate id
        public async Task<ConditionReport[]?> GetReportsFromEstateID(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ConditionReport[]>($"{_baseUrl}/api/ConditionReports/GetReportsFromEstateID/{id}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        // delete a report
        public async Task<bool> DeleteReportAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/ConditionReports/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }

        // get a report
        public async Task<ConditionReport?> GetReportAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ConditionReport>($"{_baseUrl}/api/ConditionReports/{id}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        // update a report
        public async Task<bool> UpdateReportAsync(ConditionReport report)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/ConditionReports", report);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }

        // create a report
        public async Task<bool> CreateReportAsync(ConditionReport report)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/ConditionReports", report);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
        #endregion

    }
}
