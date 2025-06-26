
using System.Xml.Linq;

namespace VirtualArtGallery.Entity
{
    internal class User
    {
        int userId;
        string userName;
        string password;
        string email;
        string firstName;
        string lastName;
        DateTime userDob;
        string profilePicture;

        public int UserId
        {
            get {  return userId; }
            set { userId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime UserDob
        {
            get { return userDob; }
            set { userDob = value; }
        }
        public string ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; }
        }

        public User() 
        {
            
        }
        public User(int userId, string userName, string password, string email, string firstName, string lastName, DateTime userDob, string profilePicture)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            UserDob = userDob;
            ProfilePicture = profilePicture;
        }

        public override string ToString()
        {
            return $"UserID= {UserId}\t Username= {UserName}\t Email= {Email}\t Name= {FirstName} {LastName}\t Passwords= {Password}\t DateOfBirth= {UserDob}\t ProfilePicture= {ProfilePicture}";
        }

    }
}
