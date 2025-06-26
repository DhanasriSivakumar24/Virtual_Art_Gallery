using VirtualArtGallery.Dao;
using VirtualArtGallery.Entity;

namespace VirtualArtGallery.MainModule
{
    internal class ArtMainModule
    {
        public void Run()
        {
            int ch = 0;
            while (ch != 9)
            {
                Console.WriteLine("\n==== Welcome to Virtual Art Gallery ====");
                Console.WriteLine("\n--- Virtual Art Gallery Menu---");
                Console.WriteLine("\t1. Add Artwork");
                Console.WriteLine("\t2. Remove Artwork by ID");
                Console.WriteLine("\t3. View Artwork by ID");
                Console.WriteLine("\t4. Search Artworks by Title");
                Console.WriteLine("\t5. Update Artwork");
                Console.WriteLine("\t6. Add Artwork to Favorites");
                Console.WriteLine("\t7. Remove Artwork from Favorites");
                Console.WriteLine("\t8. Get User Favorite ArtWork");
                Console.WriteLine("\t9. Exit");
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
                    case 3:
                        Console.WriteLine("\n\t---- 3. View Artwork by ID ----");
                        Console.WriteLine("\nEnter The Artwork ID");
                        int getArtworkById = Convert.ToInt32(Console.ReadLine());
                        GetArtworkById(getArtworkById);
                        break;
                    case 4:
                        Console.WriteLine("\n\t---- 4. Search Artworks by Title ----");
                        Console.WriteLine("\nEnter The Artwork Title");
                        string keyWord = Console.ReadLine();
                        SearchArtworkByTitle(keyWord);
                        break;
                    case 5:
                        Console.WriteLine("\n\t---- 5. Update Artwork ----");
                        Console.WriteLine("\nEnter The Artwork ID");
                        int artworkId = Convert.ToInt32(Console.ReadLine());
                        UpdateArtworkById(artworkId);
                        break;
                    case 6:
                        Console.WriteLine("\n\t---- 6. Add favourite Artwork ----");
                        Console.WriteLine("\nEnter The User ID");
                        int userId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nEnter your favourite Artwork ID");
                        int userFavArtworkId = Convert.ToInt32(Console.ReadLine());
                        AddUserFavArtwork(userId, userFavArtworkId);
                        break;
                    case 7:
                        Console.WriteLine("\n\t---- 7. Remove Artwork from Favorites ----");
                        Console.WriteLine("\nEnter The User ID");
                        int removeuserId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nEnter your favourite Artwork ID");
                        int removeArtworkId = Convert.ToInt32(Console.ReadLine());
                        RemoveFavouriteArtwork(removeuserId, removeArtworkId);
                        break;
                    case 8:
                        Console.WriteLine("\n\t---- 8. View Artwork by ID ----");
                        Console.WriteLine("\nEnter The User Id");
                        int userIdForFavourites = Convert.ToInt32(Console.ReadLine());
                        GetUserFavouriteArtwork(userIdForFavourites);
                        break;
                    case 9:
                        Console.WriteLine("\nThank you for visiting the Virtual Art Gallery.!");
                        return;
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
        }
        void AddUserFavArtwork(int id1,int id2)
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            UserFavoriteArtwork artwork = new UserFavoriteArtwork();
            artwork.ArtworkId = id1;
            artwork.UserId = id2;
            virtualArtGallery.AddArtworkToFavorite(id1, id2);

        }
        void RemoveFavouriteArtwork(int id1,int id2)
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            bool removed = virtualArtGallery.RemoveArtworkFromFavorite(id1, id2);
        }
        void RemoveArtworkById(int id)
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            bool removed = virtualArtGallery.RemoveArtwork(id);
        }

        void GetArtworkById(int id)
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            Artwork artwork = virtualArtGallery.GetArtworkById(id);
            Console.WriteLine("\t\n--- Artwork Details ---");
            Console.WriteLine($"ID:             {artwork.ArtworkId}");
            Console.WriteLine($"Title:          {artwork.ArtworkTitle}");
            Console.WriteLine($"Description:    {artwork.ArtworkDescription}");
            Console.WriteLine($"Medium:         {artwork.Medium}");
            Console.WriteLine($"Image URL:      {artwork.ImageUrl}");
            Console.WriteLine($"Creation Date:  {artwork.CreationDate}");
        }
        void GetUserFavouriteArtwork(int userid)
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            bool artwork = virtualArtGallery.GetUserFavoriteArtworks(userid);
        }
        void SearchArtworkByTitle(string title)
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            List<Artwork> artwork = virtualArtGallery.SearchArtworks(title);
            if (artwork.Count >0)
            {
                Console.WriteLine("--- Matched Artworks ---");
                foreach (Artwork item in artwork)
                {
                    Console.WriteLine($"\n{item}");
                }
            }
            else
                Console.WriteLine("--- No Matched Artworks Found ---");
        }
        void UpdateArtworkById(int id)
        {
            IVirtualArtGallery virtualArtGallery = new VirtualArtGalleryRepo();
            Artwork artwork = new Artwork();
            artwork.ArtworkId = id;
            Console.WriteLine($"Enter the Artwork Title: ");
            artwork.ArtworkTitle = Console.ReadLine();
            Console.WriteLine($"Enter the Artwork Description: ");
            artwork.ArtworkDescription = Console.ReadLine();
            artwork.CreationDate = DateTime.Now;
            Console.WriteLine($"Enter the Medium: ");
            artwork.Medium = Console.ReadLine();
            Console.WriteLine($"Enter the Image Url: ");
            artwork.ImageUrl = Console.ReadLine();
            Console.WriteLine($"Enter the ArtistId: ");
            artwork.ArtistId = Convert.ToInt32(Console.ReadLine());
            virtualArtGallery.UpdateArtwork(artwork);
        }
    }
}
