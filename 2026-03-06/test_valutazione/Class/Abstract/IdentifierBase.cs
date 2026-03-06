abstract class IdentifierBase
{
    private int _id;
    public int Id { get => _id; set => _id = value; }

    public IdentifierBase(int id) { Id = id; }
}