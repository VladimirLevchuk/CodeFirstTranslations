using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstTranslations
{
    public class TranslationClasses : ITranslationClasses
    {
        protected HashSet<Type> Classes = new HashSet<Type>();

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
            foreach (var type in types)
            {
                Classes.Add(type);
            }
            
            return this;
        }

        public virtual bool Contains(Type type)
        {
            return Classes.Contains(type);
        }
    }
}