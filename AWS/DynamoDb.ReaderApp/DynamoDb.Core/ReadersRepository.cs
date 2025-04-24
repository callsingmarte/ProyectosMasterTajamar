using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using DynamoDb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDb.Core
{
    public class ReadersRepository : IReadersRepository
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;

        public ReadersRepository()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext();
        }

        public async Task Add(ReaderInputModel entity)
        {
            var reader = new Reader
            {
                Id = Guid.NewGuid(),
                Name = entity.Name,
                EmailAddress = entity.EmailAddress,
                AddedOn = DateTime.UtcNow,
                Username = entity.UserName,                
            };

            await _context.SaveAsync(reader);
        }

        public async Task<ReaderViewModel> All(string paginationToken = "")
        {
            var table = _context.GetTargetTable<Reader>();

            var scanOps = new ScanOperationConfig();

            if (!string.IsNullOrEmpty(paginationToken))
            {
                scanOps.PaginationToken = paginationToken;
            }

            var results = table.Scan(scanOps);

            List<Document> data = await results.GetNextSetAsync();

            IEnumerable<Reader> readers = _context.FromDocuments<Reader>(data);

            return new ReaderViewModel
            {
                PaginationToken = results.PaginationToken,
                Readers = readers,
                ResultsType = ResultsType.List
            };
        }

        public async Task<IEnumerable<Reader>> Find(SearchRequest searchReq)
        {
            var scanConditions = new List<ScanCondition>();
            if (!string.IsNullOrEmpty(searchReq.UserName))
            {
                scanConditions.Add(new ScanCondition("Username", ScanOperator.Equal, searchReq.UserName));
            }
            if (!string.IsNullOrEmpty(searchReq.EmailAddress))
            {
                scanConditions.Add(new ScanCondition("EmailAddress", ScanOperator.Equal, searchReq.EmailAddress));
            }
            if (!string.IsNullOrEmpty(searchReq.Name))
            {
                scanConditions.Add(new ScanCondition("Name", ScanOperator.Equal, searchReq.Name));
            }

            return await _context.ScanAsync<Reader>(scanConditions, null).GetRemainingAsync();
        }

        public async Task Remove(Guid readerId)
        {
            await _context.DeleteAsync<Reader>(readerId);
        }

        public async Task<Reader> Single(Guid readerId)
        {
            return await _context.LoadAsync<Reader>(readerId);

        }

        public async Task Update(Guid readerId, ReaderInputModel entity)
        {
            var reader = await Single(readerId);

            reader.EmailAddress = entity.EmailAddress;
            reader.Username = entity.UserName;
            reader.Name = entity.Name;
            reader.AddedOn = entity.AddedOn;

            await _context.SaveAsync<Reader>(reader);
        }
    }
}
