using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly Context context = new Context();

        public SensorModel getSensorByName(string name)
        {
            return context.sensor.First(s => s.name == name);
        }
    }
}
