// ----------------------------------------------------------------------------
// AppServices.IBlogPostAppService.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using AppServices.Dtos;
using AppServices.Filters;

namespace AppServices.Interfaces
{
    public interface IBlogPostAppService
    {
        BlogPostDto Create(BlogPostDto conclusao);
        IEnumerable<BlogPostDto> List(BlogPostFilterDto filter);
        BlogPostDto GetById(int id);
        bool Update(BlogPostDto conclusao);
        bool Delete(int id);
    }
}
