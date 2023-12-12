using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital.Interface
{
    public interface IConfigRepository
    {
        string save();
        ConfigModel getAllConfig();
        string getExamPath();
    }
}
