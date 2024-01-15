using DMMDigital.Interface;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly Context context = new Context();

        public int add(ExamModel exam)
        {
            try
            {
                context.exam.Add(exam);
                context.SaveChanges();
                return context.exam.OrderByDescending(e => e.id).First().id;
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public void edit(ExamModel exam)
        {
            try
            {
                context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public OperationStatus delete(int examId)
        {
            try
            {
                context.exam.Remove(context.exam.Single(e => e.id == examId));
                context.SaveChanges();

                return new OperationStatus
                {
                    code = 1,
                    status = "Sucess",
                    message = "Exame deletado!"
                };
            }
            catch (Exception ex)
            {
                return new OperationStatus
                {
                    code = -1,
                    status = "Error",
                    message = "Erro ao deletar exame : " + ex.Message
                };
            }
        }

        public IEnumerable<ExamModel> getPatientExams(int patientId)
        {
            return context.exam.Where(e => e.patientId == patientId).Include(e => e.template).ToList();
        }

        public ExamModel getExam(int examId)
        {
            return context.exam.Where(e => e.id == examId).Include(e => e.patient).Include(e => e.template).First();
        }
    }
}
