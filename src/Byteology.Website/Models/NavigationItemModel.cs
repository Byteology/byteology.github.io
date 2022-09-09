namespace Byteology.Website.Models;

public record NavigationItemModel(LinkModel Link, LinkModel[] Sublinks, bool Highlighted);
