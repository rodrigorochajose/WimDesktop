using DMMDigital.Models;

namespace DMMDigital.Interface.IRepository
{
    public interface IConfigRepository
    {
        string save();
        ConfigModel getAllConfig();
        string getSensorPath();
        string getSensorModel();
        string getExamPath();
        float[] getFiltersValues();
        string getLanguage();
        void importConfig(ConfigModel config);
    }
}
