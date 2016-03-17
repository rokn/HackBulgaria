﻿using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using HackTrain.Common;

namespace HackTrainDBAccess
{
	

    public class UserAccess
    {
	    private readonly HackTrainsEntities _context;

	    public UserAccess()
	    {
			_context = new HackTrainsEntities();
	    }

	    public RegisterErrors Register(User newUser)
	    {
			var errors = RegisterErrors.None;

			if(_context.Users.Any(user => user.Username == newUser.Username))
			{
				errors |= RegisterErrors.UsernameTaken;
			}

			if(_context.Users.Any(user => user.Email == newUser.Email))
			{
				errors |= RegisterErrors.EmailTaken;
			}

		    if (errors == RegisterErrors.None)
		    {
			    _context.Users.Add(newUser);
			    try
			    {
				    _context.SaveChanges();
			    }
			    catch (DbUpdateException)
			    {
					errors |= RegisterErrors.DataBaseError;
				}
			    catch (DbEntityValidationException)
			    {
					errors |= RegisterErrors.DataBaseError;
				}
		    }

			return errors;
		}


    }
}
