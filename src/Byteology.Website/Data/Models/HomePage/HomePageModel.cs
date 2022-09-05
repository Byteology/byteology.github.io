namespace Byteology.Website.Data.Models.HomePage;

using Byteology.Website.Data.Models.HomePage.InquirySegment;

public record HomePageModel(
    string Title,
    ScientificGeneralizationModel ScientificGeneralization,
    ServiceModel[] Services,
    InquiryModel Inquiry,
    FooterModel Footer);
