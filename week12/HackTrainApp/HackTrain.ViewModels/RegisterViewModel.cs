using HackTrain.Views;
using HackTrainDBAccess;

namespace HackTrain.ViewModels
{
    public class RegisterViewModel
    {
	    private readonly IRegisterView _view;
	    private readonly UserAccess _userAccess;

	    public RegisterViewModel(IRegisterView view)
	    {
		    _view = view;
			_userAccess = new UserAccess();
		}

	    public void RegisterUser(User user)
	    {
		    
	    }
    }
}
