namespace exercise.wwwapi.DTO
{
    public class UserResponseDTO
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
    }
}
