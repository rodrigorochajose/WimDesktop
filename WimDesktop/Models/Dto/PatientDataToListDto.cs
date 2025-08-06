using System;
namespace WimDesktop.Models.Dto
{
    public class PatientDataToListDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? lastChange { get; set; }
    }
}
