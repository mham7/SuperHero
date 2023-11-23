namespace Backend.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Power { get; set; } = string.Empty;

        //public byte[] ImageData { get; set; }  // Add this property for image data


        public SuperHero() { }
    }
}
