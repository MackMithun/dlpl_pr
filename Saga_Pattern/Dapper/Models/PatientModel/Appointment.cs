namespace Saga_Pattern.Dapper.Models.PatientModel
{
    public class Appointment
    {
        public int Appointment_ID { get; set; }   
        public int Patient_ID { get; set; } 
        public int CC_ID { get; set; }  
        public DateTime Appointment_Date { get; set; }  
        public string Status { get; set; }     

    }
}
