namespace IO_refactoring
{
    class User
    {
        internal string? FirstName { get; set; }
        internal string? LastName { get; set; }
        internal string? Email { get; set; }
        internal UserRoles Role { get; set; } = UserRoles.Regular;
        internal virtual Basket? Basket { get; set; }

    }
}