using AutoMapper;
using Adou.DDD.Paging;
using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Adou.DDD.LinqExtensions
{
    /// <summary>
    /// AutoMapper映射扩展方法
    /// </summary>
    public static class AutoMapExtensions
    {
        static AutoMapExtensions()
        {
            //string->int
            Mapper.CreateMap<string, int>().ConvertUsing((x) =>
            {
                int o = 0;
                int.TryParse(x, out o);
                return o;
            });
            //int->bool
            Mapper.CreateMap<int, bool>().ConvertUsing((x) =>
            {
                return x > 0;
            });
            //string->objectId
            Mapper.CreateMap<string, ObjectId>().ConvertUsing((x) =>
            {
                return (x != null) ? ObjectId.Parse(x) : ObjectId.Empty;
            });
            //objectId->string
            Mapper.CreateMap<ObjectId, string>().ConvertUsing((x) =>
            {
                return (x != null) ? x.ToString() : string.Empty;
            });

        }
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            Mapper.CreateMap<TSource, TDestination>();
            return Mapper.Map<List<TDestination>>(source);
        }


        /// <summary>
        /// 为集合进行automapper
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> MapTo<TResult>(this IEnumerable self)
        {
            if (self == null)
                throw new ArgumentNullException();
            return (IEnumerable<TResult>)Mapper.DynamicMap(self, self.GetType(), typeof(IEnumerable<TResult>));
        }
        /// <summary>
        /// 为分页集合进行automapper
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static PagedList<TResult> MapToPaged<TResult>(this IPagedList self)
        {
            if (self == null)
                throw new ArgumentNullException();
            var result = (PagedList<TResult>)Mapper.DynamicMap(self, self.GetType(), typeof(PagedList<TResult>));
            //显示的为分页参数赋值
            result.PageIndex = self.PageIndex;
            result.PageSize = self.PageSize;
            result.TotalCount = self.TotalCount;
            result.TotalPages = self.TotalPages;
            return result;

        }
        /// <summary>
        /// 为新对象进行automapper
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TResult MapTo<TResult>(this object self)
        {
            if (self == null)
                throw new ArgumentNullException();
            Mapper.CreateMap(self.GetType().UnderlyingSystemType, typeof(TResult));
            return (TResult)Mapper.Map(self, self.GetType(), typeof(TResult));
        }

        /// <summary>
        /// 为已经存在的对象进行automapper
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static TResult MapTo<TResult>(this object self, TResult result)
        {
            if (self == null)
                throw new ArgumentNullException();
            Mapper.CreateMap(self.GetType().UnderlyingSystemType, typeof(TResult));
            return (TResult)Mapper.Map(self, result, self.GetType(), typeof(TResult));

        }


    }
}