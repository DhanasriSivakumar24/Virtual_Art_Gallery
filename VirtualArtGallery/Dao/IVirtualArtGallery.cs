using System;
using VirtualArtGallery.Entity;

namespace VirtualArtGallery.Dao
{
    internal interface IVirtualArtGallery
    {
        // Artwork Management 
        bool AddArtwork(Artwork artwork); //Completed
        bool UpdateArtwork(Artwork artwork); 
        bool RemoveArtwork(int artworkID);//Completed
        Artwork GetArtworkById(int artworkID);
        List<Artwork>SearchArtworks(string name);

        // User Favorites 
        bool AddArtworkToFavorite(int userId, int artworkId);
        bool RemoveArtworkFromFavorite(int userId, int artworkId);
        List<Artwork> GetUserFavoriteArtworks(int userId);

    }
}
