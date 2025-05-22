using WimDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WimDesktop.Components;
using WimDesktop.Interface.IRepository;
using System.Windows;
using WimDesktop.Properties;

namespace WimDesktop._Repositories
{
    public class TemplateFrameRepository : ITemplateFrameRepository
    {
        private readonly Context context = new Context();

        public void addTemplateFrame(int templateId, List<Frame> frames)
        {
            try
            {
                foreach (Frame frame in frames)
                {
                    context.templateFrame.Add(new TemplateFrameModel
                    {
                        templateId = templateId,
                        locationX = frame.Location.X,
                        locationY = frame.Location.Y,
                        orientation = frame.orientation,
                        order = frame.order
                    });
                }
                context.SaveChanges();

                MessageBox.Show(Resources.messageTemplateFrameSucess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<TemplateFrameModel> getAllTemplateFrame()
        {
            return context.templateFrame.ToList();
        }

        public List<TemplateFrameModel> getTemplateFrame(int templateId)
        {
            return context.templateFrame.Where(t => t.templateId == templateId).ToList();
        }
    }
}
