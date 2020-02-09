namespace PageObjectFramework.Interfaces
{
    public interface IHomePage
    {
        void EnterSearchString(string text);
        string GetPageTitel();
        void ClickOnElementSearchButton();
    }
}