using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital.Interface
{
    public interface IConfigRepository
    {
        string add(ConfigModel config);
        string edit(ConfigModel config);
        ConfigModel getAllConfig();
    }
}
