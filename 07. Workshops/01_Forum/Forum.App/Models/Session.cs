namespace Forum.App.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;
	using DataModels;

	public class Session : ISession
	{
	    private User user;
	    private Stack<IMenu> history;


		public string Username => throw new System.NotImplementedException();

		public int UserId => throw new System.NotImplementedException();

		public bool IsLoggedIn => throw new System.NotImplementedException();

		public IMenu CurrentMenu => throw new System.NotImplementedException();

		public IMenu Back()
		{
			throw new System.NotImplementedException();
		}

		public void LogIn(User user)
		{
			throw new System.NotImplementedException();
		}

		public void LogOut()
		{
			throw new System.NotImplementedException();
		}

		public bool PushView(IMenu view)
		{
			throw new System.NotImplementedException();
		}

		public void Reset()
		{
			throw new System.NotImplementedException();
		}
	}
}
