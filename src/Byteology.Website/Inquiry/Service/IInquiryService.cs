namespace Byteology.Website.Inquiry.Service;

public interface IInquiryService
{
    Task<bool> SendInquiryAsync(InquiryDataBase inquiry);
}
