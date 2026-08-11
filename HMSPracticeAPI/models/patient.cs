using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HMSPracticeAPI.Models
{
    public class Patient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string PatientId { get; set; } = string.Empty; // e.g. PAT-0001

        public bool IsUnknownPatient { get; set; } = false;

        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;

        public string RelativeType { get; set; } = string.Empty;
        public string RelativeName { get; set; } = string.Empty;

        public string MobileNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public string Religion { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string PatientCondition { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;

        public string IdProofType { get; set; } = string.Empty;
        public string IdProofDetails { get; set; } = string.Empty;

        public string BloodGroup { get; set; } = string.Empty;
        public string EmergencyPhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PatientCategory { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}