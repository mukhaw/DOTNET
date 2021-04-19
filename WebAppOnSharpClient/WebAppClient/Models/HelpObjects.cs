using System.Collections.Generic;

namespace WebAppClient.Models
{
    public class HelpObjects
    {
        
        public IEnumerable<Byer> Byers;
        public IEnumerable<Owner> Owners;
        public IEnumerable<Picture> Pictures;

        public HelpObjects(IEnumerable<Byer> byers, IEnumerable<Owner> owners, IEnumerable<Picture> pictures)
        {
            Byers = byers;
            Owners = owners;
            Pictures = pictures;
        }
    }
}