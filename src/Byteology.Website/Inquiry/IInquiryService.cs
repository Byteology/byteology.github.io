namespace Byteology.Website.Inquiry;

public interface IInquiryService
{
    Task<bool> SendInquiryAsync(InquiryData inquiry);
}
