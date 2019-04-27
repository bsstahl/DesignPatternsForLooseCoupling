using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateCateringData
{
    internal class ArgumentCollection : List<KeyValuePair<string, string>>
    {
        internal ArgumentCollection(string[] args)
        {
            if ((args.Count() % 2) != 0)
                throw new ArgumentException("Arguments should be key-value pair combinations");

            for (int i = 0; i < args.Count(); i += 2)
            {
                string key = args[i].ToLowerInvariant();
                if (key == "-sourcefile")
                    key = "-s";
                if (key == "-targetfile")
                    key = "-t";
                if ((key == "-startdate") || (key == "-start"))
                    key = "-sd";
                if ((key == "-enddate") || (key == "-end"))
                    key = "-ed";

                this.Add(new KeyValuePair<string, string>(key, args[i + 1]));
            }
        }

        internal string this[string key]
        {
            get { return this.Find(p => p.Key == key.ToLower()).Value; }
        }

        internal bool ContainsKey(string key)
        {
            return this.Any(p => p.Key == key);
        }
    }
}
