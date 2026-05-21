namespace Saga_Pattern.Queries
{
    public static class PatientQueries
    {
        public const string GetAllPatients = @"
            SELECT *
            FROM patients";

        public const string GetPatientById = @"
            SELECT *
            FROM patients
            WHERE id = @Id";
    }
}
