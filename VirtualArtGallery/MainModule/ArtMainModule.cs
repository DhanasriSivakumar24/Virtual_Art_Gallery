using VirtualArtGallery.Dao;
using VirtualArtGallery.Entity;

namespace VirtualArtGallery.MainModule
{
    internal class ArtMainModule
    {
        public void Run()
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            int ch = 0;
            while (ch != 7)
            {
                Console.WriteLine("\n==== Welcome to Virtual Art Gallery ====");
                Console.WriteLine("\n--- Virtual Art Gallery Menu---");
                Console.WriteLine("\t1. Add Artwork");
                Console.WriteLine("\t2. Remove Artwork by ID");
                Console.WriteLine("\t3. View Artwork by ID");
                Console.WriteLine("\t4. Search Artworks by Title");
                Console.WriteLine("\t5. Add Artwork to Favorites");
                Console.WriteLine("\t6. View Favorite Artworks");
                Console.WriteLine("\t7. Exit");
                Console.Write("\nEnter your choice: ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddArtwork();                        
                        break;
                    case 2:
                        Console.WriteLine("\n\t---- 2. Remove Artwork by ID ----");
                        Console.WriteLine("\nEnter The Artwork ID");
                        int removeArtworkById = Convert.ToInt32(Console.ReadLine());
                        RemoveArtworkById(removeArtworkById);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.. Please try again..!");
                        break;
                }
            }
        }

        void AddArtwork()
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            Console.WriteLine("\n\t---- 1.Add Artwork ----");
            Artwork artwork = new Artwork();
            Console.WriteLine($"Enter the ArtworkID: ");
            artwork.ArtworkId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter the Artwork Title: ");
            artwork.ArtworkTitle = Console.ReadLine();
            Console.WriteLine($"Enter the Artwork Description: ");
            artwork.ArtworkDescription = Console.ReadLine();
            artwork.CreationDate = DateTime.Now;
            Console.WriteLine($"Enter the Medium: ");
            artwork.Medium = Console.ReadLine();
            Console.WriteLine($"Enter the Image Url: ");
            artwork.ImageUrl= Console.ReadLine();
            Console.WriteLine($"Enter the ArtistId: ");
            artwork.ArtistId = Convert.ToInt32(Console.ReadLine());
            virtualArtGallery.AddArtwork(artwork);
            Console.WriteLine($"\n Your Artwork has been added Sucessfully..!");
        }
        void RemoveArtworkById(int id)
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            Artwork artwork = new Artwork();
            bool removed = virtualArtGallery.RemoveArtwork(id);
        }
    }
}
