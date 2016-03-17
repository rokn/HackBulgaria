using System;

namespace HackTrain.Common
{
	[Flags]
	public enum RegisterErrors
	{
		None = 0,
		UsernameTaken = 1,
		EmailTaken = 2,
		DataBaseError = 4,
	}
}