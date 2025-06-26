using VirtualArtGallery.Entity;

namespace VirtualArtGallery.Dao
{
    internal interface IVirtualArtGallery
    {
        // Artwork Management 
        bool AddArtwork(Artwork artwork); //Completed
        bool UpdateArtwork(Artwork artwork); //Completed
        bool RemoveArtwork(int artworkID);//Completed
        Artwork GetArtworkById(int artworkID);//Completed
        List<Artwork>SearchArtworks(string name);//Completed 

        // User Favorites 
        bool AddArtworkToFavorite(int userId, int artworkId);//Completed
        bool RemoveArtworkFromFavorite(int userId, int artworkId);//Completed
        bool GetUserFavoriteArtworks(int userId); //Completed

    }
}
