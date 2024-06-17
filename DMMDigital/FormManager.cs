using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DMMDigital
{
    public class FormManager
    {
        private static readonly Lazy<FormManager> lazy = new Lazy<FormManager>(() => new FormManager());

        public static FormManager instance => lazy.Value;

        private readonly Dictionary<string, Form> openForms;

        public FormManager()
        {
            openForms = new Dictionary<string, Form>();
        }

        public void showForm(string formKey, Func<object> createPresenter)
        {
            if (openForms.ContainsKey(formKey))
            {
                openForms[formKey].BringToFront();
            }
            else
            {
                var presenter = createPresenter();
                var form = ((dynamic)presenter).view as Form;
                form.FormClosed += (s, args) => openForms.Remove(formKey);
                openForms[formKey] = form;
                form.Show();
            }
        }
    }
}
