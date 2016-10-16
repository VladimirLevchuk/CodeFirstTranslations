using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests.Quickstart
{
    public class ValidationTest : TestBase
    {
        public class ValidationTool
        {
            private static ValidationContext CreateContext(object obj)
            {
                return new ValidationContext(obj, serviceProvider: null, items: null);
            }

            public static void ValidateObject(object obj)
            {
                var context = CreateContext(obj);
                Validator.ValidateObject(obj, context);
            }

            public static bool TryValidate(object obj, ICollection<ValidationResult> validationResults)
            {
                var context = CreateContext(obj);
                return Validator.TryValidateObject(obj, context, validationResults);
            }
        }

        public class ValidationMessages
        {
            public static string FieldIsRequired 
                => new StringTranslationProperty("'{0}' is required");

        }

        public class Model
        {
            [Required(ErrorMessageResourceType = typeof(ValidationMessages),
                ErrorMessageResourceName = nameof(ValidationMessages.FieldIsRequired))]
            public string Id { get; set; }
        }

        [Test]
        public void Translations_With_Validation()
        {
            TranslationsEnvironment.TranslationTypesRegistry.Add<ValidationMessages>();

            var errors = new List<ValidationResult>();
            ValidationTool.TryValidate(new Model(), errors).Should().BeFalse();
            errors.Count.Should().BePositive();
            errors.First().ErrorMessage.Should().Be("'Id' is required");
        }
    }
}