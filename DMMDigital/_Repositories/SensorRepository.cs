using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using System.Collections.Generic;
using System.Linq;

namespace DMMDigital._Repositories
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
