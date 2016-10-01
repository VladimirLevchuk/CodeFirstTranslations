using System;

namespace CodeFirstTranslations
{
    public class PathUtil : IPathUtil
    {
        public virtual string PathSeparator => "/";

        public virtual string Combine(string path1, string path2)
        {
            if (path1 == null) throw new ArgumentNullException(nameof(path1));
            if (path2 == null) throw new ArgumentNullException(nameof(path2));

            bool path1EndsWithSeparator = path1.EndsWith(PathSeparator);
            bool path2StartsWithSeparator = path2.StartsWith(PathSeparator);

            if (path1EndsWithSeparator && path2StartsWithSeparator)
            {
                return path1 + path2.Substring(PathSeparator.Length);
            }

            if (!path1EndsWithSeparator && !path2StartsWithSeparator)
            {
                return path1 + PathSeparator + path2;
            }

            return path1 + path2;
        }

        public virtual string MakeKey(string path)
        {
            return path.ToLowerInvariant();
        }
    }
}