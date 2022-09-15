using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Net;
using Syroot.Windows.IO;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsHelper.Schedules
{
    public class ScheduleDownloader
    {
        private static readonly string scheduleWebPage = "https://wu.up.krakow.pl/wu/PodzGodzin2.aspx";
        private static readonly string usernameInputId = "userNameInput";
        private static readonly string passwordInputId = "passwordInput";
        private static readonly string submitButtonId = "submitButton";
        private static readonly string downloadScheduleButtonId = @"ctl00_ctl00_ContentPlaceHolder_RightContentPlaceHolder_btn_GetPDF";

        public static bool DownloadSchedule(string userEmail, string userPassword)
        {
            try
            {
                NetworkCredential LoginCredentials = new NetworkCredential(userEmail, userPassword);

                WebDriver WebDriver = new FirefoxDriver();
                WebDriver.Url = scheduleWebPage;

                IWebElement UsernameInput = WebDriver.FindElement(By.Id(usernameInputId));
                IWebElement PasswordInput = WebDriver.FindElement(By.Id(passwordInputId));
                IWebElement LoginButton = WebDriver.FindElement(By.Id(submitButtonId));
                UsernameInput.SendKeys(LoginCredentials.UserName);
                PasswordInput.SendKeys(LoginCredentials.Password);
                LoginButton.Click();

                WebDriverWait WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
                Actions Actions = new Actions(WebDriver);
                WebDriver.Manage().Window.Maximize();
                IJavaScriptExecutor WebDriverExecutor = WebDriver;

                WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(downloadScheduleButtonId)));
                IWebElement DownloadScheduleButton = WebDriver.FindElement(By.Id(downloadScheduleButtonId));
                Actions.MoveToElement(DownloadScheduleButton);
                WebDriverExecutor.ExecuteScript("arguments[0].click()", DownloadScheduleButton);

                return true;
            }
            catch(Exception e)
            {
                Geckodriver.Geckodriver.CopyGeckodriverToDebugDirectory();
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static async Task<bool> DownloadScheduleAsync(string userEmail, string userPassword)
        {
            return await Task.Run(() => DownloadSchedule(userEmail, userPassword));         
        }
    }
}
