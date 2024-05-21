using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Models.DTO;
using PrometoFoodTrucksBackEnds.Services.Context;
using static PrometoFoodTrucksBackEnds.Models.DTO.CreateAccountDTO;

namespace PrometoFoodTrucksBackEnds.Services
{
    public class UserServices: ControllerBase
    {
        private readonly DataContext _context;

        public UserServices(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }

        // public bool DoesMenuItemExist(int menuItems)
        // {
        //     return _context.MenuDTOs.SingleOrDefault(user => user.FoodTrucksID == menuItems) != null;
        // }

        public bool AddUser(CreateAccountDTO userToAdd)
        {
            bool result = false;
            if (!DoesUserExist(userToAdd.Username))
            {                   
                
                UserModel newUser = new UserModel();
                var hashPassword = HashPassword(userToAdd.Password);
                
                    newUser.UserID = userToAdd.ID;
                    newUser.Username = userToAdd.Username;
                    newUser.Category = userToAdd.Category;
                    newUser.Address = userToAdd.Category;
                    newUser.City = userToAdd.Category;
                    newUser.State = userToAdd.Category;
                    newUser.ZipCode = userToAdd.ZipCode;
                    newUser.Latitude = userToAdd.Latitude;
                    newUser.Longitude = userToAdd.Longitude;
                    newUser.Name = userToAdd.Name;
                    newUser.Image = userToAdd.Image;
                    newUser.Schedule = userToAdd.Schedule;
                    newUser.Description = userToAdd.Description;
                    newUser.IsDeleted = userToAdd.IsDeleted;
                    newUser.Rating = userToAdd.Rating;
                    newUser.itemName = userToAdd.itemName;
                    newUser.itemPrice = userToAdd.itemPrice;


                    newUser.Salt = hashPassword.Salt;
                    newUser.Hash = hashPassword.Hash;
                    

                _context.Add(newUser);
                return _context.SaveChanges() != 0;
            }
            return result; 
        }


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

             var foundUser = GetUserByUsername(userToDelete);
            if (foundUser != null)
            {
                _context.Remove(foundUser);
                return _context.SaveChanges() != 0;
            }
            return false;
        }

        public UserIdDTO GetUserIdDTOByUsername(string username)
        {
            var foundUser = _context.UserInfo.FirstOrDefault(user => user.Username == username);
            if (foundUser != null)
            {
                return new UserIdDTO { UserId = foundUser.UserID};
            }
            return null;
        }
        
        public bool AddFoodTruck(UserModel userWithFoodTruck)
        {
            _context.Add(userWithFoodTruck);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<UserModel> GetAllFoodTrucks()
        {
            return _context.UserInfo;
        }

        public string GetAllFoodTrucksAsGeoJSON()
        {
            // Your SQL query to generate GeoJSON data
            string sqlQuery = @"
                DECLARE @featureList nvarchar(max) =
                (
                SELECT
                    'Feature'                                           as 'type',
                    address                                             as 'properties.address',
                    city                                                as 'properties.city',
                    state                                               as 'properties.state',
                    zipCode                                             as 'properties.zipCode',
                    name                                                as 'properties.name',
                    image                                               as 'properties.image',
                    schedule                                            as 'properties.schedule',
                    description                                         as 'properties.description',
                    category                                            as 'properties.category',
                    isDeleted                                           as 'properties.isDeleted',
                    'Point'                                             as 'geometry.type',
                    JSON_QUERY(CONCAT('[', CAST(longitude AS decimal(18, 15)), ', ', CAST(latitude AS decimal(18, 15)), ']')) as 'geometry.coordinates'
                FROM UserInfo
                FOR JSON PATH
            )
            

                DECLARE @featureCollection nvarchar(max) = (
                    SELECT 'FeatureCollection' as 'type',
                    JSON_QUERY(@featureList)   as 'features'
                    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
                )

                SELECT @featureCollection";

            using (SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();

                string geoJSON = (string)command.ExecuteScalar();

                return geoJSON;
            }
        }


        public bool UpdateFoodTruck(UserModel userWithUpdatedFoodTruck)
        {
            _context.UserInfo.Update(userWithUpdatedFoodTruck);
            return _context.SaveChanges() != 0;
        }

        public bool DeleteFoodTruck(int userId)
        {
            var user = _context.UserInfo.Find(userId);
            if (user == null) return false;

            _context.UserInfo.Remove(user);
            return _context.SaveChanges() != 0;
        }


        // public void AddMenuForFoodTruck(int userId, UserModel.MenuItem menuToAdd)
        // {
        //     var user = _context.UserInfo.Include(u => u.menuItems).FirstOrDefault(u => u.UserID == userId);

        //     if (user != null)
        //     {
        //         if (user.menuItems == null)
        //         {
        //             user.menuItems = new List<UserModel.MenuItem>();
        //         }

        //         menuToAdd.FoodTrucksID = user.UserID; // Assuming FoodTrucksID is UserID
        //         user.menuItems.Add(menuToAdd);
        //         _context.SaveChanges();
        //     }
        //     // return false; // If truck with given id doesn't exist
        // }

        // public void DeleteMenuItem(int userId, int menuItemId)
        // {
        //     var user = _context.UserInfo.Include(u => u.menuItems).FirstOrDefault(u => u.UserID == userId);

        //     if (user != null)
        //     {
        //         var menuItemToDelete = user.menuItems.FirstOrDefault(mi => mi.itemId == menuItemId);
        //         if (menuItemToDelete != null)
        //         {
        //             user.menuItems.Remove(menuItemToDelete);
        //             _context.SaveChanges();
        //         }
        //     }
        //     // return false; // If menu item with given id doesn't exist
        // }

        // public void UpdateMenuItem(int userId, UserModel.MenuItem updateMenuItem)
        // {
        //     var user = _context.UserInfo.Include(u => u.menuItems).FirstOrDefault(u => u.UserID == userId);

        //     if (user != null)
        //     {
        //         var menuItemToUpdate = user.menuItems.FirstOrDefault(mi => mi.FoodTrucksID == updateMenuItem.itemId);
        //         if (menuItemToUpdate != null)
        //         {
        //             menuItemToUpdate.itemName = updateMenuItem.itemName;
        //             menuItemToUpdate.itemPrice = updateMenuItem.itemPrice;
        //             _context.SaveChanges();
        //         }
        //     }
        // }

    }
}