using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jakeFirstAzureWebApp.Pages
{
    public class DataTransferModel : PageModel
    {
        public List<TableItem> tableItems = new List<TableItem>();

        public void OnGet()
        {
            List<TableItem> retreivedTableItems = HttpContext.Session.GetObject<List<TableItem>>("TableItemsStore");
            if (retreivedTableItems.Count > 0)
            {
                tableItems = retreivedTableItems;
            }
        }
    }
}