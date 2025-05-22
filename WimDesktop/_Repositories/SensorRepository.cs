using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using System.Collections.Generic;
using System.Linq;

namespace WimDesktop._Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly Context context = new Context();

        public List<SensorModel> getAllSensors()
        {
            return context.sensor.ToList();
        }
    }
}
