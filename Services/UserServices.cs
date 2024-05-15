using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Models.DTO;
using PrometoFoodTrucksBackEnds.Services.Context;

namespace PrometoFoodTrucksBackEnds.Services
{
    public class UserServices: ControllerBase
    {
        private readonly DataContext _context;

        public UserServices(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string Username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == Username) != null;
        }
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            bool result = false;

            if(!DoesUserExist(UserToAdd.Username)){
                UserModel newUser = new UserModel();

                var hashPassword = HashPassword(UserToAdd.Password);
                newUser.UserID = UserToAdd.ID;
                newUser.Username = UserToAdd.Username;
                
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;

                _context.Add(newUser);
                result = _context.SaveChanges() != 0;



                result = true;
            }
            return result;  
        //return _data.AddUser(UserToAdd);
        }

        // public void FoodTrucksWithUser(int userId, int FoodTrucksID)
        // {
        //     var user = _context.UserInfo.SingleOrDefault(user => user.UserID == userId);
        //     var FoodTruck = _context.TruckInfos.SingleOrDefault(truck => truck.ID == FoodTrucksID);
        //     if(user != null && FoodTruck != null){
        //         if(user.FoodTrucksItems == null)
        //         {
        //         user.FoodTrucksItems = new List<FoodTrucksIteamsModel>();
        //         }
        //         user.FoodTrucksItems.Add(FoodTruck);
        //         _context.SaveChanges();
        //     }
        // }

        // public void RemoveFoodTruckFromUser(int userId)
        // {
        //     var user = _context.UserInfo.SingleOrDefault(user => user.UserID == userId);
        //     if(user != null){
        //         user.FoodTrucksItems = null;
        //         _context.SaveChanges();
        //     }
        // }

        public PasswordDTO HashPassword(string password){

            PasswordDTO newHashPassword = new PasswordDTO();

            byte[] SaltByte = new byte[64];


            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            provider.GetNonZeroBytes(SaltByte);

            string salt = Convert.ToBase64String(SaltByte);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);

            string hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashPassword.Salt = salt;
            newHashPassword.Hash = hash;
            return newHashPassword;
        }

        public bool VerifyUsersPassword(string? password, string? storedHash, string? storedSalt){

            byte[] SaltByte = Convert.FromBase64String(storedSalt);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);

            string newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == storedHash;

        }
        
        public IActionResult Login(LoginDTO User)
        {
            IActionResult Result = Unauthorized();

            // Check if user exists
            if (DoesUserExist(User.Username))
            {
                // If user exists, this will evaluate to true. If true, continue with authentication
                // If true, we need to store our user object
                // To do this, we need to create another helper function

                UserModel foundUser = GetUserByUsername(User.Username);

                // This will check if our password is correct
                if (VerifyUsersPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {

                    // anyone with this secretKey can access the login
                    // Think of this as a Costco membership. You can only get into Costco if you have a membership. This is the same thing
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

                    // Sign in credentials
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    // Generates a new token and signs a user out after 30 minutes
                    // issuer and audience is a local port for our jwt token
                    // Once you deploy, you will remove that port and add in your Azure front end URL!
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(), // Claims can be added here if needed
                        expires: DateTime.Now.AddMinutes(30), // Set token expiration time (e.g., 30 minutes)
                        signingCredentials: signinCredentials // Set signing credentials
                    );

                    // Generate JWT token as a string
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    // return JWT token through http response with status code 200
                    Result = Ok(new { Token = tokenString });
                }

            }

            return Result;
        }


        public UserModel GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }


        public bool UpdateUser(UserModel userToUpdate)
        {
            // This updates the UserModel for the user that we want to update
            _context.Update<UserModel>(userToUpdate);

            // Whenever we make a change, we return a number (probably 1). Otherwise, we return a 0
            // 
            return _context.SaveChanges() != 0;
        }


        public bool UpdateUsername(int id, string username)
        {
            // Sending over just the id and username
            // We have to get the object to be updated
            // To do this, we need yet another helper function

            UserModel foundUser = GetUserById(id);

            bool result = false;

            if (foundUser != null)
            {
                // If we found a user, execute this code
                // Update founderUser object
                foundUser.Username = username;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }

            return result;
        }

        public UserModel GetUserById(int id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.UserID == id);
        }


        public bool DeleteUser(string userToDelete)
        {
            // We are only sending over the username
            // If username found, delete user

            UserModel foundUser = GetUserByUsername(userToDelete);

            bool result = false;

            if (foundUser != null)
            {
                // If we have found a user

                _context.Remove<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }

            return result;
        }

        public UserIdDTO GetUserIdDTOByUsername(string username)
        {
            UserIdDTO UserInfo = new UserIdDTO();

            // Now we need to query through our database to find the user based on the name inside the database
            UserModel foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);

            UserInfo.UserId = foundUser.UserID;

            // Assign the 
            UserInfo.PublisherName = foundUser.Username;

            return UserInfo;
        }
    }
}