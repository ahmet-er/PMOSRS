using PMOSRS.Model.Models.Items.Interface;
using System;
using System.IO;
using System.Text;

namespace PMOSRS.Model.Models.Items
{
    public class TextLog : ILog
    {
        // Variables
        private string LogPath { get; set; }
        public string Message { get; set; }
        public string ExMessage { get; set; }

        public void Add(string message, string exMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"=={DateTime.Now}==");
            stringBuilder.Append($"Message: {Message}");
            stringBuilder.Append($"Exception Message: {ExMessage}");

            try
            {
                if (File.Exists(LogPath))
                {
                    File.AppendAllText(LogPath, stringBuilder.ToString());
                }
                
            }
            catch
            {
            }

        }

        public TextLog()
        {


            string logFolder = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            string logDayFilePath = Path.Combine(logFolder, DateTime.Now.ToString("dddd") + ".log");

            try
            {
                // Dosyanın Varlığı Kontrol ediliyor
                if (File.Exists(logDayFilePath))
                {
                    FileInfo fi = new FileInfo(logDayFilePath);

                    // Dosyanın oluşturulma zamanı bugün değilse dosyayı yeniden oluşturacağız.
                    if (fi.CreationTime.ToShortDateString() != DateTime.Now.ToShortDateString())
                    {
                        File.Delete(logDayFilePath);
                        File.Create(logDayFilePath);
                    }
                }
                else
                {
                    if (!Directory.Exists(logFolder))
                    {
                        Directory.CreateDirectory(logFolder);
                    }

                    File.Create(logDayFilePath);

                }
            }
            catch
            {
            }

            this.LogPath = logDayFilePath;
        }

    }
}
