
namespace VirtualArtGallery.Entity
{
    internal class Gallery
    {
        int galleryId;
        string galleryName;
        string description;
        string galleryLocation;
        int curator;
        DateTime openingHours;

        public int GalleryId
        { 
            get { return galleryId; }
            set { galleryId = value; } 
        }
        public string GalleryName
        {
            get { return galleryName; }
            set { galleryName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string GalleryLocation
        { 
            get { return galleryLocation; } 
            set { galleryLocation = value; } 
        }
        public int Curator
        {
            get { return curator; }
            set { curator = value; }
        }
        public DateTime OpeningHours
        {
            get { return openingHours; }
            set { openingHours = value; }
        }

        public Gallery() 
        {
        
        }
        public Gallery(int galleryId, string galleryName, string description, string galleryLocation, int curator, DateTime openingHours)
        {
            GalleryId = galleryId;
            GalleryName = galleryName;
            Description = description;
            GalleryLocation = galleryLocation;
            Curator = curator;
            OpeningHours = openingHours;
        }
        public override string ToString()
        {
            return $"GalleryID= {GalleryId}\t Name= {GalleryName}\t Description= {Description}\t Location= {GalleryLocation}\t CuratorID= {Curator}\t  OpeningHours= {OpeningHours}";
        }
    }
}
