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

        public Appointment(int id, bool completed, DateTime time, Patient patient, Operation operation)
        {
            Id = id;
            Time = time;
            Patient = patient;
            Operation = operation;
            Completed = completed;
        }

        public Appointment()
        {

        }

        public override string ToString()
        {
            if(Operation.Duration.DurationInMinutes > 30)
                return $"{Operation.Code} - {Operation.Name} \n{Patient.FullName}";
            else
                return $"{Operation.Code} - {Patient.FullName}";

        }
    }
}
