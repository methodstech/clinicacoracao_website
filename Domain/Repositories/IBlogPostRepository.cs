// ----------------------------------------------------------------------------
// Domain.IBlogPostRepository.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using Domain.Entities;
using Domain.Filters;

namespace Domain.Repositories
{
    public interface IBlogPostRepository : IRepository<BlogPost, BlogPostFilter>
    {
    }
}
