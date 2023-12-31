﻿namespace BinaAz.Application.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException() : base("Authorization error")
    {
    }
    public AuthenticationException(string? message) : base(message)
    {
    }

    public AuthenticationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}