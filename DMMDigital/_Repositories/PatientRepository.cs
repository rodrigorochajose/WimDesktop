using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Context context = new Context();

        public void addPatient(PatientModel patient)
        {
            try
            {
                context.patient.Add(patient);
                context.SaveChanges();

                Directory.CreateDirectory(@"C:\Users\USER\.novowimdesktop\img\Paciente-" + patient.id);

                MessageBox.Show("Paciente cadastrado com sucesso !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void editPatient()
        {
            try
            {
                context.SaveChanges();
                MessageBox.Show("As informações do paciente foram editadas com sucesso !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deletePatient(int patientId)
        {
            try
            {
                context.patient.Remove(getPatientById(patientId));
                context.SaveChanges();

                MessageBox.Show("Paciente deletado com sucesso !");
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IEnumerable<PatientModel> getAllPatients()
        {
            return context.patient;
        }

        public PatientModel getPatientById(int patientId)
        {
            return context.patient.Single(p => p.id == patientId);
        }

        public IEnumerable<PatientModel> getPatientsByName(string value)
        {
            return context.patient.Where(p => p.name.ToLower().Contains(value.ToLower()));
        }
       
    }
}
