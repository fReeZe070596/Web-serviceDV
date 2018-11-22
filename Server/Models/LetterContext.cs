using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class LetterContext : DbContext
    {
        //Создаем контекст данных для работы с БД
        public DbSet<Letter> Letters { get; set; }
    }
}