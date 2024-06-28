namespace KraevedAPI.Constants
{
    /// <summary>
    /// Service Constants to hold static values
    /// </summary>
    public static class ServiceConstants
    {
        public static class Exception {
            public const string NotFound = "Not found";
            public const string CreatedObjectNotFound = "Created object not found";
            public const string UnknownError = "Unknown error";
            public const string ObjectEqualsNull = "Object equals null";
            public const string ObjectExists = "Object exists";
            public const string GeoObjectTypeNotFound = "GeoObjectType not found";
            public const string GeoObjectTypeIsNull = "GeoObjectType is null";
            public const string FileIsEmpty = "File is empty";
            public const string WrongExtension = "Extension is not allowed";
            public const string InvalidPhoneNumber = "Invalid phone number";
            public const string InvalidSmsCode = "Invalid confirmation code";
            public const string ManyLoginAttempts = "Too many login attempts";
            public const string InvalidSecretKey = "Invalid secret key";
            public const string UserNotFound = "User not found";
            public const string InvalidPassword = "Invalid password";
            public const string AuthorisationError = "Authorisation error";
            public const string PasswordErrorSpaces = "The password cannot be empty or contain spaces";
            public const string EmptyStringValue = "Value cannot be empty or whitespace only string";
            public const string SmsServiceError = "Sms service error";
        }
    }
}
