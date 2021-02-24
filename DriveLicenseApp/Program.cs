using ApplicationDatabaseModels;
using ApplicationDomainEntity.Db;
using ApplicationDtos;
using ApplicationUIServices.Mapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DriveLicenseApp
{
    public class Program
    {
        private static readonly ApplicationDbContext _db = new ApplicationDbContext();

        public static void Main(string[] args)
        {
            //List<Topic> data = new List<Topic>();
            //var fileName = @"C:\Users\User\Desktop\DriveLicenseApp\DriveLicenseApp\Source\topics.json";
            //using(StreamReader reader = new StreamReader(fileName))
            //{
            //    data = JsonConvert.DeserializeObject<List<Topic>>(reader.ReadToEnd());
            //}

            //_db.Topics.AddRange(data);
            //_db.SaveChanges();

            //List<Ticket> data = default;
            //List<pathTickets> dataSecond = new List<pathTickets>();
            //var fileName = @"C:\Users\User\Desktop\DriveLicenseApp\DriveLicenseApp\Source\tickets.json";
            //using(StreamReader reader =new StreamReader(fileName))
            //{
            //    dataSecond = JsonConvert.DeserializeObject<List<pathTickets>>(reader.ReadToEnd());
            //}

            //dataSecond.ForEach(o =>
            //{
            //    var answers = o.Answers.Split('/', '"');
            //    for(var i = 0; i < answers.Count(); i++) { if(i % 2 != 0) { o.SplitedAnswers.Add(answers[i]); } }
            //});

            //data = dataSecond.Select(o => new Ticket()
            //{
            //    Answers = o.SplitedAnswers.Select(a => new Answer()
            //    {
            //        Text = a
            //    }).ToList(),
            //    Coeficient = o.Coeficient,
            //    CorrectAnswer = o.CorrectAnswer,
            //    Cutoff = o.Cutoff,
            //    Desc = o.Desc,
            //    FileParent = o.FileParent,
            //    Filename = o.Filename,
            //    TicketId = o.TicketId,
            //    Question = o.Question,
            //    Timestamp = o.Timestamp,
            //    Topic = o.Topic
            //}).ToList();

            //_db.Tickets.AddRange(data);
            //_db.SaveChanges();

            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
