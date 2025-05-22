using WimDesktop.Models;
using System.Collections.Generic;

namespace WimDesktop.Interface.IRepository
{
    public interface ISensorRepository
    {
        List<SensorModel> getAllSensors();
    }
}
