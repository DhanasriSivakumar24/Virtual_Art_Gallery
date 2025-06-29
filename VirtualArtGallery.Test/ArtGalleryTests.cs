using NUnit.Framework;
using VirtualArtGallery.Dao;
using VirtualArtGallery.Entity;

namespace VirtualArtGallery.Test
{
    public class ArtGalleryTests
    {
        IVirtualArtGallery repository = new VirtualArtGalleryRepo();
        [Test]
        public void Test_To_Add_New_Artwork()
        {
            Artwork artwork = new Artwork()
            {
                ArtistId = 5,
                ArtworkTitle = "Campbell",
                ArtworkDescription = "A pop Art piece featuring 32 soup cans",
                ArtworkId = 9,
                CreationDate= new DateTime(2023, 12, 25),
                Medium = "Polymer Paint",
                ImageUrl= "https://Artwork/art9.jpg"
            };
            repository.AddArtwork(artwork);
            Assert.That(artwork.ArtistId, Is.EqualTo(5));
        }

        [Test]
        public void Test_To_Update_Artwork()
        {
            Artwork artwork = new Artwork()
            {
                ArtistId = 5,
                ArtworkTitle = "Water Lilies",
                ArtworkDescription = "A series of approximately 250 paintings",
                ArtworkId = 6,
                CreationDate= new DateTime(1916, 01, 01),
                Medium = "Oil Painting",
                ImageUrl = "https://monet.com/art6.jpg"
            };
            bool updateStatus = repository.UpdateArtwork(artwork);
            Assert.That(updateStatus, Is.True);
        }


        [Test]
        [Ignore("It is deleted in the first testing itself")]
        public void Test_To_Remove_Artwork()
        {
            Artwork artwork = new Artwork()
            {
                ArtworkId = 7
            };
            bool updateStatus = repository.RemoveArtwork(artwork.ArtworkId);
            Assert.That(updateStatus, Is.True);
        }

        [Test]
        public void Test_To_Search_Artwork()
        {
            string keyword = "Starry";
            List<Artwork> result = repository.SearchArtworks(keyword);
            bool matchfound = false;
            foreach (Artwork artwork in result) 
            {
                if(result.Contains(artwork)) 
                { 
                    matchfound = true; 
                    break; 
                }
            }
            Assert.That(matchfound,Is.True);
        }

        [Test]
        [Ignore("It is Added in the first testing itself")]
        public void Test_To_Add_Gallery()
        {
            Gallery gallery = new Gallery()
            {
                GalleryId = 4,
                GalleryName = "Abc Gallery",
                GalleryLocation = "Bombay",
                Description = "Gallery based on English Literature ",
                Curator = 6,
                OpeningHours = "5:00am - 4:00pm"
            };
            bool addgallery =repository.AddGallery(gallery);
            Assert.That(addgallery, Is.True);
        }

        [Test]
        public void Test_To_Update_Gallery()
        {
            Gallery gallery = new Gallery()
            {
                GalleryId = 4,
                GalleryName = "ABC Gallery",
                GalleryLocation = "Bombay",
                Description = "Gallery based on English Literature ",
                Curator = 6,
                OpeningHours = "5:00am - 4:00pm"
            };
            bool updateGallery = repository.UpdateGallery(gallery);
            Assert.That(updateGallery, Is.True);
        }

        [Test]
        public void Test_To_Search_Gallery()
        {
            string keyword = "Abc";
            List<Gallery> result = repository.SearchGallery(keyword);
            bool matchfound = false;
            foreach (Gallery gallery in result)
            {
                if (result.Contains(gallery))
                {
                    matchfound = true;
                    break;
                }
            }
            Assert.That(matchfound, Is.True);
        }

        [Test]
        public void Test_To_Remove_Gallery()
        {
            Gallery gallery = new Gallery()
            {
                GalleryId = 1
            };
            bool updateStatus = repository.RemoveGallery(gallery.GalleryId);
            Assert.That(updateStatus, Is.True);
        }
    }
}
