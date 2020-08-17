using SimpleLog.Loggers;
using SimpleLog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Logger : ILogger
    {
        private List<IExecutor> ActiveExecutor { get; } = new List<IExecutor>();

        private Dictionary<string, Source> SourcesCollection { get; }

        public Logger(SourcesConstructor sourcesConstructor)
        {
            SourcesCollection = sourcesConstructor.GetSources();
        }

        public void Write(string message)
        {
            Task.Run( () =>
            {
                foreach (var executor in ActiveExecutor)
                {
                    executor.Write(message);
                }

                //Parallel.ForEach(ActiveExecutor, executor =>
                //{
                //    executor.Write(message);
                //});

                //ActiveLoggers.AsParallel().ForAll(executor =>
                //{
                //    executor.Write(message);
                //});
            });
           
        }

        public void AddSources(Area area, params string[] sources)
        {
            if (ActiveExecutor.Count != 0) return;

            SetArea(area);

            foreach (var source in sources)
            {
                if (SourcesCollection.ContainsKey(source))
                {
                    var extractedSource = SourcesCollection[source];
                    SetSource(area, extractedSource);
                }
            }
        }

        private void SetSource(Area area, Source extractedSource)
        {
            if (area.HasFlag(Area.Text) && extractedSource is TextSource)
            {
                ActiveExecutor.Where(e => e is TextExecutor).First()?.AddSource(extractedSource);
            }

            if (area.HasFlag(Area.Database) && extractedSource is DatabaseSource)
            {
                ActiveExecutor.Where(e => e is DatabaseExecutor).First()?.AddSource(extractedSource);
            }

            if (area.HasFlag(Area.Email) && extractedSource is EmailSource)
            {
                ActiveExecutor.Where(e => e is EmailExecutor).First()?.AddSource(extractedSource);
            }

            if (area.HasFlag(Area.Http) && extractedSource is HttpSource)
            {
                ActiveExecutor.Where(e => e is HttpExecutor).First()?.AddSource(extractedSource);
            }
        }

        private void SetArea(Area area)
        {
            if (area.HasFlag(Area.Text))
            {
                ActiveExecutor.Add(new TextExecutor());
            }
            if (area.HasFlag(Area.Database))
            {
                ActiveExecutor.Add(new DatabaseExecutor());
            }
            if (area.HasFlag(Area.Email))
            {
                ActiveExecutor.Add(new EmailExecutor());
            }
            if (area.HasFlag(Area.Http))
            {
                ActiveExecutor.Add(new HttpExecutor());
            }
        }
    }
}









//Type[] types = Assembly.GetExecutingAssembly().GetTypes();
//types.Where(
//    t => t.IsNotPublic && t.BaseType == typeof(ILogger)).ToArray();
//            foreach (var type in types)
//            {
//                var associate = type.GetAttributeValue<LogAttribute>()?.Value;

//                if (associate != null && area.HasFlag(associate))
//                {

//                    var logger = Activator.CreateInstance(type);
//                    //ActiveLoggers.Add();
//                }
//            }
