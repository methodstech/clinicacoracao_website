// ----------------------------------------------------------------------------
// DomainServices.IBlogPostDomainService.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using Domain.Entities;
using Domain.Filters;

namespace DomainServices.Interfaces
{
    public interface IBlogPostDomainService
    {
        BlogPost Create(BlogPost conclusao);
        IEnumerable<BlogPost> List(BlogPostFilter filter);
        BlogPost GetById(int id);
        bool Update(BlogPost conclusao);
        bool Delete(int id);
    }
}
