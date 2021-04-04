﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ray.BiliBiliTool.Agent.Attributes;
using Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos;
using Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos.Relation;
using WebApiClientCore.Attributes;

namespace Ray.BiliBiliTool.Agent.BiliBiliAgent.Interfaces
{
    /// <summary>
    /// 关注相关接口
    /// </summary>
    [Header("Host", "api.bilibili.com")]
    [Header("Referer", "https://space.bilibili.com/")]
    public interface IRelationApi : IBiliBiliApi
    {
        /// <summary>
        /// 获取关注列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/x/relation/followings")]
        Task<BiliApiResponse<GetFollowingsResponse>> GetFollowings(GetFollowingsRequest request);

        /// <summary>
        /// 获取特别关注列表
        /// </summary>
        /// <returns></returns>
        [Header("Cache-Control", "no-cache")]
        [Header("Pragma", "no-cache")]
        [JsonReturn(EnsureMatchAcceptContentType = false)]
        [HttpGet("/x/relation/tag")]
        Task<BiliApiResponse<List<UpInfo>>> GetSpecialFollowings(GetSpecialFollowingsRequest request);

        /// <summary>
        /// 获取关注分组
        /// </summary>
        /// <returns></returns>
        [Header("Sec-Fetch-Mode", "no-cors")]
        [Header("Sec-Fetch-Dest", "script")]
        [HttpGet("/x/relation/tags?jsonp=jsonp")]
        Task<BiliApiResponse<List<TagDto>>> GetTags([Header("Referer")] string referer = RelationApiConstant.GetTagsReferer);
    }

    public class RelationApiConstant
    {
        /// <summary>
        /// GetTags接口中的Referer
        /// {0}为UserId
        /// </summary>
        public const string GetTagsReferer = "https://space.bilibili.com/{0}/fans/follow";
    }
}
