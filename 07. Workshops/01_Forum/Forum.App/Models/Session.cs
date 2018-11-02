﻿namespace Forum.App.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;
	using DataModels;

	public class Session : ISession
	{
	    private User user;
	    private Stack<IMenu> history;

	    public Session()
	    {
	        this.history = new Stack<IMenu>();
	    }

		public string Username => this.user?.Username;

		public int UserId => this.user?.Id ?? 0;

		public bool IsLoggedIn => this.user != null;

		public IMenu CurrentMenu => this.history.Peek();

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
