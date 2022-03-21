namespace StudentsHelper.Model
{
    internal interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string SecondName { get; set; }
        int Age { get; set; }
    }
}