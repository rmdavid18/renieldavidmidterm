using Microsoft.EntityFrameworkCore;
using renieldavid.webdev.Infrastructure.Domain.Models;
using System.Data;
using System.Reflection;
using Type = renieldavid.webdev.Infrastructure.Domain.Models.Type;

namespace renieldavid.webdev.Infrastructure.Domain
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
          : base(options)
        {
        }
        public DbSet<video> Videos { get; set; }
        public DbSet<StreamingAndService> StreamingAndServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<video> videos = new List<video>();
            List<StreamingAndService> streamingAndServices = new List<StreamingAndService>();

            videos.Add(new video()
            {
                VideoId = Guid.Parse("00965ecf-acae-46fe-8775-d7834b07fd96"),
                Title = "Turning Red",
                Description = "patayan",
                DateOfPublish = DateTime.Now,
                Type = Type.Series,
                Id= Guid.Parse("1cef3b99-b69d-4b12-9b0a-b63c5fddcdc7")
            });

            videos.Add(new video()
            {
                VideoId = Guid.Parse("7ce68d5c-5b65-495a-8a63-14aeb48da87d"),
                Title = "Master",
                Description = "buhayan",
                DateOfPublish = DateTime.Now,
                Type = Type.Movie,
                Id = Guid.Parse("e9ff85ab-f0c1-4de9-a9f2-5bee39150e4f")
            });


            videos.Add(new video()
            {
                VideoId = Guid.Parse("1d72f000-dbbd-419b-8af2-f571e1486ac2"),
                Title = "Kimi",
                Description = "aso",
                DateOfPublish = DateTime.Now,
                Type = Type.Movie,
                Id = Guid.Parse("e9735c93-7e74-4fbc-83e8-45d5999ccb1a")
            });

           

            modelBuilder.Entity<video>().HasData(videos);



            //Streaming

            streamingAndServices.Add(new StreamingAndService()
            {
                Id = Guid.Parse("1cef3b99-b69d-4b12-9b0a-b63c5fddcdc7"),
                Title = "NETFLIX",
                Description = "is an American subscription video on-demand over-the-top streaming service and production company based in Los Gatos, California. Founded in 1997 by Reed Hastings and Marc Randolph in Scotts Valley, California, it offers a film and television series library through distribution deals as well as its own productions, known as Netflix Originals.",
                Abbreviation = "NFLX"
            });
            streamingAndServices.Add(new StreamingAndService()
            {
                Id = Guid.Parse("e9ff85ab-f0c1-4de9-a9f2-5bee39150e4f"),
                Title = "amazon prime video",
                Description = "Watch award-winning Prime Originals on the web or Prime Video app. Enjoy Anywhere. Watch The Grand Tour. Unlimited Streaming. Start Free Trial. Download and Go.",
                Abbreviation = "APV"
            });
            streamingAndServices.Add(new StreamingAndService()
            {
                Id = Guid.Parse("e9735c93-7e74-4fbc-83e8-45d5999ccb1a"),
                Title = "Crunchyroll",
                Description = "Crunchyroll is an American subscription video on-demand over-the-top streaming service owned by Sony through a joint venture between Sony Pictures and Sony Music Entertainment Japan's Aniplex. The company primarily distributes films and television series from East Asian media, including Japanese anime outside Asia.",
                Abbreviation = "HIME"
            });

          

            modelBuilder.Entity<StreamingAndService>().HasData(streamingAndServices);
        }

    }
}
