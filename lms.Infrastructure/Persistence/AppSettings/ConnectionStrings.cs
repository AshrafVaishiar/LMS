using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lms.Infrastructure.Persistence.AppSettings
{
    public class ConnectionStrings
    {
        public const string SectionName = "ConnectionStrings";

        public string Sql { get; init; } = null!;

        public string Mongo { get; init; } = null!;
    }
}
