namespace Byteology.Website.Inquiring;

using System.Threading.Tasks;

public class GoogleDriveInquiryService : IInquiryService
{
    private readonly HttpClient _httpClient;

    public GoogleDriveInquiryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> SendInquiryAsync(InquiryModel inquiry)
    {
        List<KeyValuePair<string, string>> payload = new()
        {
            new KeyValuePair<string, string>(nameof(inquiry.Name), inquiry.Name ?? ""),
            new KeyValuePair<string, string>(nameof(inquiry.Email), inquiry.Email ?? ""),
            new KeyValuePair<string, string>(nameof(inquiry.Phone), inquiry.Phone ?? ""),
            new KeyValuePair<string, string>(nameof(inquiry.Message), inquiry.Message ?? "")
        };

        FormUrlEncodedContent content = new(payload);
        HttpResponseMessage response = await _httpClient.PostAsync("", content);

        bool result = response.IsSuccessStatusCode;
        return result;
    }
}
