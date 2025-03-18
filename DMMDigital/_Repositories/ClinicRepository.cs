using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Properties;
using System;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly Context context = new Context();

        public void addClinic(ClinicModel clinic)
        {
            try
            {
                context.clinic.Add(clinic);
                context.SaveChanges();

                MessageBox.Show(Resources.messageCreateSuccess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updatePassword(string email, string password)
        {
            try
            {
                ClinicModel clinic = context.clinic.FirstOrDefault(c => c.email == email);

                if (clinic == null)
                {
                    MessageBox.Show(Resources.messageEmailNotFound);
                    return;
                }

                clinic.password = password;
                context.SaveChanges();

                MessageBox.Show(Resources.messagePasswordUpdated);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void updateConnectedInfo(bool keepConnected)
        {
            try
            {
                int value = keepConnected ? 1 : 0;
                context.clinic.FirstOrDefault().keepConnected = value;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ClinicModel getClinicByEmail(string email)
        {
            return context.clinic.AsNoTracking().FirstOrDefault(c => c.email == email);
        }

        public bool hasClinic()
        {
            return context.clinic.Any();
        }

        public bool keepConnected()
        {
            ClinicModel clinic = context.clinic.FirstOrDefault();
            bool value = false;

            if (clinic != null)
            {
                value = clinic.keepConnected == 0 ? false : true;
            }
            return value;
        }
    }
}
