using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tests
{
    public class Utilities
    {
        public void DoSomething<T>(T value) where T : new()
        {
            var a = new T();
        }
    }

    public class Book
    {
        public int Price { get; set; }
    }

    public class Video
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
    
    public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    
    public class VideoEncoder
    {
        // public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            VideoEncoded?.Invoke(this, new VideoEventArgs { Video = video});
        }
    }

    internal struct Nullable<T> where T : struct
    {
        private object _value;

        public Nullable(T value)
        {
            _value = value;
        }
        
        public T GetValueOrDefault()
        {
            if (_value == null)
                return default;

            return (T) _value;
        }

        public bool HasValue => _value != null;

        public T Value
        {
            get
            {
                if (_value == null)
                    throw new InvalidOperationException();
                
                return (T)_value;
            }
        }
    }
    
    internal class Program
    {
        public event EventHandler<EventArgs> EventHanlder; 

        public static void Main(string[] arguments)
        {
            Nullable<int> number = new Tests.Nullable<int>();


            Console.WriteLine(number.HasValue);
            Console.WriteLine(number.GetValueOrDefault());
            Console.WriteLine(number.Value);


            dynamic aa = 1;
            var bb = 2;
            var cc = aa + bb;


            EventHandler<EventArgs> eventHandler;
            


            var videos = new List<Video>()
            {
                new Video() { Title = "title 1", Price = 25 },
                new Video() { Title = "title 2", Price = 50 },
            };

            var a = videos.Where((video, index) => video.Price < 75);
            // videos.FindAll((video, index) => video.Price < 10);

            Predicate<Video> predicate;




            var videoEncoder = new VideoEncoder();

            videoEncoder.VideoEncoded += (source, args) =>
            {
                Console.WriteLine("The video was encoded");
            };

            videoEncoder.Encode(new Video());



            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            var max = numbers.Max();


            var max2 = Enumerable.Max(numbers);
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            var books = new List<Book>()
            {
                new Book(){ Price = 5 },
                new Book(){ Price = 7 },
                new Book(){ Price = 12 },
            };

            Predicate<Book> predicate1 = new Predicate<Book>(book => book.Price < 10);

            Predicate<Book> predicate2 = book => book.Price < 10;

            Func<Book, bool> predicate3 = book => book.Price < 10;

            Func<Book, bool> predicate4 = new Func<Book, bool>(book => book.Price < 10);

            var result = books.Where(Predicate5);
            var result2 = books.FindAll(Predicate5);
            
            // var result3 = books.Where(predicate1);

            foreach (var book in result)
            {
                Console.WriteLine(book.Price);
            }
        }

        private static bool Predicate5(Book book)
        {
            return book.Price < 10;
        }
    }
}