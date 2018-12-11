using Common.Models;

namespace Common.Validations
{
    public class ValidateStringInput
    {
        private ValidationResult result;

        #region Rules
        private int phoneNumberLength = 10;
        private int nameMinLength = 2;
        private int nameMaxLength = 50;
        private int passwordMinLength = 5;
        private int addressMinLength = 10;
        private int addressMaxLength = 50;
        private int usernameMinLength = 2;
        private int usernameMaxLength = 20;
        private int emailMinLength = 7;
        #endregion

        #region Messeges
        string tooShortMessage = "input too short";
        string tooLongMessage = "input too long";
        string lengthOk = "input length legal";
        string inputOk = "input is legal";
        string inputillegal = "input has letters or special chars in it";
        string nullOrEmpty = "input is null or empty";
        #endregion

        #region FirstName LastName validations
        public ValidationResult ValidateNameLength(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int length = input.Length;

                if (length < nameMinLength)
                    return result = new ValidationResult(false, tooShortMessage);
                else if (length > nameMaxLength)
                    return result = new ValidationResult(false, tooLongMessage);
                else
                    return result = new ValidationResult(true, lengthOk);
            }
            else
                return result = new ValidationResult(false, nullOrEmpty);
        }
        #endregion

        #region Phone Number Validations
        public ValidationResult ValidatePhoneNumberLength(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int length = input.Length;

                if (length < phoneNumberLength)
                    return result = new ValidationResult(false, tooShortMessage);
                else if (length > phoneNumberLength)
                    return result = new ValidationResult(false, tooLongMessage);
                else
                    return result = new ValidationResult(true, lengthOk);
            }
            else
                return result = new ValidationResult(false, nullOrEmpty);
        }

        public ValidationResult ValidatePhoneNumberInput(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int tmp;
                foreach (var c in input)
                {
                    if (!int.TryParse(c.ToString(), out tmp))
                        return result = new ValidationResult(false, inputillegal);
                }
                return result = new ValidationResult(true, inputOk);
            }
            else
                return result = new ValidationResult(false, nullOrEmpty);
        }
        #endregion

        #region Username Validations
        public ValidationResult ValidateUsernameLength(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int length = input.Length;

                if (length < usernameMinLength)
                    return result = new ValidationResult(false, tooShortMessage);
                else if (length > usernameMaxLength)
                    return result = new ValidationResult(false, tooLongMessage);
                else
                    return result = new ValidationResult(true, lengthOk);
            }
            else
                return result = new ValidationResult(false, nullOrEmpty);
        }
        #endregion

        #region Password Validations
        public ValidationResult ValidatePasswordLength(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int length = input.Length;

                if (length < passwordMinLength)
                    return result = new ValidationResult(false, tooShortMessage);
                else
                    return result = new ValidationResult(true, lengthOk);
            }
            else
                return result = new ValidationResult(false, nullOrEmpty);
        }
        #endregion

        #region Address Validations
        public ValidationResult ValidateAddressLength(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int length = input.Length;

                if (length < addressMinLength)
                    return result = new ValidationResult(false, tooShortMessage);
                else if (length > addressMaxLength)
                    return result = new ValidationResult(false, tooLongMessage);
                else
                    return result = new ValidationResult(true, lengthOk);
            }
            else
                return result = new ValidationResult(false, nullOrEmpty);
        }
        #endregion

        #region Email Validations
        public ValidationResult ValidateEmailLength(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int length = input.Length;

                if (length < emailMinLength)
                    return result = new ValidationResult(false, tooShortMessage);
                else
                    return result = new ValidationResult(true, lengthOk);
            }
            else
                return result = new ValidationResult(false, nullOrEmpty);
        }

        public ValidationResult ValidateEmailInput(string input) //unfinished
        {


            return null;
        }
        #endregion
    }
}
