
using WimDesktop.Models;
using System;
using System.Collections.Generic;

namespace WimDesktop.Interface.IView
{
    public interface IMigrationDatabaseView
    {
        string software { get; set; }
        List<PatientModel> patients { get; set; }
        List<ExamModel> exams { get; set; }
        List<ExamImageModel> examImages { get; set; }
        List<ExamImageCDR> examImagesCDR { get; set; }
        PatientModel patientToImport { get; set; }
        ExamModel examToImport { get; set; }
        List<ExamImageModel> examImagesToImport { get; set; }
        SettingsModel settingsToImport { get; set; }
        bool duplicatedPatient { get; set; }


        event EventHandler eventImportPatient;
        event EventHandler eventImportExam;
        event EventHandler eventImportExamImages;
        event EventHandler eventImportSettings;
        event EventHandler eventGetDataToImport;
    }

    public class ExamImageCDR
    {
        public string uid { get; set; }
        public int id { get; set; }
        public int examId { get; set; }
        public int order { get; set; }
        public int templateFrameId { get; set; }
        public string file { get; set; }
        public string notes { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
