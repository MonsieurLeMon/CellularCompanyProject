namespace Common.Models
{
    public class ValidationResult
    {
        public bool Result { get; private set; }
        public string Description { get; private set; }

        public ValidationResult(bool result, string description)
        {
            Result = result;
            Description = description;
        }
    }
}
