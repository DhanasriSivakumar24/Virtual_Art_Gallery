using System.Data.SqlClient;
using VirtualArtGallery.Entity;
using VirtualArtGallery.Exceptions;
using VirtualArtGallery.Utility;


namespace VirtualArtGallery.Dao
{
    public class VirtualArtGalleryRepo : IVirtualArtGallery
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public VirtualArtGalleryRepo()
        {
            cmd = new SqlCommand();
        }

        #region AddArtwork
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
                    {
                        Console.WriteLine($"\n Your Artwork has been added Successfully");
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove Artwork by Id : {ex.Message}");
                return false;
            }
        }
        #endregion

        #region RemoveArtwork
        //RemoveArtwork
        public bool RemoveArtwork(int artworkID)
        {
            try
            {
                Artwork artworks = new Artwork();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "delete from Artwork where ArtworkId = @artworkId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@artworkId", artworkID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected == 0)
                    {
                        throw new ArtWorkNotFoundException($"Artwork with ID {artworkID} not found.");
                    }
                    Console.WriteLine("\n Your Artwork has been removed successfully.");
                    return true;
                }
            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine($"Failed to remove Artwork by Id : {ex.Message}");
                return false;
            }
        }
        #endregion

        #region UpdateArtwork
        //UpdateArtwork
        public bool UpdateArtwork(Artwork artwork)
        {
            try
            {
                Artwork artworks = new Artwork();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "update Artwork set Title = @title, Description = @description, CreationDate = @creationDate, Medium = @medium, ImageUrl = @url where ArtworkId = @ArtworkId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ArtworkId", artwork.ArtworkId);
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
                    {
                        Console.WriteLine($"\n Your Artwork has been update Successfully");
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to Update Artwork by Id : {ex.Message}");
                return false;
            }
        }
        #endregion

        #region GetArtworkById
        //GetArtworkById
        public Artwork GetArtworkById(int artworkID)
        {
            try
            {
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "select * from Artwork where ArtworkId = @artworkId";
                    cmd.Parameters.AddWithValue("@artworkId", artworkID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Artwork artwork = new Artwork();
                        artwork.ArtworkId = (int)reader["ArtworkId"];
                        artwork.ArtworkTitle = (string)reader["Title"];
                        artwork.ArtworkDescription = (string)reader["Description"];
                        artwork.ImageUrl = (string)reader["ImageUrl"];
                        artwork.Medium = (string)reader["Medium"];
                        artwork.CreationDate = (DateTime)reader["CreationDate"];
                        artwork.ArtistId = (int)reader["ArtistId"];
                        return artwork;
                    }
                    return null;
                }
            }
            catch (ArtWorkNotFoundException ex)
            {
                throw new ArtWorkNotFoundException($"The ArtworkId is not found {ex.Message}");
            }
        }
        #endregion

        #region SearchArtworks
        //SearchArtworks
        public List<Artwork> SearchArtworks(string name)
        {
            try 
            {
                List<Artwork> artworks = new List<Artwork>();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    Artwork artwork = new Artwork();
                    cmd.CommandText = "select * from Artwork where title like @name";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", $"%{name}%");
                    //cmd.Parameters.AddWithValue("@name", name);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Artwork artwork1 = new Artwork();
                        artwork1.ArtworkId = (int)reader["artworkId"];
                        artwork1.ArtworkTitle = (string)reader["title"];
                        artwork1.ArtworkDescription = (string)reader["description"];
                        artwork1.ImageUrl = (string)reader["imageUrl"];
                        artwork1.Medium = (string)reader["medium"];
                        artwork1.CreationDate = (DateTime)reader["creationDate"];
                        artwork1.ArtistId = (int)reader["artistId"];
                        artworks.Add(artwork1);
                    }
                }
                return artworks;
            }
            catch(Exception ex) 
            {
                throw new Exception($"The Artwork is not found.. Please Check the Artwork");
            }
        }
        #endregion

        #region AddArtworkToFavourite
        //AddArtworkToFavorite
        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            try 
            {
                UserFavoriteArtwork userFavoriteArtworks = new UserFavoriteArtwork();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "insert into User_Favorite_Artwork values (@userId,@artworkID)";
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@artworkId", artworkId);
                    cmd.Connection = sqlConnection;
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine($"\n Your Favourite Artwork has been added Successfully");
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch(ArtWorkNotFoundException e)
            {
                throw new ArtWorkNotFoundException($"The ArtworkId or UserId is not found.. Please Check the ID {artworkId} or {userId} : {e.Message}");
            }
        }
        #endregion

        #region GetUserFavoriteArtworks
        //GetUserFavoriteArtworks
        public bool GetUserFavoriteArtworks(int userId)
        {
            try
            {
                List<Artwork> artworks = new List<Artwork>();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "select * from Artwork join User_Favorite_Artwork on Artwork.ArtworkId =User_Favorite_Artwork.ArtworkId where User_Favorite_Artwork.userID =@userId";
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Artwork artwork = new Artwork();
                        artwork.ArtworkId = (int)reader["artworkId"];
                        artwork.ArtworkTitle = (string)reader["title"];
                        artwork.ArtworkDescription = (string)reader["description"];
                        artwork.ImageUrl = (string)reader["imageUrl"];
                        artwork.Medium = (string)reader["medium"];
                        artwork.CreationDate = (DateTime)reader["creationDate"];
                        artwork.ArtistId = (int)reader["artistId"];
                        artworks.Add(artwork);
                    }
                }
                if(artworks.Count > 0)
                {
                    Console.WriteLine("\t\n--- User Favourite Artwork Details ---");
                    foreach (var artwork in artworks)
                    {
                        Console.WriteLine($"\n{artwork}");

                    }
                    return true;
                }
                return false;
            }
            catch (ArtWorkNotFoundException e)
            {
                throw new ArtWorkNotFoundException($"The UserId is not found.. Please Check the ID {userId} : {e.Message}");
            }
        }
        #endregion

        #region RemoveArtworkFromFavorite
        //RemoveArtworkFromFavorite
        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            try
            {
                UserFavoriteArtwork userFavoriteArtworks = new UserFavoriteArtwork();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "delete from User_Favorite_Artwork where UserId = @userId and ArtworkId = @artworkId";
                    cmd.Parameters.AddWithValue("@userId",userId);
                    cmd.Parameters.AddWithValue("@artworkId",artworkId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected== 0)
                    {
                        throw new ArtWorkNotFoundException($"\nYour Favourite Artwork has been removed Successfully");
                    }
                    Console.WriteLine("\n Your Artwork has been removed successfully.");
                    return true;
                }
            }
            catch (ArtWorkNotFoundException e)
            {
                throw new ArtWorkNotFoundException($"The ArtworkId or UserId is not found.. Please Check the ID {artworkId} or {userId} : {e.Message}");
            }
        }
        #endregion

        #region AddGallery
        public bool AddGallery(Gallery gallery)
        {
            Gallery artworks = new Gallery();
            using (sqlConnection = DbConnUtil.GetConnectionObject())
            {
                cmd.CommandText = "insert into Gallery values (@GalleryID,@GalleryName,@Description,@Location,@Curator,@OpeningHours)";
                cmd.Parameters.AddWithValue("@GalleryID", gallery.GalleryId);
                cmd.Parameters.AddWithValue("@GalleryName", gallery.GalleryName);
                cmd.Parameters.AddWithValue("@Description", gallery.Description);
                cmd.Parameters.AddWithValue("@Location", gallery.GalleryLocation);
                cmd.Parameters.AddWithValue("@Curator", gallery.Curator);
                cmd.Parameters.AddWithValue("@OpeningHours", gallery.OpeningHours);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                try
                {
                    if (rowAffected > 0)
                    {
                        Console.WriteLine($"\n Your Gallery has been added Successfully");
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }
        #endregion

        #region UpdateGallery
        public bool UpdateGallery(Gallery gallery)
        {
            try
            {
                Artwork artworks = new Artwork();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "update Gallery set GalleryName = @GalleryName, Description = @description, Location = @Location, Curator = @Curator, OpeningHours = @OpeningHours where GalleryID = @GalleryID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GalleryID", gallery.GalleryId);
                    cmd.Parameters.AddWithValue("@GalleryName", gallery.GalleryName);
                    cmd.Parameters.AddWithValue("@Description", gallery.Description);
                    cmd.Parameters.AddWithValue("@Location", gallery.GalleryLocation);
                    cmd.Parameters.AddWithValue("@Curator", gallery.Curator);
                    cmd.Parameters.AddWithValue("@OpeningHours", gallery.OpeningHours);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected != 0)
                    {
                        Console.WriteLine($"\n Your Gallery has been Updated Successfully");
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Remove Gallery
        public bool RemoveGallery(int galleryID)
        {
            try
            {
                Gallery artworks = new Gallery();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "delete from Gallery where galleryID = @galleryID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@galleryID", galleryID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected == 0)
                    {
                        throw new ArtWorkNotFoundException($"Gallery with ID {galleryID} not found.");
                    }
                    Console.WriteLine("\n Your Artwork has been removed successfully.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Remove Gallery by Id : {ex.Message}");
            }
        }
        #endregion

        #region SearchGallery
        public List<Gallery> SearchGallery(string name)
        {
            try
            {
                List<Gallery> artworks = new List<Gallery>();
                using (sqlConnection = DbConnUtil.GetConnectionObject())
                {
                    Artwork artwork = new Artwork();
                    cmd.CommandText = "select * from Gallery where galleryName like @name";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", $"%{name}%");
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Gallery gallery = new Gallery();
                        gallery.GalleryId = (int)reader["GalleryId"];
                        gallery.GalleryName = (string)reader["GalleryName"];
                        gallery.Description = (string)reader["Description"];
                        gallery.GalleryLocation = (string)reader["Location"];
                        gallery.Curator = (int)reader["Curator"];
                        gallery.OpeningHours = (string)reader["OpeningHours"];
                        artworks.Add(gallery);
                    }
                }
                return artworks;
            }
            catch (Exception e)
            {
                throw new Exception($"The gallery is not found.. Please Check the Gallery name");
            }
        }
        #endregion
    }
}
