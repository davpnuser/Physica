namespace Physica.Interfaces
{
    public interface IPipeline
    {
        public string Name { get; set; }
        void Draw();
    }
}
