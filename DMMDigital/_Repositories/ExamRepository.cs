using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly Context context = new Context();

        public void addExam(ExamModel exam)
        {
            try
            {
                context.exam.Add(exam);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var errorMessages = dbEx.EntityValidationErrors
                    .SelectMany(e => e.ValidationErrors)
                    .Select(e => $"Property: {e.PropertyName} Error: {e.ErrorMessage}");

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = $"Validation failed: {fullErrorMessage}";

                MessageBox.Show(exceptionMessage);
            }
        }

        public void deleteExam(int examId)
        {
            try
            {
                context.exam.Remove(getExam(examId));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int getExamId(ExamModel exam)
        {
            return context.exam.OrderByDescending(e => e.id).First().id;
        }

        public ExamModel getExam(int examId)
        {
            return context.exam.Where(e => e.id == examId).Include(e => e.patient).Include(e => e.template).First();
        }

        public IEnumerable<ExamModel> getPatientExams(int patientId)
        {
            return context.exam.Where(e => e.patientId == patientId).Include(e => e.template).AsNoTracking().ToList();
        }

        public bool examHasImages(int examId)
        {
            ExamModel exam = context.exam.FirstOrDefault(e => e.id == examId);
            return exam.examImages.Any();
        }

        public void updateExamTemplate(int examId, int templateId)
        {
            try
            {
                ExamModel exam = context.exam.FirstOrDefault(e => e.id == examId);

                if (exam != null)
                {
                    exam.templateId = templateId;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateExamLastChange(int examId)
        {
            try
            {
                ExamModel exam = context.exam.FirstOrDefault(e => e.id == examId);

                exam.updatedAt = DateTime.Now;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool patientHasExams(int patientId)
        {
            return context.exam.Any(e => e.patientId == patientId);
        }
    }
}
