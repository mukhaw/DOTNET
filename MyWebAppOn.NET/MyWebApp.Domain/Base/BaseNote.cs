using System;

namespace MyWebApp.Domain.Base
{
    public class BaseNote
    {
        public int? ByerId { get; set; }
        public int? OwnerId { get; set; }
        
        public int? PictureId { get; set; }
    
    }
}