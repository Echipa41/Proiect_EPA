using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.SeleniumComponent;
using ForumTest.Common;
using OpenQA.Selenium;

namespace ForumTest.ProjectComponent
{
    public static class ForumClass
    {
        public static void NavigateToCategory(String category)
        {
            var title = SeleniumGetMethods.Parent(SeleniumGetMethods.GetParentNode(SeleniumGetMethods.GetWebElementInnerHTML(category)));
            SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(2, title)).Click();
        }

        public static void NavigateToSubject(String subject)
        {
            SeleniumGetMethods.Parent(SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML(subject))).Click();
        }

        public static void AddComment(String comment)
        {
            var textarea = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$AddMessageLoginView$MessageTB");
            textarea.Clear();
            textarea.SendKeys(comment);
            var addCommentButton = SeleniumGetMethods.GetWebElementByAttribut("value", "Adauga comentariu");
            addCommentButton.Click();
            Sincronize.Wait(5000);
        }

        public static void EditeComment(String originalComment, String newComment, bool append)
        {
            var commentRootElem = SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML(originalComment));
            var childs = SeleniumGetMethods.GetChilds(commentRootElem);
            var editeButton = SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetFirstChild((IWebElement)childs[3]));
            editeButton.Click();
            var textarea = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$AddMessageLoginView$EditMessageTB");
           
            if (!append)
            {
                textarea.Clear();
            }
            else
            {

            }
            textarea.SendKeys(newComment);
            var addCommentButton = SeleniumGetMethods.GetWebElementByAttribut("value", "Salveaza");
            addCommentButton.Click();
            Sincronize.Wait(5000);
        }

        public static void DeleteComment(String comment)
        {
            var commentRootElem = SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML(comment));
            var childs = SeleniumGetMethods.GetChilds(commentRootElem);
            var editeButton = SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetFirstChild((IWebElement)childs[3]));
            var delete = SeleniumGetMethods.GetNextSibling(editeButton);
            delete.Click();
        }

        public static void SearchAutor(String autor)
        {
            var autorText = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$MessageUserTB");
            autorText.SendKeys(autor);
            var cautaButton = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$Button2");
            cautaButton.Click();
        }

        public static void SearchContent(String content)
        {
            var continutText = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$MessageDescriptionTB");
            continutText.SendKeys(content);
            var cautaButton = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$Button2");
            cautaButton.Click();
        }

        public static void Citeaza(String text)
        {
            var citeaza = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$MessageListView$ctrl0$QuoteLoginView$QuoteMessageButton");
            citeaza.Click();
            AddComment(text);
        }
    }
}
