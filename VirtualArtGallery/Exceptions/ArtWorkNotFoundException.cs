namespace VirtualArtGallery.Exceptions
{
    internal class ArtWorkNotFoundException:ApplicationException
    {
        public ArtWorkNotFoundException()
        {
            
        }
        public ArtWorkNotFoundException(string message):base(message)
        {
            
        }
    }
}
