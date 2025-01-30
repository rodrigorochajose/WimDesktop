using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
{
    [Table("CONFIG")]
    public class ConfigModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("LANGUAGE")]
        public string language { get; set; }

        [Column("SENSOR_PATH")]
        public string sensorPath { get; set; }

        [Column("EXAM_PATH")]
        public string examPath { get; set; }

        [Column("EXPORT_PATH")]
        public string exportPath { get; set; }

        [Column("SENSOR_MODEL")]
        public string sensorModel { get; set; }

        [Column("ACQUIRE_MODE")]
        public int acquireMode { get; set; }

        [Column("DRAWING_COLOR")]
        public string drawingColor { get; set; }

        [Column("DRAWING_SIZE")]
        public int drawingSize { get; set; }

        [Column("TEXT_COLOR")]
        public string textColor { get; set; }

        [Column("TEXT_SIZE")]
        public int textSize { get; set; }

        [Column("RULER_COLOR")]
        public string rulerColor { get; set; }

        [Column("FILTER_BRIGHTNESS")]
        public float brightness { get; set; }

        [Column("FILTER_CONTRAST")]
        public float contrast { get; set; }

        [Column("FILTER_REVEAL")]
        public float reveal { get; set; }

        [Column("FILTER_SMART_SHARPEN")]
        public float smartSharpen { get; set; }
    }

    public class ConfigModelMap : ClassMap<ConfigModel>
    {
        public ConfigModelMap()
        {
            Map(m => m.id).Name("ID");
            Map(m => m.language).Name("LANGUAGE");
            Map(m => m.sensorPath).Name("SENSOR_PATH");
            Map(m => m.examPath).Name("EXAM_PATH");
            Map(m => m.sensorModel).Name("SENSOR_MODEL");
            Map(m => m.acquireMode).Name("ACQUIRE_MODE");
            Map(m => m.drawingColor).Name("DRAWING_COLOR");
            Map(m => m.drawingSize).Name("DRAWING_SIZE");
            Map(m => m.textColor).Name("TEXT_COLOR");
            Map(m => m.textSize).Name("TEXT_SIZE");
            Map(m => m.rulerColor).Name("RULER_COLOR");
            Map(m => m.brightness).Name("FILTER_BRIGHTNESS");
            Map(m => m.contrast).Name("FILTER_CONTRAST");
            Map(m => m.reveal).Name("FILTER_REVEAL");
            Map(m => m.smartSharpen).Name("FILTER_SMART_SHARPEN");
        }
    }
}
