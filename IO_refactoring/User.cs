﻿namespace IO_refactoring
{
    class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public UserRoles Role { get; set; }
        public Basket? Basket { get; set; }
        
    }
}
