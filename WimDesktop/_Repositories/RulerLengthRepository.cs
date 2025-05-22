using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop._Repositories
{
    public class RulerLengthRepository : IRulerLengthRepository
    {
        private readonly Context context = new Context();

        public void addRulerLength(List<RulerLengthModel> rulerLengths)
        {
            try
            {
                context.rulerLength.AddRange(rulerLengths);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteRangeRulerLength(List<int> drawingsId)
        {
            try
            {
                IEnumerable<RulerLengthModel> rulerLengthsToDelete = drawingsId.SelectMany(drawingId => getModelByDrawing(drawingId));

                context.rulerLength.RemoveRange(rulerLengthsToDelete);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<float> getRulerLengthByDrawing(int drawingId)
        {
            return context.rulerLength.Where(rl => rl.examImageDrawingId == drawingId).ToList().Select(rl => rl.lineLength).ToList();
        }

        private IEnumerable<RulerLengthModel> getModelByDrawing(int drawingId)
        {
            return context.rulerLength.Where(rl => rl.examImageDrawingId == drawingId);
        }
    }
}
