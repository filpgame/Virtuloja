using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
	public string Id {
		get;
		set;
	}

	public Profile MyProfile {
		get;
		set;
	}

	public class Profile
	{
		public string Name {
			get;
			set;
		}
	}
}
