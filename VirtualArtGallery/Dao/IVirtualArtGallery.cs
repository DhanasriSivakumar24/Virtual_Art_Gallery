using VirtualArtGallery.Entity;

namespace VirtualArtGallery.Dao
{
    public interface IVirtualArtGallery
    {
        // Artwork Management 
        public bool AddArtwork(Artwork artwork); //Completed
        public bool UpdateArtwork(Artwork artwork); //Completed
        public bool RemoveArtwork(int artworkID);//Completed
        public Artwork GetArtworkById(int artworkID);//Completed
        public List<Artwork>SearchArtworks(string name);//Completed 

        // User Favorites 
        public bool AddArtworkToFavorite(int userId, int artworkId);//Completed
        public bool RemoveArtworkFromFavorite(int userId, int artworkId);//Completed
        public bool GetUserFavoriteArtworks(int userId); //Completed

        //Gallery Management
        public bool AddGallery(Gallery artwork);//Completed
        public bool UpdateGallery(Gallery artwork);//Completed
        public bool RemoveGallery(int galleryID);//Completed
        public List<Gallery> SearchGallery(string galleryName);
    }
}
