using Restaurant.Abstractions.Facades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Mobile.UI.Facades
{
    public class DiagnosticsFacade : IDiagnosticsFacade
    {
        public void TrackError(Exception exception, IDictionary<string, string> properties = null)
        {
        }

        public void TrackEvent(string name, IDictionary<string, string> properties = null)
        {
        }
    }
}
