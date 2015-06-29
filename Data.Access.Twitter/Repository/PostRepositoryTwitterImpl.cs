using CadastroLivros.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using System.Configuration;
using CadastroLivros.Domain.Entity;

namespace Data.Access.Twitter.Repository
{
    public class PostRepositoryTwitterImpl : IPostRepository
    {

        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public PostRepositoryTwitterImpl()
        {
            _consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            _consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            _accessToken = ConfigurationManager.AppSettings["AccessToken"];
            _accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];
        }

        public Post SaveOrUpdate(Post post)
        {
            var service = GetAuthenticatedService();

            var status = "O livro mais vendido da semana foi: A história";
            var tweet = service.SendTweet(new SendTweetOptions { Status = status });

            post.PostId = tweet.Id;
            post.PostDate = tweet.CreatedDate;

            return post;
        }

        public Post Get(long id)
        {
            var service = GetAuthenticatedService();
            var tweet = service.GetTweet(new GetTweetOptions() { Id = id });

            return new Post
            {
                PostId = tweet.Id,
                PostMessage = tweet.Text,
                PostDate = tweet.CreatedDate
            };
        }

        public IEnumerable<Post> GetAll()
        {
            var service = GetAuthenticatedService();
            var tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());

            List<Post> posts = new List<Post>();
            foreach (var tweet in tweets)
            {
                posts.Add(new Post
                                {
                                    PostId = tweet.Id,
                                    PostMessage = tweet.Text,
                                    PostDate = tweet.CreatedDate
                                });
            }

            return posts;
        }


        public void Delete(Post post)
        {

        }


        private TwitterService GetAuthenticatedService()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.TraceEnabled = true;
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            return service;
        }

    }
}
