﻿using QuirkyBookRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuirkyBookRental.Extensions
{
    public static class ThumbnailExtensions
    {
        public static IEnumerable<ThumbnailModel> GetBookThumbnail(this List<ThumbnailModel> thumbnails, ApplicationDbContext db = null, string search = null)
        {
            try
            {
                if (db == null)
                {
                    db = ApplicationDbContext.Create();
                }
                thumbnails = (from b in db.Books
                              select new ThumbnailModel
                              {
                                  BookId = b.Id,
                                  Title = b.Title,
                                  Description = b.Description,
                                  ImageUrl = b.ImageUrl,
                                  Link = "/BookDetail/Index/" + b.Id,
                                  GenreName = b.Genre.Name,
                                  MostPopular = false

                              }).ToList();
                if (search != null)
                {
                    Dictionary<int, int> hm = new Dictionary<int, int>();
                    foreach (var book in thumbnails)
                    {
                        if (book.GenreName.Equals(search))
                        {
                            hm.Add(book.BookId, 0);
                            foreach (var b in db.BookRental)
                            {
                                if (hm.ContainsKey(b.BookId))
                                    hm[b.BookId] += 1;
                            }
                        }

                    }
                    var keyOfMaxValue = hm.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                    foreach (var book in thumbnails)
                    {
                        if (book.BookId == keyOfMaxValue)
                            book.MostPopular = true;
                    }

                    return thumbnails.Where(t => t.GenreName.ToLower().Contains(search.ToLower())).OrderBy(t => t.GenreName);
                }
            }
            catch (Exception ex)
            {
            }
            return thumbnails.OrderBy(b => b.Title);
        }
    }
}