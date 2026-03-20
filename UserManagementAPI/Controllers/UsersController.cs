using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // In-memory storage for demonstration purposes
        private static List<User> users = new()
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 30 },
            new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Age = 28 }
        };

        private static int nextId = 3;

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(users);
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User object if found</returns>
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {id} not found" });
            }
            return Ok(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">User object to create</param>
        /// <returns>Created user object</returns>
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            // Validation is handled by model validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.Id = nextId++;
            users.Add(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="updatedUser">Updated user object</param>
        /// <returns>Updated user object</returns>
        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {id} not found" });
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Age = updatedUser.Age;

            return Ok(user);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {id} not found" });
            }

            users.Remove(user);
            return NoContent();
        }
    }
}
