using DMMDigital.Forms;
using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMMDigital._Repositories
{
    public class PatientRepository : IPatientRepository
    {
        Contexto<PatientModel> context = new Contexto<PatientModel>();

        public string add(PatientModel patient)
        {
            try
            {
                context.tabela.Add(patient);
                context.SaveChanges();

                Directory.CreateDirectory(@"C:\Users\USER\.novowimdesktop\img\Paciente-" + patient.id);
                return "Paciente cadastrado com sucesso !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string edit(PatientModel paciente)
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
                context.tabela.Remove(context.tabela.Single(p => p.id == patientId));
                context.SaveChanges();
                return "Paciente Removido com sucesso !";
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IEnumerable<PatientModel> getAllPatients()
        {
            return context.tabela;
        }

        public PatientModel getPatientById(int patientId)
        {
            return context.tabela.Single(p => p.id == patientId);
        }

        public IEnumerable<PatientModel> getPatientsByName(string value)
        {
            return context.tabela.Where(p => p.name.ToLower().Contains(value.ToLower()));
        }
       
    }
}
