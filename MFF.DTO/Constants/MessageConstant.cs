namespace MFF.DTO.Constants
{
    public class MessageConstant
    {
        public const string UNAUTHORIZED = "UnAuthorized";
        public const string NOT_FOUND = "NotFound";
        public const string BAD_ARGRUMENT = "BadArgument";
        public const string FORBIDDEN = "Forbidden";
        public const string INTERNAL_SERVER = "InternalServer";
        public const string UNSPECIFIED = "Unspecified";

        public const string SUCCESS_RESPONSE = "This operation has been completed successfully";
        public const string ERROR_RESPONSE = "This operation could not be completed";
        public const string NOT_FOUND_RESPONSE = "This item could not be found";
        public const string INTERNAL_ERROR = "Server error. Please contact admin to support";
        public const string FORBIDDEN_ERROR = "You don't have permission to perform this action";

        public const string POST_NOT_FOUND = "This post could not be found";
        public const string POST_NOT_UPDATE_FAILED = "This post could not be updated";
        public const string POST_NOT_DELETE_FAILED = "This post could not be deleted";

        public const string PASSWORD_REQUIRED = "Password is required";
        public const string PASSWORD_OLD_WRONG = "Current password wrong";
        public const string PASSWORD_FORGOT_SUCCESS = "Forgot password successfully";
        public const string PASSWORD_UPDATE_SUCCESS = "Your password has been updated";
        public const string PASSWORD_CHANGE_SUCCESS = "Change password successfully";

        public const string ACCOUNT_LOGIN_FAILED = "Wrong username or password";

        public const string FILE_NOT_FOUND = "No file to upload";
        public const string FILE_EMPTY = "File is empty";

        public const string NOT_FOUND_Product_RESPONSE = "This Product could not be found";
        public const string NOT_FOUND_FEEDBACK_RESPONSE = "This feedback could not be found";

        public const string USER_USERNAME_ALREADY_EXIST = "Username already exist";
        public const string USER_EMAIL_ALREADY_EXIST = "Email already exist";
        public const string USER_PHONENUMBER_ALREADY_EXIST = "Phone number already exist";
        public const string USER_CREATE_FAILED = "Could not create new user";
        public const string USER_UPDATE_FAILED = "Could not update user";
        public const string USER_DELETE_FAILED = "Could not delete user";
        public const string USER_NOT_FOUND = "User could not be found";


        public const string EMAIL_IS_REQUIRED = "Email is required";
        public const string EMAIL_NOT_FOUND = "This email could not be found";
        public const string EMAIL_INVALID_FORMAT = "Email invalid format";
        public const string PASSWORD_INVALID_FORMAT = "Password invalid format";

        public const string RESET_PASSWORD_TOKEN_REQUIRED = "Token is required";
        public const string RESET_PASSWORD_NEW_PASSWORD_REQUIRED = "New password is required";
        public const string RESET_PASSWORD_FAILED = "Could not reset password, please try again";
        public const string RESET_PASSWORD_TOKEN_EXPIRED = "Token has been expired. Please try again";

        public const string CHANGE_PASSWORD_OLD_PASSWORD_REQUIRED = "Old password is required";
        public const string CHANGE_PASSWORD_NEW_PASSWORD_REQUIRED = "New password is required";
        public const string CHANGE_PASSWORD_OLD_PASSWORD_WRONG = "Old password invalid";
        public const string CHANGE_PASSWORD_FAILED = "Could not change password";

        public const string PROFILE_UPDATE_FAILED = "Could not update profile";

        public const string ALIAS_NAME_EXISTS = "The Alias Name already exists. Please Choose a different site alias";
    }
}
