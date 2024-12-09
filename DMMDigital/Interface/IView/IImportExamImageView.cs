using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Interface.IView
{
    public interface IImportExamImageView
    {
        int patientId { get; set;  }
        int examId { get; set; }
        List<ExamModel> exams { get; set; }
        List<string> imageFiles { get; set; }

        event EventHandler eventGetExamImages;

        void setExamList(BindingSource examList);

        List<Image> getSelectedImages();
    }
}
