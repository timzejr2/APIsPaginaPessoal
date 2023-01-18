using AutoMapper;
using MainPostsAPI.Models;
using MainPostsAPI.Data.ValueObjects;

namespace MainPostsAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Post, PostVO>().ReverseMap();
                config.CreateMap<PostItem, PostItemVO>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
