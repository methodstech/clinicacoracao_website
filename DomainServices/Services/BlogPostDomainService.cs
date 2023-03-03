// ----------------------------------------------------------------------------
// DomainServices.BlogPostDomainService.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;
using DomainServices.Interfaces;

namespace DomainServices.Services
{
    internal class BlogPostDomainService : IBlogPostDomainService
    {
        private readonly IBlogPostRepository _repository;

        public BlogPostDomainService(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        public BlogPost Create(BlogPost blogPost)
        {
            return _repository.Create(blogPost);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public BlogPost GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<BlogPost> List(BlogPostFilter filter)
        {
            return _repository.List(filter);
        }

        public bool Update(BlogPost blogPost)
        {
            return _repository.Update(blogPost);
        }
    }
}
