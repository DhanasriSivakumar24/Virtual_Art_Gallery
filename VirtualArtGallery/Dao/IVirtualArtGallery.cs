using VirtualArtGallery.Entity;

namespace VirtualArtGallery.Dao
{
    public interface IVirtualArtGallery
    {
        // Artwork Management 
        public bool AddArtwork(Artwork artwork);
        public bool UpdateArtwork(Artwork artwork);
        public bool RemoveArtwork(int artworkID);
        public Artwork GetArtworkById(int artworkID);
        public List<Artwork>SearchArtworks(string name);

        // User Favorites 
        public bool AddArtworkToFavorite(int userId, int artworkId);
        public bool RemoveArtworkFromFavorite(int userId, int artworkId);
        public bool GetUserFavoriteArtworks(int userId); 

        //Gallery Management
        public bool AddGallery(Gallery artwork);
        public bool UpdateGallery(Gallery artwork);
        public bool RemoveGallery(int galleryID);
        public List<Gallery> SearchGallery(string galleryName);
    }
}
