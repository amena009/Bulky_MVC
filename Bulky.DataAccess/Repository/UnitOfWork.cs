﻿using Bulky.DataAccess.Repository.IRepository;
using BulkyMVCWebApp.Data;
using System;


namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category{ get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
