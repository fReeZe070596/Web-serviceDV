using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        //Создаем контекст данных
        LetterContext db = new LetterContext();

        public ActionResult Index()
        {            
            //Получаем объекты из Бд
            IEnumerable<Letter> letters = db.Letters;
            //Передаем все объекты в динамическое свойство Letters в ViewBag
            ViewBag.Letters = letters;
            //Возвращаем представление
            return View();
        }

       

        //Принимаем запрос от клиента с входящей иформацией
        [HttpPost]
        public string CreateLetter(string title, string target, string sender,  string content, string date)
        {
            Letter letter = new Letter()
            {
                Title = title,
                Target = target,
                Sender = sender,
                Content = content,
                Date = date
            };            
            AddLetter(letter);
            return "Письмо отправлено!";
        }

        //Удаление письма из базы данных
        public ActionResult DeleteLetter(int id)
        {
            Letter letter = db.Letters.Find(id);
            if (letter != null)
            {
                db.Letters.Remove(letter);
                db.SaveChanges();
            }
            return RedirectToAction("Index");     
           
        }

        //Добавление письма в базу данных
        private void AddLetter(Letter letter)
        {
            //Добавление письма в базу данных
            db.Letters.Add(letter);
            //Сохранение изменений в базе данных
            db.SaveChanges();
        }
    }
}
