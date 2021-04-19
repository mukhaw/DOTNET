using AutoMapper;
using MyWebApp.Client.DTO;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Read;
using MyWebApp.Client.DTO.Update;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DAL.Entity.Byer, Domain.Byer>();
            this.CreateMap<Domain.Byer, ByerDTO>();
            this.CreateMap<ByerCreateDTO, ByerUpdateModel>();
            this.CreateMap<ByerUpdateDTO, ByerUpdateModel>();
            this.CreateMap<ByerUpdateModel, DAL.Entity.Byer>();
            
            this.CreateMap<DAL.Entity.Collection, Domain.Collection>();
            this.CreateMap<Domain.Collection, CollectionDTO>();
            this.CreateMap<CollectionCreateDTO, CollectionUpdateModel>();
            this.CreateMap<CollectionUpdateDTO, CollectionUpdateModel>();
            this.CreateMap<CollectionUpdateModel, DAL.Entity.Collection>();
            
            this.CreateMap<DAL.Entity.Picture, Domain.Picture>();
            this.CreateMap<Domain.Picture, PictureDTO>();
            this.CreateMap<PictureCreateDTO, PictureUpdateModel>();
            this.CreateMap<PictureUpdateDTO, PictureUpdateModel>();
            this.CreateMap<PictureUpdateModel, DAL.Entity.Picture>();
            
            this.CreateMap<DAL.Entity.Owner, Domain.Owner>();
            this.CreateMap<Domain.Owner, OwnerDTO>();
            this.CreateMap<OwnerCreateDTO, OwnerUpdateModel>();
            this.CreateMap<OwnerUpdateDTO, OwnerUpdateModel>();
            this.CreateMap<OwnerUpdateModel, DAL.Entity.Owner>();
            
            this.CreateMap<DAL.Entity.Note, Domain.Note>();
            this.CreateMap<Domain.Note, NoteDTO>();
            this.CreateMap<NoteCreateDTO, NoteUpdateModel>();
            this.CreateMap<NoteUpdateDTO, NoteUpdateModel>();
            this.CreateMap<NoteUpdateModel, DAL.Entity.Note>();
        }
    }
}