using DMMDigital.Interface;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class PatientRepository : IPatientRepository
    {
        Context context = new Context();

        public string add(PatientModel patient)
        {
            try
            {
                context.patient.Add(patient);
                context.SaveChanges();

                Directory.CreateDirectory(@"C:\Users\USER\.novowimdesktop\img\Paciente-" + patient.id);
                return "Paciente cadastrado com sucesso !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string edit()
        {
            try
            {
                context.SaveChanges();
                return "Paciente editado com sucesso !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string delete(int patientId)
        {
            try
            {
                context.patient.Remove(context.patient.Single(p => p.id == patientId));
                context.SaveChanges();
                return "Paciente Removido com sucesso !";
            } catch (Exception ex)
            {
                return ex.Message;
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
