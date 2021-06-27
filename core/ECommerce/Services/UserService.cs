using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Domain.Services.Communication;

namespace ECommerce.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnityOfWork _unityOfWork;
        
        public UserService(IUserRepository userRepository, IUnityOfWork unityOfWork)
        {
            _userRepository = userRepository;
            _unityOfWork = unityOfWork;
        }
        
        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unityOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            try
            {
                var _user = await _userRepository.FindByIdAsync(id);

                if (_user == null) return new UserResponse($"this user not found by id {id}");

                _user.Name = user.Name;
                _user.Email = user.Email;
                _user.Password = user.Password;
              
                _userRepository.Update(_user);
                await _unityOfWork.CompleteAsync();
                return new UserResponse(_user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred {e.Message}");
            }
            
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            try
            {
                var user = await _userRepository.FindByIdAsync(id);
                if (user == null) return new UserResponse($"this user doesn't exists by id {id}");
                
                _userRepository.Delete(user);
                await _unityOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occured {e.Message}");
            }
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<User> FirstOrDefaultAsync(string email, string password)
        {
            return await _userRepository.FirstOrDefaultAsync(email, password);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
    }
}
