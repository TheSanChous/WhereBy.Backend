﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Application.Interfaces;
using WhereBy.Domain;

namespace WhereBy.Application.Notices.Commands.CreateNote
{
    public class CreateNoticeCommandHandler
        :IRequestHandler<CreateNoticeCommand, int>
    {
        private readonly IDatabaseContext _dbContext;

        public CreateNoticeCommandHandler(IDatabaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateNoticeCommand request,
            CancellationToken cancellationToken)
        {
            var shop = await _dbContext.Shops
                .FirstOrDefaultAsync(shop => shop.Id == request.ShopId, cancellationToken: cancellationToken);

            if (shop is null)
            {
                throw new NotFoundException(typeof(Shop).Name, request.ShopId);
            }

            var notice = new Notice
            {
                Shop = shop,
                Description = request.Description,
                Created = DateTime.Now.ToString("yyyy-MM-dd"),
                Modified = DateTime.Now.ToString("yyyy-MM-dd"),
                Deleted = null
            };

            await _dbContext.Notices.AddAsync(notice, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return notice.Id;
        }
    }
}