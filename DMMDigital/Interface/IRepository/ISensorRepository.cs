using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface.IRepository
{
    public interface ISensorRepository
    {
        List<SensorModel> getAllSensors();
    }
}
