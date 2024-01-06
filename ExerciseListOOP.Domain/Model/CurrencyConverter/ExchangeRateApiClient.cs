using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ExerciseListOOP.ConsoleInteraction.Components
{
    public class ExchangeRateApiClient
    {
        private readonly string _apiBaseUrl = "https://economia.awesomeapi.com.br/json/";
        private readonly HttpClient _httpClient;

        public ExchangeRateApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<double> GetExchangeRate()
        {
            string key = "USD";
            try
            {
                string apiUrl = $"{_apiBaseUrl}{key}";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return ParseExchangeRate(content);
                }
                else
                {
                    HandleErrorResponse(response);
                }
            }
            catch (HttpRequestException ex)
            {
                HandleHttpRequestException(ex);
            }
            catch (Exception ex)
            {
                HandleGeneralException(ex);
            }

            // default value only
            return -1;
        }

        private double ParseExchangeRate(string content)
        {
            using (JsonDocument document = JsonDocument.Parse(content))
            {
                JsonElement root = document.RootElement;
                if (root.ValueKind == JsonValueKind.Array && root.GetArrayLength() > 0)
                {
                    JsonElement highElement = root[0].GetProperty("high");

                    if (highElement.ValueKind == JsonValueKind.String)
                    {
                        if (double.TryParse(highElement.GetString(), out double highValue))
                        {
                            Console.Clear();
                            Message.WriteTitle(Title.CurrencyConverter(), "Green");
                            Console.WriteLine($"\nConversão atual BRL-USD: 1-{highValue}");
                            return highValue;
                        }
                        else
                        {
                            Message.Error("Erro ao converter o valor da propriedade 'high' para um número válido.");
                        }
                    }
                    else
                    {
                        Message.Error("A propriedade 'high' não é uma string.");
                    }
                }
                else
                {
                    Message.Error("A resposta JSON não é um array ou está vazia.");
                }
            }

            return -1; // default value
        }

        private void HandleErrorResponse(HttpResponseMessage response)
        {
            Message.Error($"Erro na taxa de conversão. Status code: {response.StatusCode}");
        }

        private void HandleHttpRequestException(HttpRequestException ex)
        {
            Message.Error($"HTTP Request Error: {ex.Message}");
        }

        private void HandleGeneralException(Exception ex)
        {
            Message.Error($"Erro na taxa de conversão: {ex.Message}");
        }
    }
}
