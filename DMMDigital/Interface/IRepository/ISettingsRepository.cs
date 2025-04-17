using DMMDigital.Models;

namespace DMMDigital.Interface.IRepository
{
    public interface ISettingsRepository
    {
        string save();
        SettingsModel getAllSettings();
        string getSensorPath();
        string getSensorModel();
        int getAcquireMode();
        string getExamPath();
        float[] getFiltersValues();
        string getLanguage();
        void importSettings(SettingsModel settings);
        void saveExportPath(string path);
        string getExportPath();
        void updateWaterMark(bool waterMark);
        bool getWaterMark();
    }
}
