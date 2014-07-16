using System;
using Nancy.TwitterBootstrap.Example.Models;

namespace Nancy.TwitterBootstrap.Example
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ =>
            {
                return View["index", new ExampleViewModel
                {
                    Color = "#FF000F",
                    Email = "bernos@gmail.com",
                    Number = 23,
                    Password = "password",
                    DateTime = DateTime.UtcNow
                }];
            };
        }
    }
}