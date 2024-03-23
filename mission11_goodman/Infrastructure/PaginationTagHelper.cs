using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mission11_goodman.Models.ViewModels; // Importing necessary view models
using System;

namespace mission11_goodman.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory; // Creating a private variable for the URL helper factory

        // Constructor to initialize the tag helper with a URL helper factory
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            urlHelperFactory = temp; // Assigning the injected URL helper factory to the private variable
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; } // Property to hold the view context

        public string? PageAction { get; set; } // Property to hold the page action

        public Pagination PageModel { get; set; } // Property to hold the pagination information

        public bool PageClassesEnabled { get; set; } = false; // Flag to enable page classes

        public string PageClass { get; set; } = string.Empty; // CSS class for pagination

        public string PageClassNormal { get; set; } = string.Empty; // CSS class for normal pagination items

        public string PageClassSelected { get; set; } = string.Empty; // CSS class for selected pagination item

        // Method to process the tag helper and generate pagination HTML
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext); // Getting URL helper

                TagBuilder result = new TagBuilder("div"); // Creating a div tag for pagination

                // Generating pagination links
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a"); // Creating an anchor tag for each page
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i }); // Setting href attribute

                    // Adding CSS classes if enabled
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString()); // Setting page number as inner HTML

                    result.InnerHtml.AppendHtml(tag); // Appending anchor tag to the result
                }

                output.Content.AppendHtml(result.InnerHtml); // Setting output content with pagination HTML
            }
        }
    }
}