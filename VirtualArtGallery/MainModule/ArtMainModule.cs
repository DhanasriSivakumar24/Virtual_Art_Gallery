using VirtualArtGallery.Dao;
using VirtualArtGallery.Entity;


namespace VirtualArtGallery.MainModule
{
    public class ArtMainModule
    {
        IVirtualArtGallery _virtualArtGallery = new VirtualArtGalleryRepo();
        public void Run()
        {
            int ch = 0;
            while (ch != 5)
            {
                Console.WriteLine("\n==== Welcome to Virtual Art Gallery ====");
                Console.WriteLine("\n--- Virtual Art Gallery Menu---");
                Console.WriteLine("\t1. Artwork Management ");
                Console.WriteLine("\t2. Personal Gallery");
                Console.WriteLine("\t3. Gallery Management");
                Console.WriteLine("\t4. Exit");
                Console.Write("\nEnter your choice: ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        ArtworkManagement();             
                        break;
                    case 2:
                        PersonalGallery();
                        break;
                    case 3:
                        GalleryManagement();
                        break;
                    case 4:
                        Console.WriteLine("\nThank you for visiting the Virtual Art Gallery.!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.. Please try again..!");
                        break;
                }
            } 
        }
        void ArtworkManagement()
        {
            int ch = 0;
            while (ch != 7)
            {
                Console.WriteLine("\n==== Welcome to Artwork Management ====");
                Console.WriteLine("\n--- Artwork Management Menu---");
                Console.WriteLine("\t1. Add Artwork");
                Console.WriteLine("\t2. Remove Artwork by ID");
                Console.WriteLine("\t3. View Artwork by ID");
                Console.WriteLine("\t4. Search Artworks by Title");
                Console.WriteLine("\t5. Update Artwork");
                Console.WriteLine("\t6. Exit");
                Console.Write("\nEnter your choice: ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddArtwork();
                        break;
                    case 2:
                        RemoveArtworkById();
                        break;
                    case 3:
                        GetArtworkById();
                        break;
                    case 4:
                        SearchArtworkByTitle();
                        break;
                    case 5:
                        UpdateArtworkById();
                        break;
                    case 6:
                        Console.WriteLine("\nThank you for visiting the Artwork Management.!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.. Please try again..!");
                        break;
                }
            }
        }

        #region Artwork Management
        void AddArtwork()
        {
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
            artwork.ImageUrl = Console.ReadLine();
            Console.WriteLine($"Enter the ArtistId: ");
            artwork.ArtistId = Convert.ToInt32(Console.ReadLine());
            _virtualArtGallery.AddArtwork(artwork);
        }

        void RemoveArtworkById()
        {
            Console.WriteLine("\n\t---- 2. Remove Artwork by ID ----");
            Console.WriteLine("\nEnter The Artwork ID");
            int removeArtworkById = Convert.ToInt32(Console.ReadLine());
            try
            {
                bool removed = _virtualArtGallery.RemoveArtwork(removeArtworkById);
                if(removed)
                    Console.WriteLine("Artwork is removed succesfully");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        void GetArtworkById()
        {
            Console.WriteLine("\n\t---- 3. View Artwork by ID ----");
            Console.WriteLine("\nEnter The Artwork ID");
            int getArtworkById = Convert.ToInt32(Console.ReadLine());
            Artwork artwork = _virtualArtGallery.GetArtworkById(getArtworkById);
            if (artwork != null)
            {
                Console.WriteLine("\t\n--- Artwork Details ---");
                Console.WriteLine($"ID:             {artwork.ArtworkId}");
                Console.WriteLine($"Title:          {artwork.ArtworkTitle}");
                Console.WriteLine($"Description:    {artwork.ArtworkDescription}");
                Console.WriteLine($"Medium:         {artwork.Medium}");
                Console.WriteLine($"Image URL:      {artwork.ImageUrl}");
                Console.WriteLine($"Creation Date:  {artwork.CreationDate}");
            }
            else
            {
                Console.WriteLine("Artwork Not Found");
            }
        }

        void SearchArtworkByTitle()
        {
            Console.WriteLine("\n\t---- 4. Search Artworks by Title ----");
            Console.WriteLine("\nEnter The Artwork Title");
            string keyWord = Console.ReadLine();
            List<Artwork> artwork = _virtualArtGallery.SearchArtworks(keyWord);
            if (artwork.Count > 0)
            {
                Console.WriteLine("--- Matched Artworks ---");
                foreach (Artwork item in artwork)
                {
                    Console.WriteLine($"\n{item}");
                }
            }
            else
            {
                Console.WriteLine("No Artwork Found Containing this Keyword");
            }
        }

        void UpdateArtworkById()
        {
            Console.WriteLine("\n\t---- 5. Update Artwork ----");
            Console.WriteLine("\nEnter The Artwork ID");
            int artworkId = Convert.ToInt32(Console.ReadLine());
            Artwork artwork = new Artwork();
            artwork.ArtworkId = artworkId;
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
            _virtualArtGallery.UpdateArtwork(artwork);
        }
        #endregion

        void PersonalGallery()
        {
            int ch = 0;
            while (ch != 5)
            {
                Console.WriteLine("\n==== Welcome to Personal Gallery ====");
                Console.WriteLine("\n--- Personal Gallery Menu---");
                Console.WriteLine("\t1. Add Artwork to Favourite");
                Console.WriteLine("\t2. Remove Artwork from Favourite");
                Console.WriteLine("\t3. View User's Favourite Artwork ");
                Console.WriteLine("\t4. Exit");
                Console.Write("\nEnter your choice: ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddUserFavArtwork();
                        break;
                    case 2:
                        RemoveFavouriteArtwork();
                        break;
                    case 3:
                        GetUserFavouriteArtwork();
                        break;
                    case 4:
                        Console.WriteLine("\nThank you for visiting the Personal Gallery.!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.. Please try again..!");
                        break;
                }
            }
        }

        #region Personal Gallery
        void AddUserFavArtwork()
        {
            Console.WriteLine("\n\t---- 1. Add favourite Artwork ----");
            Console.WriteLine("\nEnter The User ID");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter your favourite Artwork ID");
            int userFavArtworkId = Convert.ToInt32(Console.ReadLine());
            UserFavoriteArtwork artwork = new UserFavoriteArtwork();
            artwork.ArtworkId = userFavArtworkId;
            artwork.UserId = userId;
            _virtualArtGallery.AddArtworkToFavorite(userId, userFavArtworkId);
        }
        void RemoveFavouriteArtwork()
        {
            Console.WriteLine("\n\t---- 2. Remove Artwork from Favorites ----");
            Console.WriteLine("\nEnter The User ID");
            int removeuserId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter your favourite Artwork ID");
            int removeArtworkId = Convert.ToInt32(Console.ReadLine());
            try
            {
                bool removed = _virtualArtGallery.RemoveArtworkFromFavorite(removeuserId, removeArtworkId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        void GetUserFavouriteArtwork()
        {
            Console.WriteLine("\n\t---- 3. View Artwork by ID ----");
            Console.WriteLine("\nEnter The User Id");
            int userIdForFavourites = Convert.ToInt32(Console.ReadLine());
            bool artwork = _virtualArtGallery.GetUserFavoriteArtworks(userIdForFavourites);
        }
        #endregion

        void GalleryManagement()
        {
            int ch = 0;
            while (ch != 5)
            {
                Console.WriteLine("\n==== Welcome to Gallery Management ====");
                Console.WriteLine("\n--- Gallery Management Menu---");
                Console.WriteLine("\t1. Add Gallery");
                Console.WriteLine("\t2. Remove Gallery by ID");
                Console.WriteLine("\t3. Search Gallery By Name");
                Console.WriteLine("\t4. Update Gallery");
                Console.WriteLine("\t5. Exit");
                Console.Write("\nEnter your choice: ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddGallery();
                        break;
                    case 2:
                        RemoveGalleryById();
                        break;
                    case 3:
                        SearchGalleryByName();
                        break;
                    case 4:
                        UpdateGallery();
                        break;
                    case 5:
                        Console.WriteLine("\nThank you for visiting the Gallery Management.!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.. Please try again..!");
                        break;
                }
            }
        }

        #region GalleryManagement
        void AddGallery()
        {
            Console.WriteLine("\n\t---- 1. Add Gallery ----");
            Gallery gallery = new Gallery();
            Console.Write("Enter Gallery ID: ");
            gallery.GalleryId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Gallery Name: ");
            gallery.GalleryName = Console.ReadLine();
            Console.Write("Enter Gallery Description: ");
            gallery.Description = Console.ReadLine();
            Console.Write("Enter Location: ");
            gallery.GalleryLocation = Console.ReadLine();
            Console.Write("Enter Curator Artist ID: ");
            gallery.Curator = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Opening Hours: ");
            gallery.OpeningHours =Console.ReadLine();
            _virtualArtGallery.AddGallery(gallery);
       
        }

        void UpdateGallery()
        {
            Console.WriteLine("\n\t---- 4. Update Gallery ----");
            Console.Write("Enter Gallery ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Gallery gallery = new Gallery();
            gallery.GalleryId = id;
            Console.Write("Enter Gallery Name: ");
            gallery.GalleryName = Console.ReadLine();
            Console.Write("Enter Description: ");
            gallery.Description = Console.ReadLine();
            Console.Write("Enter Location: ");
            gallery.GalleryLocation = Console.ReadLine();
            Console.Write("Enter Curator Artist ID: ");
            gallery.Curator = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Opening Hours: ");
            gallery.OpeningHours = Console.ReadLine();
            _virtualArtGallery.UpdateGallery(gallery);
        }

        void RemoveGalleryById()
        {
            Console.WriteLine("\n\t---- 2. Remove Gallery by ID ----");
            Console.Write("Enter Gallery ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                bool removed = _virtualArtGallery.RemoveGallery(id);
                if(removed)
                    Console.WriteLine("Gallery Removed Successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            
        }

        void SearchGalleryByName()
        {
            Console.WriteLine("\n\t---- Search Galleries by Name ----");
            Console.Write("\nEnter keyword: ");
            string keyword = Console.ReadLine();
            List<Gallery> gallery = _virtualArtGallery.SearchGallery(keyword);
            if (gallery.Count > 0)
            {
                Console.WriteLine("--- Matched Artworks ---");
                foreach (Gallery item in gallery)
                {
                    Console.WriteLine($"\n{item}");
                }
            }
            else
            {
                Console.WriteLine("No Gallery Found Containing this Keyword");
            }
        }
        #endregion
    }
}
