using WimDesktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop
{
    public class FormManager
    {
        private static readonly Lazy<FormManager> lazy = new Lazy<FormManager>(() => new FormManager());
        public static FormManager instance => lazy.Value;

        private readonly Dictionary<Type, Form> openForms;

        public FormManager()
        {
            openForms = new Dictionary<Type, Form>();
        }

        public void openForm<T>(Func<object> createPresenter) where T : Form
        {
            Type formType = typeof(T);

            if (openForms.ContainsKey(formType))
            {
                openForms[formType].BringToFront();
            }
            else
            {
                var presenter = createPresenter();
                var form = ((dynamic)presenter).view as Form;

                form.FormClosed += (s, args) => openForms.Remove(formType);
                openForms[formType] = form;

                form.Show();
            }
        }

        public void closeAllExceptExamAndMenu()
        {
            List<Form> forms = Application.OpenForms.Cast<Form>().ToList();

            for (int counter = 0; counter < forms.Count; counter++)
            {
                Type formType = forms[counter].GetType();

                if (formType == typeof(MenuView))
                {
                    forms[counter].Hide();
                    continue;
                }

                if (formType == typeof(ExamContainerView)) continue;

                if (formType == typeof(ExamView)) continue;
                
                forms[counter].Close();
            }
        }

        public void unhideMainForm()
        {
            Application.OpenForms.Cast<Form>().First().Show();
        }

        public void closeAllForms()
        {
            List<Form> forms = Application.OpenForms.Cast<Form>().ToList();

            for (int counter = 0; counter < forms.Count; counter++)
            {
                forms[counter].Close();
            }
        }
    }
}
