namespace Saga_Pattern.Queries
{
    public class AppointmentQueries
    {
        public const string GetAllAppointment = @"
            SELECT *
            FROM appointments";

        public const string GetAppointmentById = @"
            SELECT *
            FROM appointments
            WHERE appointment_id = @appointment_id";
    }
}
