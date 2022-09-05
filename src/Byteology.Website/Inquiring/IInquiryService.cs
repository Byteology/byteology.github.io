namespace Byteology.Website.Inquiring;

public interface IInquiryService
{
    Task<bool> SendInquiryAsync(InquiryData inquiry);
}
