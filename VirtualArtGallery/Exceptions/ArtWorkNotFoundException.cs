using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Exceptions
{
    internal class ArtWorkNotFoundException:ApplicationException
    {
        public ArtWorkNotFoundException()
        {
            
        }
        public ArtWorkNotFoundException(string message):base(message)
        {
            
        }
    }
}
