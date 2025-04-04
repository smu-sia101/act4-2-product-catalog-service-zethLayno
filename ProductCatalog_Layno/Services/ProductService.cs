using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ProductCatalog_Layno.Models;
namespace ProductCatalog_Layno.Services;

public class ProductService
{
    private readonly IMongoCollection<ProductModel> _productsCollection;

    public ProductService(
    IOptions<ProductDatabaseSettings> ProductDatabaseSettings)
{
    var mongoClient = new MongoClient(
        ProductDatabaseSettings.Value.ConnectionString);

    var mongoDatabase = mongoClient.GetDatabase(
        ProductDatabaseSettings.Value.DatabaseName);

        _productsCollection = mongoDatabase.GetCollection<ProductModel>(
        ProductDatabaseSettings.Value.ProductsCollectionName);
}
    public async Task<List<ProductModel>> GetAsync() =>
        await _productsCollection.Find(_ => true).ToListAsync();

    public async Task<ProductModel?> GetAsync(string id) =>
        await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ProductModel newProduct) =>
        await _productsCollection.InsertOneAsync(newProduct);

    public async Task UpdateAsync(string id, ProductModel updatedProduct) =>
        await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

    public async Task RemoveAsync(string id) =>
        await _productsCollection.DeleteOneAsync(x => x.Id == id);
}

