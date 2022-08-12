using System;

namespace CreateCateringFile;

internal class ArgumentCollection: List<KeyValuePair<string, string>>
{
    internal ArgumentCollection(string[] args)
    {
        if ((args.Length % 2) != 0)
            throw new ArgumentException("Arguments should be key-value pair combinations");
        
        for (int i = 0; i < args.Length; i += 2)
        {
            string key = args[i].ToLowerInvariant();
            if (key == "-sourcefile")
                key = "-s";
            if (key == "-targetfile")
                key = "-t";

            this.Add(new KeyValuePair<string, string>(key, args[i+1]));
        }
    }

    internal string this[string key]
    {
        get { return this.Find(p => p.Key == key.ToLower()).Value; }
    }
}
