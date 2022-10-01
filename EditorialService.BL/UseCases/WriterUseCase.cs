﻿using EditorialService.BL.Common;
using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.UseCases
{
    public class WriterUseCase : IWriterUseCase
    {
        public readonly EditorialDbContext db;

        public WriterUseCase(EditorialDbContext db)
        {
            this.db = db;
        }

        public async Task<PostResponse> getPostByAuthor(OwnPostRequest postRequest)
        {
            return await PostQueries.getPostsByAuthor(db, postRequest);
        }
    }
}
