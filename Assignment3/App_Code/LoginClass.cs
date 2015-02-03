﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LoginClass
{
    private string pass;
    private string username;
    private int seed;
    private byte[] dbHash;
    private int key;
    private byte[] newHash;

	public LoginClass(string pass, string username)
	{
        this.pass = pass;
        this.username = username;
	}

    private void GetUserInfo()
    {
        ShowTrackerEntities db = new ShowTrackerEntities();

        var info = from i in db.FanLogins
                   where i.FanLoginUserName.Equals(username)
                   select new { i.FanLoginHashed, i.FanLoginRandom, i.FanKey };

        foreach(var u in info)
        {
            seed = u.FanLoginRandom;
            dbHash = u.FanLoginHashed;
            if (u.FanKey != null)
            {
                key = (int)u.FanKey; 
            }
        }
    }

    private void GetNewHash()
    {
        PasswordHash passwordHash = new PasswordHash();
        newHash = passwordHash.HashIt(pass, seed.ToString());
    }

    private bool CompareHash()
    {
        bool goodLogin = false;

        if (dbHash != null)
        {
            if (newHash.SequenceEqual(dbHash))
            {
                goodLogin = true;
            }
        }

        return goodLogin;
    }

    public int ValidateLogin()
    {
        GetUserInfo();
        GetNewHash();
        bool result = CompareHash();

        if (!result)
        {
            key = 0;
        }
        return key;
    }
}