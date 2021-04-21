namespace Ponea.Homework.Bookshop.Application.Contracts.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Mappings the specified profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        void Mapping(AutoMapper.Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}