using Microsoft.AspNetCore.SignalR;
using SignalRDemoApplication.Constants;

namespace SignalRDemoApplication.Hubs
{
    public class DealthlyHallowHub :  Hub
    {
        public Dictionary<string, int> GetRaceStatus()
        {
            return SD.DeathlyHallowRace;
        }
    }
}
