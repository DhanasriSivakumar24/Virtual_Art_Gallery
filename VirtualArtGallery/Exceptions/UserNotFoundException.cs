﻿
namespace VirtualArtGallery.Exceptions
{
    internal class UserNotFoundException:ApplicationException
    {
        public UserNotFoundException()
        {
            
        }
        public UserNotFoundException(string message):base(message)
        {
            
        }
    }
}
