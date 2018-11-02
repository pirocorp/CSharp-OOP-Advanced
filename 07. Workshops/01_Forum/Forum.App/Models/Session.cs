﻿namespace Forum.App.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
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
		    if (this.history.Count > 1)
		    {
		        this.history.Pop();
		    }

		    var previousMenu = this.history.Peek();
            previousMenu.Open();

		    return previousMenu;
		}

		public void LogIn(User currentUser)
		{
		    this.user = currentUser;
		}

		public void LogOut()
		{
		    this.user = null;
		}

		public bool PushView(IMenu view)
		{
		    if (this.history.Any() || this.history.Peek() != view)
		    {
                this.history.Push(view);
		        return true;
		    }

		    return false;
		}

		public void Reset()
		{
			this.history = new Stack<IMenu>();
		    this.user = null;
		}
	}
}
