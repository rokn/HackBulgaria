using HackTrain.Common;

namespace HackTrain.Views
{
	public interface IRegisterView
	{
		void RegisterUser();
		void CloseRegistration();
		void MarkErrors(RegisterErrors regErrors);
		string GetConfirmPass();
	}
}
