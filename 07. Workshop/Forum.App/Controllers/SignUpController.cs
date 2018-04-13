namespace Forum.App.Controllers
{
	using Forum.App;
	using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using System;

    public class SignUpController : IController, IReadUserInfoController
	{
		private const string DETAILS_ERROR = "Invalid Username or Password!";
		private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string ErrorMessage { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        
        public enum SignUpStatus
        {
            Success, DetailsError, UsernameTakenError
        }

        private enum Command
        {
            ReadUsername, ReadPassword, SignUp, Back
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Signup;

                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Signup;

                case Command.SignUp:
                    var signedUp = UserService.TrySignUpUser(this.Username, this.Password);
                    switch (signedUp)
                    {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;

                        case SignUpStatus.DetailsError:
                            ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;

                        case SignUpStatus.UsernameTakenError:
                            ErrorMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.Error;
                         
                    }
                    return MenuState.Error;

                case Command.Back:
                    ResetSignUp();
                    return MenuState.Back;

                default:
                    throw new InvalidOperationException();
            }
        }

        public IView GetView(string userName)
        {
            return new SignUpView(this.ErrorMessage);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ResetSignUp()
        {
            this.Username = string.Empty;
            this.ErrorMessage = string.Empty;
            this.Password = string.Empty;
        }
    }
}
