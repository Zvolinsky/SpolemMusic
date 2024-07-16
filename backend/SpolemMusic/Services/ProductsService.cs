using Microsoft.Identity.Client;
using SpolemMusic.Data;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Data.Models;
using SpolemMusic.Data.ReactJSTypes;

namespace SpolemMusic.Server.Services
{
    public class ProductsService
    {
        private AppDBContext _context;

        public ProductsService(AppDBContext context)
        {
            _context = context;
        }

        public List<ProductType> GetProducts()
        {
            var products = _context.Products.Select(p => new ProductType()
            {
                Id = p.Id,
                Title = p.Name,
                Artists = p.ProductArtists.Select(n => n.Artist.Name).ToList(),
                Format = p.Format.Name,
                Genre = p.Genre.Name,
                Year = p.Year,
                Country = p.Country.Name,
                Description = p.Description,
                Tracklist = p.Tracklist.Select(n => new TrackType()
                {
                    TrackNumber = n.TrackNumber,
                    Title = n.Title,
                    Length = n.Length,
                    Artists = n.TrackArtists.Select(n => n.Artist.Name).ToList()
                }).ToList(),
                Label = p.Label.Name,
                CatalogueNum = p.CatalogueNum,
                CoverImage = p.CoverImage,
                PreviewMusic = p.PreviewMusic,
                Price = p.Price,
                CountInStock = p.CountInStock,
                Reviews = p.Reviews.Select(n => new ReviewType()
                {
                    User = "NeverMind123",
                    ReviewRating = n.Rate,
                    ReviewComment = n.Comment
                }).ToList(),

            }).ToList();
            return products;
        }

        public ProductType GetProductById(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).Select(p => new ProductType()
            {
                Id = p.Id,
                Title = p.Name,
                Artists = p.ProductArtists.Select(n => n.Artist.Name).ToList(),
                Format = p.Format.Name,
                Genre = p.Genre.Name,
                Year = p.Year,
                Country = p.Country.Name,
                Description = p.Description,
                Tracklist = p.Tracklist.Select(n => new TrackType()
                {
                    TrackNumber = n.TrackNumber,
                    Title = n.Title,
                    Length = n.Length,
                    Artists = n.TrackArtists.Select(n => n.Artist.Name).ToList()
                }).ToList(),
                Label = p.Label.Name,
                CatalogueNum = p.CatalogueNum,
                CoverImage = p.CoverImage,
                PreviewMusic = p.PreviewMusic,
                Price = p.Price,
                CountInStock = p.CountInStock,
                Reviews = p.Reviews.Select(n => new ReviewType()
                {
                    User = "NeverMind123",
                    ReviewRating = n.Rate,
                    ReviewComment = n.Comment
                }).ToList(),

            }).FirstOrDefault();
            return product;
        }

        public Product AddProduct(ProductDTO product)
        {
            var _product = new Product()
            {
                Name = product.Name,
                FormatId = product.FormatId,
                GenreId = product.GenreId,
                Year = product.Year,
                CountryId = product.CountryId,
                Description = product.Description,
                LabelId = product.LabelId,
                CatalogueNum = product.CatalogueNum,
                CoverImage = product.CoverImage,
                PreviewMusic = product.PreviewMusic,
                Price = product.Price,
                CountInStock = product.CountInStock,

            };
            _context.Products.Add(_product);
            _context.SaveChanges();

            return _product;
        }
        public void UpdateProduct(ProductDTO product, int id)
        {
            var _product = _context.Products.FirstOrDefault(n => n.Id == id);
            if (_product != null)
            {
                _product.Name = product.Name;
                _product.FormatId = product.FormatId;
                _product.GenreId = product.GenreId;
                _product.Year = product.Year;
                _product.CountryId = product.CountryId;
                _product.Description = product.Description;
                _product.LabelId = product.LabelId;
                _product.CatalogueNum = product.CatalogueNum;
                _product.CoverImage = product.CoverImage;
                _product.PreviewMusic = product.PreviewMusic;
                _product.Price = product.Price;
                _product.CountInStock = product.CountInStock;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteProduct(int id)
        {
            var _product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (_product != null)
            {
                _context.Products.Remove(_product);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }
    }


}
