using MyWebApp.Client.DTO.Create;

namespace MyWebApp.Client.DTO.Update
{
    public class NoteUpdateDTO:NoteCreateDTO
    {
        public int Id { get; set; }
    }
}