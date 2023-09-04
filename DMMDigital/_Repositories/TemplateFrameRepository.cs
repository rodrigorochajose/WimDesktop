using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class TemplateFrameRepository : ITemplateFrameRepository
    {
        Contexto<TemplateFrameModel> context = new Contexto<TemplateFrameModel>();

        public string add(int templateId, IList<Frame> framesList)
        {
            try
            {
                foreach (Frame frame in framesList)
                {
                    context.tabela.Add(new TemplateFrameModel
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
            return context.tabela.ToList();
        }
    }
}
