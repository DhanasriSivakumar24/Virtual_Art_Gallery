
namespace VirtualArtGallery.Entity
{
    internal class UserFavoriteArtwork
    {
        int userId;
        int artworkId;
        
        public int UserId
        { 
            get { return userId; } 
            set { userId = value; } 
        }
        public int ArtworkId 
        { 
            get { return artworkId; } 
            set { artworkId = value; } 
        }
        public UserFavoriteArtwork() 
        {
        
        }
        public UserFavoriteArtwork(int userId, int artworkId)
        {
            UserId = userId;
            ArtworkId = artworkId;
        }
        public override string ToString()
        {
            return $"UserID= {UserId}\t FavoriteArtworkID: {ArtworkId}";
        }

    }
}