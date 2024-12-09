using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.LibaryApi.Models.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int PagesNumber { get; set; }
        public bool IsAvailable { get; set; }

        //public ProblemDetails ValidateCreateBook(Book book)
        //{
        //    ProblemDetails details = new ProblemDetails();

        //    if (book.BookName.Length < 3)
        //    {
        //        details.Title = "Validasyon Hatası.";

        //    }
            
        //    if(book.AuthorName == null || book.AuthorName.Length < 2)
        //    {
        //        return false;
        //    }

        //    if(book.PagesNumber <= 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
}
