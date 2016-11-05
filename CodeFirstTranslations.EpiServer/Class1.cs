using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Framework.Localization;

namespace CodeFirstTranslations.EpiServer
{
    public class CodeFirstTranslationsLocalizationProvider : LocalizationProvider
    {
        public CodeFirstTranslationsLocalizationProvider(CodeFirstTranslationsLocalizationProviderConfiguration configuration)
        {
            AvailableLanguages = configuration.AvailableLanguages;
        }


        public override string GetString(string originalKey, string[] normalizedKey, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ResourceItem> GetAllStrings(string originalKey, string[] normalizedKey, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<CultureInfo> AvailableLanguages { get; }
    }

    public class CodeFirstTranslationsLocalizationProviderConfiguration
    {
        public virtual IEnumerable<CultureInfo> AvailableLanguages { get; set; } = new[]
            {CultureInfo.GetCultureInfo("en")};
    }
}
