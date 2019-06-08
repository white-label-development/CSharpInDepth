using System;

namespace Delegates101
{
    public class MoshTutorial
    {
        //good old mosh :)
        // https://www.youtube.com/watch?v=jQgwEsJISy0

        public void Main()
        {
            var video = new Video { Title = "v1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailSvc = new MailService(); //subscriber

            videoEncoder.VideoEncoded += mailSvc.OnVideoEncoded; //function reference / pointer to the method (to be called later)
            videoEncoder.Encode(video);
        }
    }


    //v1
    public class VideoEncoder
    {

        //1. define a delegate
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); //old school .NET1

        //1.1
        public event EventHandler<VideoEventArgs> VideoEncoded2; // in .NET2(?) a generic type was added that combines 1. and 2.

        //2. define an event
        public event VideoEncodedEventHandler VideoEncoded;

        //3. raise an event

        //3.1 need a method we can call
        protected virtual void OnVideoEncoded(Video video) //convention: protected, virtual, void.
        {
            if (VideoEncoded == null)
            {
                // no subscribers
                return;
            }
            
            //we have subscribers (pointers)
            VideoEncoded(this, new VideoEventArgs{ Video=video} );

            
        }

        public void Encode(Video video)
        {
            //encode...

            //3 raise event:
            OnVideoEncoded(video);

        }
    }

    public class Video
    {
        public string Title { get; set; }
    }

    //a subscriber
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {            
            //send email
            Console.WriteLine("sending an email..." + e.Video.Title);
        }
    }

    //Extend EventArgs so we can pass a ref to the video just encoded.
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
}
