using System;

namespace Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool Completed { get; set; }
        public Patient Patient { get; set; }
        public Operation Operation { get; set; }

        public Appointment(DateTime time, Patient patient, Operation operation)
        {
            Time = time;
            Patient = patient;
            Operation = operation;
        }

        public override string ToString()
        {
            return $"{Operation.Code} - {Operation.Name} \n {Patient.FullName}";
        }
    }
}
