using EPiServer.Core;

namespace CodeFirstTranslations.EpiServer.EpiTest.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
