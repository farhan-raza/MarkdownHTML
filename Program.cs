using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertHTMLmarkdown
{
    class Program
    {
        static String dataDir = Path.GetFullPath(GetDataDir_Data());

        static void Main(string[] args)
        {
            // Convert HTML to Markdown
            ConvertHTMLtoMarkdown();

            // Convert HTML to Markdown with SaveOptions
            ConvertHTMLtoMarkdown_options();

            // Convert Markdown to HTML
            ConvertMarkdownToHTML();

            Console.WriteLine("HTML to Markdown and Markdown to HTML Conversion Examples Executed Successfully!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();

        }


        static void ConvertHTMLtoMarkdown()
        {
            // Prepare an HTML code and save it to the file.
            var code = "<h1>Header 1</h1>" +
                       "<h2>Header 2</h2>" +
                       "<p>Hello World!!</p>";
            System.IO.File.WriteAllText(dataDir + "document.html", code);

            // Call ConvertHTML method to convert HTML to Markdown.
            Aspose.Html.Converters.Converter.ConvertHTML(dataDir + "document.html", new Aspose.Html.Saving.MarkdownSaveOptions(), dataDir + "output.md");
        }

        static void ConvertHTMLtoMarkdown_options()
        {
            // Prepare an HTML code and save it to the file.
            var code = "<h1>Header 1</h1>" +
                       "<h2>Header 2</h2>" +
                       "<p>Hello World!!</p>" +
                       "<a href='aspose.com'>aspose</a>";
            System.IO.File.WriteAllText(dataDir + "document.html", code);

            // Create an instance of SaveOptions and set up the rule: 
            // - only <a> and <p> elements will be converted to markdown.
            var options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            // Call the ConvertHTML method to convert the HTML to Markdown.
            Aspose.Html.Converters.Converter.ConvertHTML(dataDir + "document.html", options, dataDir + "output_options.md");
        }

        static void ConvertMarkdownToHTML()
        {
            // Prepare a simple Markdown example
            var code = "### Hello World" +
                       "\r\n" +
                       "[visit applications](https://products.aspose.app/html/family)";
            // Create a Markdown file
            System.IO.File.WriteAllText(dataDir + "input_document.md", code);

            // Convert Markdown to HTML document
            Aspose.Html.Converters.Converter.ConvertMarkdown(dataDir + "input_document.md", dataDir + "MarkdownToHTMLoutput.html");
        }


        public static string GetDataDir_Data()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory());
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return Path.Combine(startDirectory, "Data\\");
        }
    }
}
