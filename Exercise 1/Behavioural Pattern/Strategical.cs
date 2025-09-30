//using System;

//// Step 1: Define a common Strategy interface
//interface ITextFormatter
//{
//    string Format(string text);
//}

//// Step 2: Create different strategies
//class UpperCaseFormatter : ITextFormatter
//{
//    public string Format(string text) => text.ToUpper();
//}

//class LowerCaseFormatter : ITextFormatter
//{
//    public string Format(string text) => text.ToLower();
//}

//class TitleCaseFormatter : ITextFormatter
//{
//    public string Format(string text)
//    {
//        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
//    }
//}

//// Step 3: Context class (uses strategies)
//class TextEditor
//{
//    private ITextFormatter _formatter;

//    public void SetFormatter(ITextFormatter formatter)
//    {
//        _formatter = formatter;
//    }

//    public void PublishText(string text)
//    {
//        Console.WriteLine(_formatter.Format(text));
//    }
//}

//// Step 4: Demo
//class Program2
//{
//    static void Main()
//    {
//        TextEditor editor = new TextEditor();

//        editor.SetFormatter(new UpperCaseFormatter());
//        editor.PublishText("hello world");

//        editor.SetFormatter(new LowerCaseFormatter());
//        editor.PublishText("HELLO WORLD");

//        editor.SetFormatter(new TitleCaseFormatter());
//        editor.PublishText("hello design patterns");
//    }
//}
