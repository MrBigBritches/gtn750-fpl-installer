using System;
using System.Collections.Generic;
using System.Text;

namespace gtn750_fpl_installer.lib
{
    internal class FlightplanException(Flightplan flightplan, string message) : Exception(message)
    {
        internal Flightplan Flightplan = flightplan;
    }
}
