using DMMDigital.Interface;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DMMDigital.Components;

namespace DMMDigital._Repositories
{
    public class TemplateFrameRepository : ITemplateFrameRepository
    {
        private readonly Context context = new Context();

        public string add(int templateId, IList<Frame> framesList)
        {
            try
            {
                foreach (Frame frame in framesList)
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
                return "Template cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
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
