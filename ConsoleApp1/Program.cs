using SimpleLog;
using SimpleLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sources = new Source[]
            {
                 new TextSource() { Name = "Text1" },
                 new TextSource() { Name = "Text2" },
                 new TextSource() { Name = "Text3" },

                 new DatabaseSource() { Name = "Database1" },
                 new DatabaseSource() { Name = "Database2" },
                 new DatabaseSource() { Name = "Database3" },

                 new HttpSource() { Name = "Http1" },
                 new HttpSource() { Name = "Http2" },
                 new HttpSource() { Name = "Http3" },

                 new EmailSource() { Name = "Email1" },
                 new EmailSource() { Name = "Email2" },
                 new EmailSource() { Name = "Email3" },
            };

            var constructor = new SourcesConstructor().AddSources(sources).AddSource(sources[0]).AddSource(sources[0]).AddSource(sources[1]).AddSource(sources[2]);

            var logger1 = new Logger(constructor);
            logger1.AddSources(Area.Text | Area.Email, "default", "Text1", "Text2");

            var logger2 = new Logger(constructor);
            logger2.AddSources(Area.Text | Area.Email, "Text1", "Text2", "Email1");

            var logger3 = new Logger(constructor);
            logger3.AddSources(Area.Text | Area.Email, "Text1", "Text2", "Text3");

            var logger4 = new Logger(constructor);
            logger4.AddSources(Area.Text | Area.Email, "default", "Text1", "Text2", "Email2", "Email3");

            var logger5 = new Logger(constructor);
            logger5.AddSources(Area.Text | Area.Email | Area.Database, "default", "Text1", "Text2", "Text3");

            var logger6 = new Logger(constructor);
            logger6.AddSources(Area.Text);

            var loggers = new List<ILogger>() { logger1, logger2, logger3, logger4, logger5, logger6 };

            var message = $"Hello world";
            Parallel.For(0, 10000, e =>
            {
                loggers.AsParallel().ForAll(e =>
                {
                    e.Write(message);
                });

            });


            Console.ReadKey();
        }
    }
}
