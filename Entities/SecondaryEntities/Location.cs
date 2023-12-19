namespace Safari_Management.Entities.SecondaryEntities

{
    [Serializable] // Marcar a classe como serializável
    class Location
    {
        public string Name { get; set; }

        public Location() { }
        public Location(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
