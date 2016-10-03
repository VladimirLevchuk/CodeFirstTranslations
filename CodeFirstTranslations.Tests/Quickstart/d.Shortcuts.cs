using System.Collections.Generic;
using CodeFirstTranslations.Shortcuts;
using FluentAssertions;
using JetBrains.Annotations;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests.Quickstart
{
    public class Shortcuts
    {
        public class T : StringTranslationProperty
        {
            public T([NotNull] string text, [CanBeNull] IEnumerable<string> alternativeKeys) : base(text, alternativeKeys)
            {
            }

            public T([NotNull] string text) : base(text)
            {
            }
        }

        public class T2 : TranslationFormat2Property
        {
            public T2([NotNull] string text, [CanBeNull] IEnumerable<string> alternativeKeys) : base(text, alternativeKeys)
            {
            }

            public T2([NotNull] string text) : base(text)
            {
            }
        }

        public class Translations : TestBase
        {
            public static string First => new T("My first translation");
            public static Translation Second = new T("My second translation");
            public static T Third = new T("The third one");
            public static T2 WithTwoParameters = new T2("Format with two parameters: {0} and {1}");
            public static Translation WithDifferentCultures = new T("default").en("english").no("norwegian");
        }

        [Test]
        public void Sample()
        {
            Translations.WithTwoParameters.Format("one", "two").Should().Be("Format with two parameters: one and two");
            Translations.Second.Key.Should().Be("/translations/second");
        }
    }
}