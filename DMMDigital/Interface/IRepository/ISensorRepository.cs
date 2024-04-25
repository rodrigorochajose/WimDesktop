using DMMDigital.Models;

namespace DMMDigital.Interface.IRepository
{
    public interface ISensorRepository
    {
        SensorModel getSensorByName(string name);
    }
}
