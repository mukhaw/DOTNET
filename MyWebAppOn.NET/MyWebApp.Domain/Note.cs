using System;
using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain
{
    public class Note:BaseNote, IByerContainer,IOwnerContainer
    {
        public int Id { get; set; }
        
        public DateTime DateVisit { get; set; }
    }
}