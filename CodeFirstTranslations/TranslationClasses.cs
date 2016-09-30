using System;
using System.Collections.Generic;
using System.Linq;

namespace Creuna.CodeFirstTranslations2
{
    public interface ITranslationClasses
    {
        string DefaultCulture { get; }
        List<Type> ToList();
        bool Contains(Type type);
    }

    public interface IWriteOnlyTranslationClasses
    {
        IWriteOnlyTranslationClasses Add<TTranslationClass>();
        IWriteOnlyTranslationClasses AddRange(IEnumerable<Type> types);
    }

    public class TranslationClasses : ITranslationClasses, IWriteOnlyTranslationClasses
    {
        protected List<Type> Classes = new List<Type>();

        public string DefaultCulture { get; }

        public TranslationClasses(string defaultCulture)
        {
            DefaultCulture = defaultCulture;
        }

        public virtual IWriteOnlyTranslationClasses Add<TTranslationClass>()
        {
            Classes.Add(typeof(TTranslationClass));
            return this;
        }

        public virtual List<Type> ToList()
        {
            return this.Classes.ToList();
        }

        public virtual IWriteOnlyTranslationClasses AddRange(IEnumerable<Type> types)
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