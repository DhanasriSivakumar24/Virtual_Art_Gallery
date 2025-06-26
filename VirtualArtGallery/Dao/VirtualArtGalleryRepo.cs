using System.Data.SqlClient;
using System.Xml.Linq;
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
                    cmd.CommandText = "delete * from Artwork where ArtworkId = @artworkId";
                    cmd.Parameters.RemoveAt(artworkID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine($"\n Your Artwork has been Remove Successfully");
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine($"Failed to Updated Artwork by Id : {ex.Message}");
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
                    cmd.CommandText = "update Artwork set Title = @title, Description = @description, CreationDate = @creationDate, Medium = @medium, ImageUrl = @url where ArtworkId = @ArtistId";
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
                        Console.WriteLine($"\n Your Artwork has been update Successfully");
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

        #region GetArtworkById
        //GetArtworkById
        public Artwork GetArtworkById(int artworkID)
        {
            Artwork artworks = new Artwork();
            using (sqlConnection = DbConnUtil.GetConnectionObject())
            {
                cmd.CommandText = "select artworkId,title,description,imageUrl from Artwork where ArtworkId = @artworkId";
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
                    return artwork;
                }
                return artworks;
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
            catch(ArtWorkNotFoundException e) 
            {
                throw new ArtWorkNotFoundException($"The Artwork is not found.. Please Check the Artwork {name}");
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
                    if (rowAffected > 0)
                    {
                        Console.WriteLine($"\nYour Favourite Artwork has been removed Successfully");
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (ArtWorkNotFoundException e)
            {
                throw new ArtWorkNotFoundException($"The ArtworkId or UserId is not found.. Please Check the ID {artworkId} or {userId} : {e.Message}");
            }
        }
        #endregion
    }
}
