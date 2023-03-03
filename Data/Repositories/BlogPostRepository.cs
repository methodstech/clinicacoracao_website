// ----------------------------------------------------------------------------
// Data.BlogPostRepository.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using Dapper;
using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;

namespace Data.Repositories
{
    internal class BlogPostRepository : RepositoryBase, IBlogPostRepository
    {
        public BlogPost Create(BlogPost obj)
        {
            obj.BpoId = Connection.QueryFirst<int>(
                "exec blogpost_i @BpoImagePath, @BpoTitulo, @BpoData, @BpoAutor, @BpoTexto", obj);
            return obj;
        }

        public bool Delete(int id)
        {
            var affectedRows = Connection.Execute("exec blogpost_d @BpoId", new {BpoId = id});
            return affectedRows > 0;
        }

        public BlogPost GetById(int id)
        {
            var result = Connection.QueryFirstOrDefault<BlogPost>("exec blogpost_g @BpoId", new {BpoId = id});
            return result;
        }

        public IEnumerable<BlogPost> List(BlogPostFilter filter)
        {
            var result = Connection.Query<BlogPost>("exec blogpost_l @filtro", filter);
            return result;
        }

        public bool Update(BlogPost obj)
        {
            var affectedRows =
                Connection.Execute("exec blogpost_u @BpoId, @BpoImagePath, @BpoTitulo, @BpoAutor, @BpoTexto", obj);
            return affectedRows > 0;
        }
    }
}
