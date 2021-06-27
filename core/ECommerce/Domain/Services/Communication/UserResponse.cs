using System;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; private set; }
        
        public UserResponse(string message, bool success, User user) : base(message, success)
        {
            User = user;
        }

        public UserResponse(User user): this(String.Empty, true, user)
        {
            
        }

        public UserResponse(string message) : this(message, false, null)
        {
            
        }

    }
}