using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using WimDesktop.Models.Dto;
using WimDesktop.Properties;

namespace WimDesktop._Repositories
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

                MessageBox.Show(Resources.messagePatientCreated);
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
                MessageBox.Show(Resources.messagePatientEdited);
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

                MessageBox.Show(Resources.messagePatientDeleted);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<PatientDataToListDto> getAllPatientsDataToList()
        {
            return context.patient.Select(p => new PatientDataToListDto
            {
                id = p.id,
                name = p.name
            }).ToList();
        }

        public PatientModel getPatientById(int patientId)
        {
            return context.patient.Single(p => p.id == patientId);
        }

        public List<PatientDataToListDto> getPatientsByName(string value)
        {
            return context.patient.Where(p => p.name.ToLower().Contains(value.ToLower())).Select(p => new PatientDataToListDto { id = p.id, name = p.name }).ToList();
        }

        public void importPatient (PatientModel patient)
        {
            try
            {
                context.patient.Add(patient);
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
       
    }
}
