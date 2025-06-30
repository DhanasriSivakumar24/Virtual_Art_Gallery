namespace VirtualArtGallery.Entity
{
    public class ArtworkGallery
    {
        int artworkId;
        int galleryId;

        public int ArtworkId
        {
            get { return artworkId; }
            set { artworkId = value; }
        }
        public int GalleryId
        {
            get { return galleryId; }
            set { galleryId = value; }
        }
        public ArtworkGallery() 
        { 
        
        }
        public ArtworkGallery(int artworkId, int galleryId)
        {
            ArtworkId = artworkId;
            GalleryId = galleryId;
        }
        public override string ToString()
        {
            return $"ArtworkID= {ArtworkId}\t GalleryID: {GalleryId}";
        }
    }
}
