using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class ExamRepository : IExamRepository
    {
        Context<ExamModel> context = new Context<ExamModel>();

        public void add(ExamModel exam)
        {
            try
            {
                context.tabela.Add(exam);
                context.SaveChanges();

            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        public string delete(int examId)
        {
            try
            {
                context.tabela.Remove(context.tabela.Single(e => e.id == examId));
                context.SaveChanges();
                return "Exame deletado com sucesso !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public IEnumerable<ExamModel> selectExamsByPatient(int patientId)
        {
            return context.tabela.Where(e => e.patientId == patientId);
        }
    }
}
