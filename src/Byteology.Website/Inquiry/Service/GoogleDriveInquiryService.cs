namespace Byteology.Website.Inquiry.Service;

using System.Threading.Tasks;

public class GoogleDriveInquiryService : IInquiryService
{
    private readonly HttpClient _httpClient;

    public GoogleDriveInquiryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> SendInquiryAsync(InquiryDataBase inquiry)
    {
        List<KeyValuePair<string, string>> payload = inquiry.ToPayload();

        FormUrlEncodedContent content = new(payload);
        HttpResponseMessage response = await _httpClient.PostAsync(Config.GoogleDriveInquiryServiceUrl, content);

        bool result = response.IsSuccessStatusCode;
        return result;
    }
}
