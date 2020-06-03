using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace jakeFirstAzureWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<TableItem> tableItems = new List<TableItem>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            tableItems = new TableItem().ReturnDemoList();
            HttpContext.Session.SetObject("TableItemsStore", tableItems);
        }
    }

    public class TableItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }

        public TableItem() { }

        public TableItem(int ItemNumber)
        {
            Name = "Name " + ItemNumber;
            Description = "Example Description " + ItemNumber;
            Count = ItemNumber;
        }

        public List<TableItem> ReturnDemoList()
        {
            List<TableItem> tableItems = new List<TableItem>
            {
                new TableItem(1),
                new TableItem(2),
                new TableItem(3),
                new TableItem(4)
            };

            return tableItems;
        }
    }

    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
