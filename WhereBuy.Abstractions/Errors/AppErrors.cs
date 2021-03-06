namespace WhereBuy.Common.Errors
{
    public static class AppErrors
    {
        public static readonly AppError UserNotFound = new(101, "User not found");
        public static readonly AppError WrongPassword = new(102, "Wrong password");
        public static readonly AppNotFoundError NotFound = new(103, "Not found");
        public static readonly AppEntityExistsError EntityExists = new(104, "Entity already exists");
        public static readonly AppError WrongVerificationCode = new(105, "Wrong verification code");
        public static readonly AppError EmailIsNotConfirmed = new(105, "Email is not confirmed");
    }
}
