namespace Byteology.Website.Data.Models.HomePage;

using Byteology.Website.Data.Models.HomePage.InquirySegment;
using Byteology.Website.Data.Models.HomePage.ServucesListSegment;

public record HomePageModel(
    string Title,
    ScientificGeneralizationModel ScientificGeneralization,
    ServicesListModel ServicesList,
    InquiryModel Inquiry);
