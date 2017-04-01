using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class MyDecoder
{
	public MyDecoder()
	{
		
	}

    public static string DecodeText(string text)
    {
        text = text.Replace(":D", "<img src='Emoticons/smile.png'>");
        text = text.Replace(":))", "<img src='Emoticons/laugh.png'>");
        text = text.Replace(":)", "<img src='Emoticons/happy.png'>");
        text = text.Replace(":((", "<img src='Emoticons/cry.png'>");
        text = text.Replace(":(", "<img src='Emoticons/sad.png'>");
        text = text.Replace("~X(", "<img src='Emoticons/angry.png'>");


        text = text.Replace("[b]", "<b>");
        text = text.Replace("[/b]", "</b>");
        text = text.Replace("[u]", "<u>");
        text = text.Replace("[/u]", "</u>");
        text = text.Replace("[i]", "<i>");
        text = text.Replace("[/i]", "</i>");
        text = text.Replace("[quote]", "<blockquote>");
        text = text.Replace("[/quote]", "</blockquote>");
        
        return text;
    }

}