using Microsoft.AspNetCore.Mvc;
using MVC_Library_Management_App.Helpers;
using MVC_Library_Management_App.Models;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_Library_Management_App.Controllers
{
    public class AuthorController : Controller
    {
        private List<Author> authors = ListHelper.Authors; // ListHelper konumundan alınan author listesi

        [HttpGet] // Yazar ekleme formuna yönlendiren action
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Yazar ekleme formundan gelen bilgileri yakalayan action
        public IActionResult Create(CreateAuthorViewModel formData)
        {            
            int newAuthorId = 1;// listede eleman yoksa id 1 olarak atanır

            if (authors.Any()) // listede eleman varsa listedeki max eleman sayısının bir fazlası id olarak atanır 
            {
                newAuthorId = authors.Max(x => x.Id) + 1;
            }
            var author = new Author()
            {
                Id = newAuthorId,
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                DateOfBirth = formData.DateOfBirth
            };

            authors.Add(author);

            return RedirectToAction("List", "Author"); // Yazarların listelendiği sayfaya yönlendirme
        }

        [HttpGet]
        public IActionResult Edit(int id) // id si gelen yazarı düzenlemek için olan forma yönlendiren action
        {
            var author = authors.FirstOrDefault(x => x.Id == id);

            var authorEditViewModel = new AuthorEditViewModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
            };

            return View(authorEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AuthorEditViewModel formData) // düzenleme formundan gelen bilgileri o id de olan verinin bilgileriyle değiştiren action
        {
            var author = authors.FirstOrDefault(x => x.Id == formData.Id);

            author.FirstName = formData.FirstName;
            author.LastName = formData.LastName;
            author.DateOfBirth = formData.DateOfBirth;
            return RedirectToAction("List", "Author"); // list sayfasına geri yönlendirir
        }

        public IActionResult Delete(int id) // id si alınan veriyi siler
        {
            var author = authors.FirstOrDefault(x => x.Id == id);
            authors.Remove(author);

            return RedirectToAction("List", "Author");
        }

        [HttpGet]
        public IActionResult List() // oluşturulan verileri listeleyen sayfaya yönlendiren action
        {
            if (!authors.Any())// liste boş ise listede eleman yok sayfasına yönlendirir
            {
                return RedirectToAction("IsEmpty", "Home");
            }
            var authorModel = authors.Select(x => new CreateAuthorViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
            }).ToList();

            return View(authorModel); // View a listelenmesi için oluşturulaan modeli gönderir
        }

        public IActionResult Details(int id) // id si alınan verinin detay sayfasına yönlendirir
        {
            var author = authors.FirstOrDefault(x => x.Id == id);

            var authorBooks = ListHelper.Books.Where(b => b.AuthorId == author.Id).ToList();

            ViewBag.Author = author;
            ViewBag.AuthorBooks = authorBooks;
           
            return View();
        }
    }
}
