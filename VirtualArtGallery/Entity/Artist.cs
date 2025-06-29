namespace VirtualArtGallery.Entity
{
    public class Artist
    {
        //Attributes of the Artist Class
        int artistId;
        string artistName;
        string biography;
        DateTime birthDate;
        string nationality;
        string website;
        string contactInfo;

        //Getter and Setter Properties
        public int ArtistId
        {
            get { return artistId; }
            set { artistId = value; }
        }
        public string ArtistName
        {
            get { return artistName; }
            set { artistName = value; }
        }
        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }
        public string Website
        {
            get { return website; }
            set { website = value; }
        }
        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        //Default Constructor
        public Artist()
        {

        }
        //Parameterized Constructor
        public Artist(int artistId, string artistName, string biography, DateTime birthDate, string nationality, string website, string contactInfo)
        {
            ArtistId = artistId;
            ArtistName = artistName;
            Biography = biography;
            BirthDate = birthDate;
            Nationality = nationality;
            Website = website;
            ContactInfo = contactInfo;

        }
        public override string ToString()
        {
            return $"ArtistID=     {ArtistId}\nName=         {ArtistName}\nBiography=    {Biography}\nContactInfo=  {ContactInfo}\nNationality=  {Nationality}\nBirthDate=    {BirthDate}";
        }
    }
}
