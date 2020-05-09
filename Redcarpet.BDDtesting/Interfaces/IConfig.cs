using Redcarpet.BDDtesting.Configuration;

namespace Redcarpet.BDDtesting.Interfaces
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        string GetUsername();
        string GetPassword();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
        string GetEnvironment();
        string GetDevUrl();
        string GetQaUrl();
        string GetTokenDev();
        string GetTokenQA();
    }
}
