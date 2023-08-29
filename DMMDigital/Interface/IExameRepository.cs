using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital.Modelos
{
    public interface IExameRepository
    {
        void adicionar(ExamModel exame);
        void editar(ExamModel exame);
        void deletar(int id);
        IEnumerable<PatientModel> selecionarExamePorPaciente(int value);
    }
}
