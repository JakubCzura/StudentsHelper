namespace StudentsHelper.Model
{
    internal interface IUser
    {
        string Login { get; set; }
        string Password { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string SecondName { get; set; }
        int Age { get; set; }
    }
}