namespace Byteology.Website.Company.Career;

public record JobOpening(string Id, string Title, string Intro, Type Icon, (int Min, int Max)? SalaryInEuro, Type DetailsComponent);
