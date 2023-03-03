// ----------------------------------------------------------------------------
// Domain.BlogPost.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System;

namespace Domain.Entities
{
    public class BlogPost
    {
        public int BpoId { get; set; }
        public string BpoImagePath { get; set; }
        public string BpoTitulo { get; set; }
        public DateTime BpoData { get; set; }
        public string BpoAutor { get; set; }
        public string BpoTexto { get; set; }
    }
}
