namespace VirtualArtGallery.Entity
{
    public class Artwork
    {
        //Attributes of the Artwork
        int artworkId;
        string artTitle;
        string artDescription;
        DateTime creationDate;
        string medium;
        string imageUrl;
        int artistId;

        //Getter and Setter Property
        public int ArtworkId
        {
            get { return artworkId; }
            set { artworkId = value; }
        }
        public string ArtworkTitle
        {
            get { return artTitle; }
            set { artTitle = value; }
        }
        public string ArtworkDescription
        {
            get { return artDescription; }
            set { artDescription = value; }
        }
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        public string Medium
        {
            get { return medium; }
            set { medium = value; }
        }
        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }
        public int ArtistId
        {
            get { return artistId; }
            set { artistId = value; }
        }

        //Default Constructor
        public Artwork() 
        { 

        }
        //Parametrized Constructor
        public Artwork(int id, string title, string description, DateTime date,string medium, string url, int artistId)
        {
            artworkId = id;
            artTitle = title;
            artDescription = description;
            creationDate = date;
            Medium = medium;
            ImageUrl = url;
            ArtistId = artistId;
        }

        public override string ToString()
        {
            return $" ArtworkId = {artworkId}\n Title = {artTitle}\n Description = {artDescription}\n CreationDate = {creationDate}\n Medium = {Medium}\n ImageUrl = {ImageUrl}\n ArtistId = {ArtistId}";
        }
    }
}
