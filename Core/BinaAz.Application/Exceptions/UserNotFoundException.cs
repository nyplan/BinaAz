﻿namespace BinaAz.Application.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Username or Password is wrong")
    {
    }
    public UserNotFoundException(string? message) : base(message)
    {
    }
    public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}