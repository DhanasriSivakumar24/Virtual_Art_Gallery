using System.Data.SqlClient;
using VirtualArtGallery.Entity;
using VirtualArtGallery.Exceptions;
using VirtualArtGallery.Utility;

namespace VirtualArtGallery.Dao
{
    internal class VirtualArtGalleryRepo : IVirtualArtGallery
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        //Declaring a objects as List
         List<Artwork> artworks;
         List<UserFavoriteArtwork> userFavorites;

        //Object Initiallization in Constructor
        public VirtualArtGalleryRepo()
        {
            //sqlConnection = new SqlConnection("Server= LAPTOP-HUOM74K1;Database=Virtual_Art_Gallery;Trusted_connection =True");
            //sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            sqlConnection = DbConnUtil.GetConnectionObject();
            cmd = new SqlCommand();

            artworks = new List<Artwork>();
            {
                new Artwork() { ArtworkId = 1, ArtworkTitle = "Starry Nights", ArtworkDescription = "Vincent Van Gough Masterpiece", CreationDate = DateTime.Now, ImageUrl = "https://StarryNights.jpeg", Medium = "Starry Nights" };
            }
            userFavorites = new List<UserFavoriteArtwork>()
            {
                new UserFavoriteArtwork() { UserId=1001,ArtworkId=1 }
            };
        }

        //AddArtwork
        public bool AddArtwork(Artwork artwork)
        {
            try
            {
                Artwork artworks = new Artwork();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "insert into Artwork values (@ArtworkID,@Title,@Description,@CreationDate,@Medium,@Url,@ArtistId)";
                    cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkId);
                    cmd.Parameters.AddWithValue("@Title", artwork.ArtworkTitle);
                    cmd.Parameters.AddWithValue("@Description", artwork.ArtworkDescription);
                    cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                    cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                    cmd.Parameters.AddWithValue("@Url", artwork.ImageUrl);
                    cmd.Parameters.AddWithValue("@ArtistId", artwork.ArtistId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                        return true;
                    else
                        throw new ArtWorkNotFoundException($"The ArtworkId is not added.. ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove Artwork by Id : {ex.Message}");
                return false;
            }
        }

        //RemoveArtwork
        public bool RemoveArtwork(int artworkID)
        {
            try
            {
                Artwork artworks = new Artwork();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "delete * from Artwork where ArtworkId = @artworkId";
                    cmd.Parameters.RemoveAt(artworkID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                        return true;
                    else
                        throw new ArtWorkNotFoundException($"The ArtworkId is not found.. Please Check the ID {artworkID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove Artwork by Id : {ex.Message}");
                return false;
            }
        }
        //UpdateArtwork
        public bool UpdateArtwork(Artwork artwork)
        {
            for (int i = 0; i<artworks.Count; i++)
            {
                if (artworks[i].ArtworkId == artwork.ArtworkId)
                {
                    artworks[i] = artwork;
                    return true;
                }
            }
            throw new ArtWorkNotFoundException($"The Artwork is not found.. Please Check the Artwork {artwork}");
        }

        //GetArtworkById
        public Artwork GetArtworkById(int artworkID)
        {
            Artwork artworks = new Artwork();
            using (sqlConnection = DbConnUtil.GetConnectionObject())
            {
                cmd.CommandText = "select * from Artwork where ArtworkId = @artworkId";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artwork artwork = new Artwork();
                    artwork.ArtworkId = (int)reader["ArtworkId"];
                    artwork.ArtworkTitle = (string)reader["Title"];
                    artwork.ArtworkDescription = (string)reader["Description"];
                    artwork.Medium = (string)reader["Medium"];
                    artwork.ImageUrl = (string)reader["ImageUrl"];
                    artwork.CreationDate = (DateTime)reader["CreationDate"];
                }
            }
            return artworks;
        }

        //SearchArtworks
        public List<Artwork> SearchArtworks(string name)//
        {
            
            throw new ArtWorkNotFoundException($"The Artwork is not found.. Please Check the Artwork {name}");
        //
        }

        //AddArtworkToFavorite
        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            if (userId != 0 || artworkId != 0)
            {
                userFavorites.Add(new UserFavoriteArtwork { UserId = userId, ArtworkId = artworkId });
                return true;
            }
            throw new ArtWorkNotFoundException($"The ArtworkId or UserId is not found.. Please Check the ID {artworkId} or {userId}");
        }

        //GetUserFavoriteArtworks
        public List<Artwork> GetUserFavoriteArtworks(int userId)
        {
            if (userId != null) 
            {
                List<UserFavoriteArtwork> result = new List<UserFavoriteArtwork>();
                foreach (UserFavoriteArtwork fa in userFavorites)
                {
                    if (fa.UserId == userId)
                    {
                        foreach (Artwork artwork in artworks)
                        {
                            if (fa.ArtworkId == artwork.ArtworkId)
                            {
                                result.Add(fa);
                            }
                        }
                    }
                }
            }
            throw new UserNotFoundException($"The UserId is not found.. Please Check the UserID {userId}");
        }

        //RemoveArtworkFromFavorite
        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            for(int i=0;i<userFavorites.Count;i++ )
            {
                if(userFavorites[i].UserId == userId && userFavorites[i].ArtworkId == artworkId)
                {
                    userFavorites.RemoveAt(i);
                    return true;
                }
            }
            throw new ArtWorkNotFoundException($"The ArtworkId or UserId is not found.. Please Check the ID {artworkId} or {userId}");
        }
    }
}
