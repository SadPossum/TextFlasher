namespace TextFlasher.DomainModel
{
    public interface ITextService
    {
        string LoadText();

        void SaveText(string text);
    }
}
