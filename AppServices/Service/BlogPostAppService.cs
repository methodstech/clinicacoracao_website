// ----------------------------------------------------------------------------
// AppServices.BlogPostAppService.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using AppServices.Dtos;
using AppServices.Extensions;
using AppServices.Filters;
using AppServices.Interfaces;
using Domain.Entities;
using Domain.Filters;
using DomainServices.Interfaces;

namespace AppServices.Service
{
    internal class BlogPostAppService : IBlogPostAppService
    {
        private readonly IBlogPostDomainService _service;

        public BlogPostAppService(IBlogPostDomainService service)
        {
            _service = service;
        }

        public BlogPostDto Create(BlogPostDto blogPost)
        {
            var result = _service.Create(blogPost.MapTo<BlogPost>());
            return result.MapTo<BlogPostDto>();
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public BlogPostDto GetById(int id)
        {
            return _service.GetById(id).MapTo<BlogPostDto>();
        }

        public IEnumerable<BlogPostDto> List(BlogPostFilterDto filter)
        {
            return _service.List(filter.MapTo<BlogPostFilter>()).Enumerable<BlogPostDto>();
        }

        public bool Update(BlogPostDto blogPost)
        {
            return _service.Update(blogPost.MapTo<BlogPost>());
        }
    }
}
