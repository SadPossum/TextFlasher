using System.IO;

namespace TextFlasher.DomainModel
{
    public class TextService : ITextService
    {
        private const string _filePath = "Text";

        public string LoadText()
        {
            if (File.Exists(_filePath))
                using (StreamReader reader = new StreamReader(_filePath))
                    return reader.ReadToEnd();

            return string.Empty;
        }

        public void SaveText(string text)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                writer.Write(text);
                writer.Flush();
            }
        }
    }
}
