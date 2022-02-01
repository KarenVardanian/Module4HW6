using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Module4HW6;
using Module4HW6.Entities;
using Module4HW6.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW6
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Ganre> Ganres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfigurations());
            modelBuilder.ApplyConfiguration(new GanreConfigurations());
            modelBuilder.ApplyConfiguration(new SongArtistConfigurations());
            modelBuilder.ApplyConfiguration(new SongConfigurations());
        }
    }
    public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();



            string connectionString = "Server=DESKTOP-3OAE4IJ\\SQLEXPRESS;Database=ModuleWork;Trusted_Connection=True;"; 
            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new ApplicationContext(optionsBuilder.Options);
        }
    }

       

    public class InsertData
    {
        public readonly ApplicationContext _context;

        public InsertData(ApplicationContext applicationContext)
        {
            _context = applicationContext; 
        }

        public async void QueryTwo()
        {
                   
            using (ApplicationContext db = _context)
            {
                var b = _context.Ganres.Include(x => x.Songs).Count();
            }
        }
        public async Task QueryThree()
        {
            //select Song.Title,Min(Artist.DateOfBirth)
            //from Artist, Song
            //group by Title,Song.ReleasedDate
            //having Min(Artist.DateOfBirth) > ReleasedDate
            using (ApplicationContext db = _context)
            {
                List<int> vs = new List<int>();
                var b = await _context.Artists.ToListAsync();
                DateTimeOffset ds = b.Min(m => m.DateOfBirth);
                var c = _context.Songs.FirstOrDefault(f=>f.ReleasedDate<ds);

                Console.Write(c.ReleasedDate);
                    }
            
        }
        public async Task QueryOne()
        {
           string query= "select Artist.Name, Ganre.Title,Song.Title from Artist join SongArtist on" +
                " Artist.Artist = SongArtist.ArtistId " +
                "join Song on Song.Id = SongArtist.SongId join Ganre on Ganre.Ganre = Song.GanreId and " +
                "Artist.Name is not null"
        }
        public async Task AddData()
        {
            var s = new SongArtist { ArtistId = 5, SongId = 14 };
            var s1 = new SongArtist { ArtistId = 6, SongId = 15 };
            var s2 = new SongArtist { ArtistId = 7, SongId = 14 };
            var s3 = new SongArtist { ArtistId = 8, SongId = 13 };
            var s4 = new SongArtist { ArtistId = 7, SongId = 14 };
            var s5 = new SongArtist { ArtistId = 8, SongId = 15 };
            await _context.SongArtists.AddAsync(s);
            await _context.SongArtists.AddAsync(s1);
            await _context.SongArtists.AddAsync(s2);
            await _context.SongArtists.AddAsync(s3);
            await _context.SongArtists.AddAsync(s4);
            _context.SaveChanges();

            using (ApplicationContext db = _context)
            {
               

                List<Artist> artists = new List<Artist>()
                {
                    new Artist{Name = "Piter", DateOfBirth=new DateTimeOffset(), Phone = "0661783321", Email = "Piter.gmail.com", InstagramUrl="UrlPiter" },
                    new Artist{Name = "Dim", DateOfBirth=new DateTimeOffset(), Phone = "0661725921", Email = "Dim.gmail.com", InstagramUrl="UrlDim" },
                    new Artist{Name = "Summer", DateOfBirth=new DateTimeOffset(), Phone = "0661105921", Email = "Summer.gmail.com", InstagramUrl="UrlSummer" },
                    new Artist{Name = "Winter", DateOfBirth=new DateTimeOffset(), Phone = "0662345921", Email = "Winter.gmail.com", InstagramUrl="UrlWinter" }
                };
                List<Ganre> ganre = new List<Ganre>()
                {
                    new Ganre{ Title="Rock" },
                    new Ganre{ Title="Classcic"},
                    new Ganre{ Title="Espanian"},
                    new Ganre{ Title="Electro"}
                };
                List<Song> song = new List<Song>()
                {
                    new Song{ Title="First", Duration=2, ReleasedDate= new DateTimeOffset()},
                    new Song{ Title="Second", Duration=8, ReleasedDate= new DateTimeOffset()},
                    new Song{ Title="Third", Duration=4, ReleasedDate= new DateTimeOffset()},
                    new Song{ Title="Fourrth", Duration=1, ReleasedDate= new DateTimeOffset()}
                };

                List<SongArtist> songArtists = new List<SongArtist>()
                {
                    new SongArtist { ArtistId=7
                        , SongId=12 },
                    new SongArtist { ArtistId=5,SongId=13 },
                    new SongArtist { ArtistId=7, SongId=14 },
                    new SongArtist { ArtistId=6, SongId=15 },
                    new SongArtist { ArtistId=8, SongId=13 },
                    new SongArtist { ArtistId=5, SongId=14 },
                };
                await _context.SongArtists.AddRangeAsync(songArtists);
                await _context.Artists.AddRangeAsync(artists);
                await _context.Songs.AddRangeAsync(song);
                await _context.Ganres.AddRangeAsync(ganre);
                _context.SaveChanges();

            }

        }
    }
}


