using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstTranslations
{
    public class TranslationClasses : ITranslationClasses
    {
        protected List<Type> Classes = new List<Type>();

        public string DefaultCulture { get; }

        public TranslationClasses(string defaultCulture)
        {
            DefaultCulture = defaultCulture;
        }

        public virtual ITranslationClasses Add<TTranslationClass>()
        {
            Classes.Add(typeof(TTranslationClass));
            return this;
        }

        public virtual List<Type> ToList()
        {
            return this.Classes.ToList();
        }

        public virtual ITranslationClasses AddRange(IEnumerable<Type> types)
        {
            Classes.AddRange(types);
            return this;
        }

        public virtual bool Contains(Type type)
        {
            return Classes.Contains(type);
        }
    }
}