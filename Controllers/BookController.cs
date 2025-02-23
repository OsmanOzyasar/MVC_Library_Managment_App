using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Library_Management_App.Helpers;
using MVC_Library_Management_App.Models;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_Library_Management_App.Controllers
{
    public class BookController : Controller
    {
        private List<Book> books = ListHelper.Books;
        private List<Author> authors = ListHelper.Authors;

        [HttpGet]
        public IActionResult Create()// Kitap oluşturmak için ilgili view a yönlendirir
        {
            ViewBag.Authors = authors.Select(x => new CreateAuthorViewModel()// Kitap oluşturuken seçilmesi için o anda bulunan yazarların bilgisini view a yollar
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,

            }).ToList();


            return View();
        }

        [HttpPost] // Kitap ekleme formundan gelen bilgileri yakalayan action
        public IActionResult Create(CreateBookViewModel formData)
        {
            int newBookId = 1;// listede eleman yoksa id 1 olarak atanır

            if (books.Any()) // listede eleman varsa listedeki max eleman sayısının bir fazlası id olarak atanır 
            {
                newBookId = books.Max(x => x.Id) + 1;
            }
            var book = new Book()
            {
                Id = newBookId,
                Title = formData.BookTitle,
                Genre = formData.BookGenre,
                ISBN = formData.BookISBN,
                CopiesAvailable = formData.AvailableBookCopies,
                PublishDate = formData.BookPublishDate,
                AuthorId = formData.AuthorIdV
            };


            books.Add(book);


            return RedirectToAction("List"); // kitapların listelendiği sayfaya yönlendirir
        }



        [HttpGet]
        public IActionResult List() // oluşturulan verileri listeleyen sayfaya yönlendiren action
        {
            if (!books.Any()) // liste boş ise listede eleman yok sayfasına yönlendirir
            {
                return RedirectToAction("IsEmpty", "Home");
            }

            var listModel = books.Select(x => new CreateBookViewModel()
            {
                BookTitle = x.Title,
                BookGenre = x.Genre,
                BookId = x.Id,
                BookISBN = x.ISBN,
                BookPublishDate = x.PublishDate,
                AvailableBookCopies = x.CopiesAvailable,

            }).ToList();


            return View(listModel); // View a listelenmesi için oluşturulaan modeli gönderir
        }
     

        [HttpGet]
        public IActionResult Edit(int id) // id si gelen kitabı düzenlemek için olan forma yönlendiren action
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            var bookEditViewModel = new BookEditViewModel() 
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                CopiesAvailable = book.CopiesAvailable,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                AuthorId = book.AuthorId,
            };

            ViewBag.Authors = authors;

            return View(bookEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookEditViewModel formData) // Kitap düzenleme formundan gelen bilgileri ilgili id ye sahip kitabın bilgileriyle değiştirir
        {
            var book = books.FirstOrDefault(x => x.Id == formData.Id);

            book.Title = formData.Title;
            book.Genre = formData.Genre;
            book.CopiesAvailable = formData.CopiesAvailable;
            book.PublishDate = formData.PublishDate;
            book.AuthorId = formData.AuthorId;
            book.ISBN = formData.ISBN;

            return RedirectToAction("List");
        }

        public IActionResult Details(int id) // id si gelen kitabın detay sayfasına yönlendirir
        {
            var book = ListHelper.Books.FirstOrDefault(x => x.Id == id);

            var author = ListHelper.Authors.FirstOrDefault(a => a.Id == book.AuthorId);
           
            ViewBag.Book = book;
            ViewBag.Author = author;

            return View();
        }

        public IActionResult Delete(int id) // id si gelen kitabı siler
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            books.Remove(book);

            return RedirectToAction("List");
        }
    }
}
