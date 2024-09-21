using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TravelWithMe.InviteCode.Context;
using TravelWithMe.InviteCode.Dtos;

namespace TravelWithMe.InviteCode.Services
{
    public class InviteCodeServices : IInviteCodeServices
    {
        private readonly DapperContext _dapperContext;

        public InviteCodeServices(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateInviteCodeAsync(CreateInviteCodeDto createInviteCodeDto)
        {
            // string query = $"insert into test (deneme) values('olaylar' || '{DateTime.Now.ToString("dd.MM.yyy H m s")}' )";
             string query = "INSERT INTO \"InviteCodes\" (\"Code\", \"UserId\", \"EventId\", \"IsActive\", \"CreatedDate\", \"ValidDate\") VALUES (:code, :userId, :eventId, :isActive, :createdDate, :validDate)";
            //string query = $"INSERT INTO \"InviteCodes\" (\"Code\", \"UserId\", \"EventId\", \"IsActive\", \"CreatedDate\", \"ValidDate\") VALUES (:code, :userId, :eventId, :isActive, to_date('{createInviteCodeDto.CreatedDate.ToString("dd.MM.yyyy")}','dd.mm.yyyy'), to_date('{createInviteCodeDto.ValidDate.ToString("dd.MM.yyyy")}','dd.mm.yyyy'))";

            var parameters = new DynamicParameters();
            parameters.Add(":code", createInviteCodeDto.Code, DbType.String);
            parameters.Add(":userId", createInviteCodeDto.UserId, DbType.String);
            parameters.Add(":eventId", createInviteCodeDto.EventId, DbType.String);
            parameters.Add(":isActive", createInviteCodeDto.IsActive ? 1 : 0, DbType.Int32);
            parameters.Add(":createdDate", createInviteCodeDto.CreatedDate, DbType.DateTime);
            parameters.Add(":validDate", createInviteCodeDto.ValidDate, DbType.DateTime);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
               // await connection.ExecuteAsync(query);
            }
        }

        public Task DeleteInviteCodeAsync(int inviteCodeId)
        {
            string query = "DELETE FROM \"InviteCodes\" WHERE \"InviteCodeId\" = :id";
            var parameters = new DynamicParameters();
            parameters.Add(":id", inviteCodeId, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                return connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultInviteCodeDto>> GetAllCodesAsync()
        {
            string query = "SELECT * FROM \"InviteCodes\"";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInviteCodeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByCodeInviteCodeDto> GetByCodeInviteCodeAsync(string code)
        {
            string query = "SELECT * FROM \"InviteCodes\" WHERE \"Code\" = :code";
            var parameters = new DynamicParameters();
            parameters.Add(":code", code, DbType.String);
            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByCodeInviteCodeDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateInviteCodeAsync(UpdateInviteCodeDto updateInviteCodeDto)
        {
            string query = "UPDATE \"InviteCodes\" SET \"Code\" = :code, \"UserId\" = :userId, \"EventId\" = :eventId, \"IsActive\" = :isActive, \"CreatedDate\" = :createdDate, \"ValidDate\" = :validDate WHERE \"Id\" = :id";
            var parameters = new DynamicParameters();
            parameters.Add(":code", updateInviteCodeDto.Code, DbType.String);
            parameters.Add(":userId", updateInviteCodeDto.UserId, DbType.String);
            parameters.Add(":eventId", updateInviteCodeDto.EventId, DbType.String);
            parameters.Add(":isActive", updateInviteCodeDto.IsActive ? 1 : 0, DbType.Int32);
            parameters.Add(":createdDate", updateInviteCodeDto.CreatedDate, DbType.DateTimeOffset);
            parameters.Add(":validDate", updateInviteCodeDto.ValidDate, DbType.DateTimeOffset);
            parameters.Add(":id", updateInviteCodeDto.InviteCodeId, DbType.Int32);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
