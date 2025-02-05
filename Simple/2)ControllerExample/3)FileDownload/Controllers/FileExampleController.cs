﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _3_FileDownload.Controllers
{
    public class FileExampleController : Controller
    {
        // Скачивание файла по пути. 
        public ActionResult Download1()
        {
            return File("/Download/1.mp3", "audio/*", "1.mp3");
        }

        // Скачивание массива байт.
        public ActionResult Download2()
        {
            // Переменная содержашая путь к файлу.
            string pathToOpen = Server.MapPath("/Download/1.mp3");
            // массив байт
            byte[] data;
            // Заполнение массива байт данными из файла. 
            data = System.IO.File.ReadAllBytes(pathToOpen);
            return File(data, "audio/*", "1.mp2");
        }

        // Создание файла из потока.
        public ActionResult Download3()
        {
            // Переменная, содержащая путь к файлу. 
            string pathToOpen = Server.MapPath("/Download/1.mp3");
            // Создание потока streamForDownload
            // и открытие файла /Download/1.mp3 для чтения. 
            FileStream streamForDownload = 
                new FileStream(Server.MapPath("/Download/1.mp3"), 
                    FileMode.Open);
            // Поток и MIME.
            return File(streamForDownload, "audio/*", "1.mp3");
        }
    }
}
