namespace Safari_Management.Entities;

[Serializable] // Marcar a classe como serializável
class Section
{
    public string Name { get; set; }

    public Section() { }
    public Section(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
