using Newtonsoft.Json;
using SpeedrunComApi.EnumOptions;
using SpeedrunComApi.Interfaces;
using SpeedrunComApi.Models.Runs;
using SpeedrunComApi.Objects;
using SpeedrunComApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Endpoints
{
    public class RunsEndpoint : EndpointBase
    {
        internal RunsEndpoint(IRateLimitedRequester requester) : base(requester) { }

        private readonly string baseUrl = "v1/runs";

        public async Task<ApiResponse<List<Run>>> GetRunsAsync(int pageSize = 20, int page = 1, RunOrderBy orderBy = RunOrderBy.Game, SortDirection sortDir = SortDirection.Asc, RunStatusFilter status = RunStatusFilter.All)
        {
            var parameters = GetListDefaultParameters(status, orderBy, sortDir, pageSize, page);

            var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResponse<List<Run>>>(response);
        }

        public async Task<ApiResponse<List<Run>>> GetRunsByGameAsync(string gameId, int pageSize = 20, int page = 1, RunOrderBy orderBy = RunOrderBy.Game, SortDirection sortDir = SortDirection.Asc, RunStatusFilter status = RunStatusFilter.All)
        {
            var parameters = GetListDefaultParameters(status, orderBy, sortDir, pageSize, page);
            parameters.Add($"game={gameId}");

            var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResponse<List<Run>>>(response);
        }

        public async Task<ApiResponse<List<Run>>> GetRunsByUserAsync(string userId, int pageSize = 20, int page = 1, RunOrderBy orderBy = RunOrderBy.Game, SortDirection sortDir = SortDirection.Asc, RunStatusFilter status = RunStatusFilter.All)
        {
            var parameters = GetListDefaultParameters(status, orderBy, sortDir, pageSize, page);
            parameters.Add($"user={userId}");

            var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResponse<List<Run>>>(response);
        }

        public async Task<ApiResponse<List<Run>>> GetRunsByExaminerAsync(string examinerId, int pageSize = 20, int page = 1, RunOrderBy orderBy = RunOrderBy.Game, SortDirection sortDir = SortDirection.Asc, RunStatusFilter status = RunStatusFilter.All)
        {
            var parameters = GetListDefaultParameters(status, orderBy, sortDir, pageSize, page);
            parameters.Add($"examiner={examinerId}");

            var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResponse<List<Run>>>(response);
        }

        public async Task<ApiResponse<List<Run>>> GetRunsByLevelAsync(string levelId, int pageSize = 20, int page = 1, RunOrderBy orderBy = RunOrderBy.Game, SortDirection sortDir = SortDirection.Asc, RunStatusFilter status = RunStatusFilter.All)
        {
            var parameters = GetListDefaultParameters(status, orderBy, sortDir, pageSize, page);
            parameters.Add($"level={levelId}");

            var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResponse<List<Run>>>(response);
        }

        public async Task<ApiResponse<List<Run>>> GetRunsByCategoryIdAsync(string categoryId, int pageSize = 20, int page = 1, RunOrderBy orderBy = RunOrderBy.Game, SortDirection sortDir = SortDirection.Asc, RunStatusFilter status = RunStatusFilter.All)
        {
            var parameters = GetListDefaultParameters(status, orderBy, sortDir, pageSize, page);
            parameters.Add($"category={categoryId}");

            var response = await _requester.CreateGetRequestAsync(baseUrl, parameters).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResponse<List<Run>>>(response);
        }

        private List<string> GetListDefaultParameters(RunStatusFilter status, RunOrderBy orderBy, SortDirection sortDir, int max, int page)
        {
            List<string> parameters = new List<string>();
            parameters.Add($"direction={sortDir.GetDescription()}");
            parameters.Add($"orderby={orderBy.GetDescription()}");
            parameters.Add($"max={max}");
            if (page > 1)
            {
                parameters.Add($"offset={max * (page - 1)}");
            }

            if(status != RunStatusFilter.All)
            {
                parameters.Add($"status={status.GetDescription()}");
            }

            return parameters;
        }
    }
}
