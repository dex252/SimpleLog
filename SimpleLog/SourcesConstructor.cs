using SimpleLog.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace SimpleLog
{
    public class SourcesConstructor
    {
        private Dictionary<string, Source> SourcesCollection { get; }

        public SourcesConstructor()
        {
            SourcesCollection = new Dictionary<string, Source>
            {
                { "default", SetDefaultSource() }
            };
        }

        public Dictionary<string, Source> GetSources()
        {
            return SourcesCollection;
        }

        public SourcesConstructor AddSource(Source source)
        {
            if (!SourcesCollection.ContainsKey(source.Name)) 
            {
                SourcesCollection.Add(source.Name, source);
            }

            return this;
        }

        public SourcesConstructor AddSources(params Source[] sources)
        {
            foreach (var source in sources)
            {
                if (!SourcesCollection.ContainsKey(source.Name))
                {
                    SourcesCollection.Add(source.Name, source);
                }
            }

            return this;
        }

        private TextSource SetDefaultSource()
        {
            return new TextSource() { Name = "default"};
        }
    }
}
