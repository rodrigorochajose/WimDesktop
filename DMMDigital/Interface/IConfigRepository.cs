using DMMDigital.Models;

namespace DMMDigital.Interface
{
    public interface IConfigRepository
    {
        string save();
        ConfigModel getAllConfig();
        string getExamPath();
    }
}
